using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Utils.Reflection
{
    public class Reflectionner
    {
        public Dictionary<String, Object> ReadClass<T>()
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();
            PropertyInfo[] props = typeof(T).GetProperties();
            T item = (T)Activator.CreateInstance(typeof(T));
            foreach (var prop in props)
            {
                result.Add(prop.Name, prop.GetValue(item, null));
            }

            return result;
        }

        public Dictionary<String, Object> ReadList<T>(List<T> list)
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();
            var props = typeof(T).GetProperties();
            foreach (T item in list)
            {
                foreach (var prop in props)
                {
                    result.Add(prop.Name, prop.GetValue(item));
                }
            }

            return result;
        }

        public Dictionary<String, Object> ReadList<T>(T list) where T : System.Collections.IList
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();
            foreach (Object item in list)
            {
                var props = item.GetType().GetProperties();
                foreach (var prop in props)
                {
                    result.Add(prop.Name, prop.GetValue(item, null));
                }
            }

            return result;
        }
    }
}
