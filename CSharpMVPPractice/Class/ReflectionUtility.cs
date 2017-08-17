using CSharpMVPPractice.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMVPPractice.Class
{
    public class ReflectionUtility : IReflectionUtility
    {
        public IEnumerable<object> GetImplementations(Type type)
        {
            if (type.IsInterface == false)
                throw new NotSupportedException("Only interfaces should be thrown in this method!");

            return from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.GetInterfaces().Contains(type)
                            && t.GetConstructor(Type.EmptyTypes) != null
                    select Activator.CreateInstance(t);
        }
    }
}
