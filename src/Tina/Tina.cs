namespace Tina
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Tina
    {
        private static IDictionary<string, Type> templateMappings = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        public static void Register<TTemplate>(string extension)
        {
            if (string.IsNullOrEmpty(extension)) return;
            var ext = extension.StartsWith(".") ? extension : "." + extension;
            templateMappings[ext] = typeof(TTemplate);
        }

        public static bool IsRegistered(string extension)
        {
            if (string.IsNullOrEmpty(extension)) return false;
            var ext = extension.StartsWith(".") ? extension : "." + extension;
            return templateMappings.ContainsKey(ext);
        }

        public static Type GetTemplateType(string fileOrExtension)
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
            return templateMappings[ext];
        }
    }
}
