using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MK6.AutomatedTesting.Runner
{
    public static class InstanceCreator
    {
        public static T CreateInstanceOf<T>(string fullTypeName, params object[] args) where T : class
        {
            var scriptNameComponents = fullTypeName.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var typeName = scriptNameComponents[0].Trim();
            var assemblyName = scriptNameComponents[1].Trim() + ".dll";
            
            return GetInstance<T>(
                GetAssembly(assemblyName), 
                typeName,
                args);
        }

        private static Assembly GetAssembly(string assemblyName)
        {
            var assemblyPath = Directory.GetFiles(
                Directory.GetCurrentDirectory(), 
                assemblyName, 
                SearchOption.AllDirectories).FirstOrDefault();

            if (string.IsNullOrEmpty(assemblyPath))
            {
                throw new ApplicationException(
                    string.Format("Unable to find the assembly named {0}. Paths checked: {1}", assemblyName, assemblyPath));
            }

            return Assembly.LoadFrom(assemblyPath);
        }

        private static T GetInstance<T>(Assembly assembly, string typeName, params object[] args) where T : class
        {
            var type = assembly.GetType(typeName);

            if (type == null)
            {
                throw new ApplicationException(string.Format("Unable to find the type specified: {0}", typeName));
            }

            var instance = Activator.CreateInstance(type, args);

            if (instance == null)
            {
                throw new ApplicationException(string.Format("Type name specified, {0}, does not inherit from {1}", typeName, typeof(T).Name));
            }

            return instance as T;
        }
    }
}
