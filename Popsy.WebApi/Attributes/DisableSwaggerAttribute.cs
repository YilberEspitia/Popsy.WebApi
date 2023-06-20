namespace Popsy.Attributes
{
    /// <summary>
    /// Atributo que indica que controladores serán ocultados en producción.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DisableSwaggerAttribute : Attribute { }
}
