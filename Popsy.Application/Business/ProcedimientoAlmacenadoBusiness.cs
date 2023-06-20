using Popsy.Enums;
using Popsy.Interfaces;

namespace Popsy.Business
{
    public class ProcedimientoAlmacenadoBusiness : IProcedimientoAlmacenadoBusiness
    {
        private readonly IProcedimientoAlmacenadoRepository _repository;

        public ProcedimientoAlmacenadoBusiness(IProcedimientoAlmacenadoRepository repository)
        {
            _repository = repository;
        }

        async Task IProcedimientoAlmacenadoBusiness.ExecuteStoredProc(string storedProcName)
        {
            try
            {
                await this._repository.ExecuteStoredProc(storedProcName);
            }
            catch (Exception ex)
            {
                throw new PopsyException(ex.Message, ErrorSource.Proceso);
            }
        }

        async Task<int> IProcedimientoAlmacenadoBusiness.ProcedimientoSeguimientoPDV()
        {
            try
            {
                return await this._repository.ProcedimientoSeguimientoPDV();
            }
            catch (Exception ex)
            {
                throw new PopsyException(ex.Message, ErrorSource.Proceso);
            }
        }

        async Task<int> IProcedimientoAlmacenadoBusiness.ProcedimientoEliminarPedidos(int año, int mes, int dia)
        {
            try
            {
                return await this._repository.ProcedimientoEliminarPedidos(año, mes, dia);
            }
            catch (Exception ex)
            {
                throw new PopsyException(ex.Message, ErrorSource.Proceso);
            }
        }

        async Task<int> IProcedimientoAlmacenadoBusiness.ProcedimientoEliminarProductosTransaccionales()
        {
            try
            {
                return await this._repository.ProcedimientoEliminarProductosTransaccionales();
            }
            catch (Exception ex)
            {
                throw new PopsyException(ex.Message, ErrorSource.Proceso);
            }
        }
    }
}
