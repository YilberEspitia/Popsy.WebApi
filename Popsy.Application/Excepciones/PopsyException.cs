using Popsy.Enums;

namespace Popsy
{
    public class PopsyException : Exception
    {
        public ErrorType errorType { get; set; }

        public PopsyException(ErrorType errorType)
        {
            this.errorType = errorType;
        }
    }
}
