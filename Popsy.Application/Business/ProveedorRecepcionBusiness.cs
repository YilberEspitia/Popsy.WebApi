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
        /// Constructor.
        /// </summary>
        /// <param name="mapper">mapper.</param>
        /// <param name="repository"><see cref="IProveedorRecepcionRepository"/> repositorio.</param>
        public ProveedorRecepcionBusiness(IMapper mapper, IProveedorRecepcionRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        async Task<bool> IProveedorRecepcionBusiness.CreateAsync(ProveedorRecepcionObject proveedorSave)
        {
            Boolean response;
            TblProveedorRecepcionEntity proveedor = _mapper.Map<TblProveedorRecepcionEntity>(proveedorSave);
            TblProveedorRecepcionEntity? proveedorDb = default;
            if (proveedor.proveedor_recepcion_id != default)
                proveedorDb = await _repository.GetProveedorRecepcionAsync(proveedor.proveedor_recepcion_id);
            if (proveedorDb is null)
            {
                await _repository.CreateAsync(proveedor);
                response = true;
            }
            else
            {
                await _repository.UpdateAsync(proveedor);
                response = false;
            }
            return response;
        }

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
    }
}
