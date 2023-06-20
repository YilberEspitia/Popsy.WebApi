namespace Popsy.Objects
{
    public record ResponseSAP<T>
        where T : class
    {
        public ResultsSAP<T> d { get; set; }
    }
}