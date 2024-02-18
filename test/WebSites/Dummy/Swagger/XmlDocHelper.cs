using System.IO;
using System.Reflection;

namespace Dummy.Swagger
{
    /// <summary>
    /// Extensions methods for xml doc files
    /// </summary>
    public static class XmlDocHelper
    {
        /// <summary>
        /// Find the XML documentation files for a given assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetXmlDocFile(Assembly assembly)
        {
            return $"{Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), assembly.GetName().Name)}.xml";
        }
    }
}
