namespace Tina
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Tina
    {
        private readonly IDictionary<string, Type> templateMappings = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        public void Register<TTemplate>()
        {
            var templateProviderAttributes = typeof(TTemplate).GetCustomAttributes<TemplateProviderAttribute>();

            foreach (var attribute in templateProviderAttributes)
            {
                Register<TTemplate>(attribute.Extension);
            }
        }

        public void Register<TTemplate>(string extension)
        {
            if (string.IsNullOrEmpty(extension)) return;
            var ext = extension.StartsWith(".") ? extension : "." + extension;
            templateMappings[ext] = typeof(TTemplate);
        }

        public bool IsRegistered(string extension)
        {
            if (string.IsNullOrEmpty(extension)) return false;
            var ext = extension.StartsWith(".") ? extension : "." + extension;
            return templateMappings.ContainsKey(ext);
        }

        public Type this[string fileOrExtension]
        {
            get { return GetTemplateType(fileOrExtension); }
        }

        public Type GetTemplateType(string fileOrExtension)
        {
            if (string.IsNullOrEmpty(fileOrExtension)) return null;
            string ext = null;
            try
            {
                ext = Path.GetExtension(fileOrExtension);
            }
            catch (ArgumentException)
            {
            }
            if (string.IsNullOrEmpty(ext))
            {
                ext = fileOrExtension.StartsWith(".") ? fileOrExtension : "." + fileOrExtension;
            }
            Type implementationType = null;
            if (templateMappings.TryGetValue(ext, out implementationType))
            {
                return implementationType;
            }
            return null;
        }
    }
}
