namespace Tina
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class TemplateProviderAttribute : Attribute
    {
        public TemplateProviderAttribute()
        {

        }

        public TemplateProviderAttribute(string extension)
        {
            Extension = extension;

        }
        public string Extension { get; set; }
    }
}
