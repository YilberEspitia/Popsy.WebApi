using AutoMapper;

namespace Popsy.Business
{
    public class ApplicationBase
    {
        protected readonly IMapper _mapper;

        public ApplicationBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
