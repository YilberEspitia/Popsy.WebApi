using AutoMapper;

namespace Popsy.Business
{
    /// <summary>
    /// Clase de aplicación base.
    /// </summary>
    public class ApplicationBase
    {
        /// <summary>
        /// Mapper.
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mapper">Mapper.</param>
        public ApplicationBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
