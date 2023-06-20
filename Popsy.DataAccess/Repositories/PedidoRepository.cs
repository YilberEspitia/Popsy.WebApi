using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Enums;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    /// <summary>
    /// Implementa los metodos relacionados con la entidad <see cref="TblPedidoEntity"/>.
    /// </summary>
    public class PedidoRepository : IPedidoRepository
    {
        /// <summary>
        /// Contexto.
        /// </summary>
        private readonly PopsyDbContext _context;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context">Contexto.</param>
        public PedidoRepository(PopsyDbContext context)
        {
            _context = context;
        }


        async Task<bool> IPedidoRepository.ExisteAsync(Guid pedido_id)
            => await _context.Pedidos.Where(x => x.pedido_id.Equals(pedido_id)).AnyAsync();

        async Task<bool> IPedidoRepository.UpdateEstadoAsync(Guid pedido_id, SAPEstado nuevo_estado)
        {
            {
                bool response = false;
                if (await _context.Pedidos.Where(x => x.pedido_id.Equals(pedido_id)).FirstOrDefaultAsync() is TblPedidoEntity pedido)
                {
                    if (!pedido.estado.Equals(nuevo_estado))
                    {
                        pedido.estado = nuevo_estado;
                        await _context.SaveChangesAsync();
                        response = true;
                    }
                }
                return response;
            }
        }
    }
}