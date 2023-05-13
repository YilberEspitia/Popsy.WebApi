using AutoMapper;

using Popsy.Entities;
using Popsy.Objects;

namespace Popsy
{
    /// <summary>
    /// Mapeo de entidades a objetos o viceversa.
    /// </summary>
    public class ApplicationAppProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ApplicationAppProfile()
        {
            this.MapProveedorRecepcion();
        }

        public void MapProveedorRecepcion()
        {
            CreateMap<ProveedorRecepcionObject, TblProveedorRecepcionEntity>().ReverseMap();
        }
    }
}
