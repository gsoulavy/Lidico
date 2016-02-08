using System;
using System.Collections.Generic;
using System.Linq;

namespace Lidico
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();

        public T Resolve<T>() => (T)Resolve(typeof(T));

        public object Resolve(Type typeToResolve)
        {
            Type resolvedType = null;
            try
            {
                resolvedType = _dependencyMap[typeToResolve];
            }
            catch
            {
                throw new Exception($"Type is not in the container, Type: {typeToResolve}.");
            }

            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();
            if (!constructorParameters.Any()) return Activator.CreateInstance(resolvedType);

            IList<object> parameters = new List<object>();
            foreach (var parameterToResolve in constructorParameters)
            {
                parameters.Add(Resolve(parameterToResolve.ParameterType));
            }

            return firstConstructor.Invoke(parameters.ToArray());
        }

        public void Register<T1, T2>()
        {
            if (_dependencyMap.ContainsKey(typeof(T1)))
            {
                _dependencyMap[typeof(T1)] = typeof(T2);
            }
            else
            {
                _dependencyMap.Add(typeof(T1), typeof(T2));
            }
        }
    }
}