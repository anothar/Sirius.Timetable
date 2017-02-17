using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Timetable.Core.Services
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void RegisterService<T>(T instance)
        {
            _services[typeof(T)] = instance;
        }

        public static T GetService<T>()
        {
            return (T)_services[typeof(T)];
        }
    }
}
