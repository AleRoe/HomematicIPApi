using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AleRoe.HomematicIpApi.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetTypesWithInterface<TInterface>(this Assembly assembly)
            where TInterface : class
        {
            var iType = typeof(TInterface);
            var types = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(iType));
            
            return types;
        }

        public static IEnumerable<Type> GetTypesWithInterface<TInterface>(this Assembly[] assemblies)
            where TInterface : class
        {
            return assemblies.SelectMany(a => a.GetTypesWithInterface<TInterface>());
        }

        public static IEnumerable<Type> GetTypesWithInterface<TInterface>()
            where TInterface : class
        {
            return AppDomain.CurrentDomain.GetAssemblies().GetTypesWithInterface<TInterface>();
        }
    }
}
