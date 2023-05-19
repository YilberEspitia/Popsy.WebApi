using System;

using AutoMapper;

using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Business
{
    /// <summary>
    /// Implementa los metodos relacionados con la entidad <see cref="TblProveedorRecepcionEntity"/>.
    /// </summary>
    public class ProveedorRecepcionBusiness : ApplicationBase, IProveedorRecepcionBusiness
    {
        /// <summary>
        /// <see cref="IProveedorRecepcionRepository"/> repositorio.
        /// </summary>
        private readonly IProveedorRecepcionRepository _repository;
        /// <summary>
        /// <see cref="ISapRecepcionDeComprasIntegration"/> repositorio.
        /// </summary>
        private readonly ISapRecepcionDeComprasIntegration _sapIntegration;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapper">mapper.</param>
        /// <param name="repository"><see cref="IProveedorRecepcionRepository"/> repositorio.</param>
        public ProveedorRecepcionBusiness(IMapper mapper, IProveedorRecepcionRepository repository,
            ISapRecepcionDeComprasIntegration sapIntegration) : base(mapper)
        {
            _repository = repository;
            _sapIntegration = sapIntegration;
        }

        async Task<AccionesBD> IProveedorRecepcionBusiness.CreateAsync(ProveedorRecepcionObject proveedorSave)
            => await this.CrearProveedorAsync(proveedorSave);

        async Task<IEnumerable<ProveedorRecepcionObject>> IProveedorRecepcionBusiness.GetProveedoresRecepcionAsync()
            => _mapper.Map<IEnumerable<ProveedorRecepcionObject>>(await _repository.GetProveedoresRecepcionAsync());

        async Task<ProveedorRecepcionObject> IProveedorRecepcionBusiness.GetProveedorRecepcionAsync(string codigoSap)
        {
            TblProveedorRecepcionEntity? proveedor = await _repository.GetProveedorRecepcionAsync(codigoSap);
            if (proveedor is null)
                throw new PopsyException(ErrorType.ProveedorNoEncontrado);
            else
                return _mapper.Map<ProveedorRecepcionObject>(proveedor);
        }

        async Task<ProveedorRecepcionObject> IProveedorRecepcionBusiness.GetProveedorRecepcionAsync(Guid id)
        {
            TblProveedorRecepcionEntity? proveedor = await _repository.GetProveedorRecepcionAsync(id);
            if (proveedor is null)
                throw new PopsyException(ErrorType.ProveedorNoEncontrado);
            else
                return _mapper.Map<ProveedorRecepcionObject>(proveedor);
        }

        #region Integraciones
        async Task<IEnumerable<ResponsePopsySAP>> IProveedorRecepcionBusiness.SyncSAPAsync()
        {
            ISet<ResponsePopsySAP> responsePopsy = new HashSet<ResponsePopsySAP>();
            ResponseSAP<ResultProveedorRecepcion>? response = await _sapIntegration.SyncProveedoresRecepcion();
            if (response is not null)
            {
                foreach (ResultProveedorRecepcion proveedor in response.d.results)
                {
                    try
                    {
                        AccionesBD accion = await this.CrearProveedorAsync(new ProveedorRecepcionObject()
                        {
                            codigo_sap_proveedor = proveedor.Lifnr,
                            nombre = proveedor.Name1,
                        });
                        responsePopsy.Add(new ResponsePopsySAP()
                        {
                            Codigo = proveedor.Lifnr,
                            Accion = accion,
                        });
                    }
                    catch (Exception ex)
                    {
                        responsePopsy.Add(new ResponsePopsySAP()
                        {
                            Codigo = proveedor.Lifnr,
                            Accion = AccionesBD.NoCreado,
                            Error = ex.Message
                        });
                    }
                }
            }
            return responsePopsy;
        }
        #endregion

        #region Metodos privados
        private async Task<AccionesBD> CrearProveedorAsync(ProveedorRecepcionObject proveedorSave)
        {
            AccionesBD response = AccionesBD.NoCreado;
            TblProveedorRecepcionEntity proveedor = _mapper.Map<TblProveedorRecepcionEntity>(proveedorSave);
            TblProveedorRecepcionEntity? proveedorDb = default;
            if (proveedor.codigo_sap_proveedor != default)
                proveedorDb = await _repository.GetProveedorRecepcionPorSapAsync(proveedor.codigo_sap_proveedor);
            if (proveedorDb == default && proveedor.proveedor_recepcion_id != default)
                proveedorDb = await _repository.GetProveedorRecepcionAsync(proveedor.proveedor_recepcion_id);
            if (proveedorDb is null)
            {
                await _repository.CreateAsync(proveedor);
                response = AccionesBD.Creado;
            }
            else
            {
                proveedor.proveedor_recepcion_id = proveedorDb.proveedor_recepcion_id;
                if (this.TieneCambios(proveedorDb, proveedor))
                {
                    await _repository.UpdateAsync(proveedor);
                    response = AccionesBD.Actualizado;
                }
                else
                    response = AccionesBD.NoActualizado;
            }
            return response;
        }

        private bool TieneCambios(TblProveedorRecepcionEntity proveedorDb, TblProveedorRecepcionEntity proveedor)
            => proveedor.nombre != proveedorDb.nombre ||
            proveedor.codigo_sap_proveedor != proveedorDb.codigo_sap_proveedor;
        #endregion
    }
}
