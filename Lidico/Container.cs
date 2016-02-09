using System;
using System.Collections.Generic;
using System.Linq;

namespace Lidico
{
    public class Container : IContainer
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
                throw new NotRegisteredException($"Type is not in the container, Type: {typeToResolve}.");
            }

            return GetInstance(resolvedType);
        }

        private object GetInstance(Type resolvedType)
        {
            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParameters = firstConstructor.GetParameters();
            if (!constructorParameters.Any()) return Activator.CreateInstance(resolvedType);

            IList<object> parameters = constructorParameters.Select(parameterToResolve => Resolve(parameterToResolve.ParameterType)).ToList();

            return firstConstructor.Invoke(parameters.ToArray());
        }

        public void Register<T1, T2>()
        {
            if (!typeof(T1).IsAssignableFrom(typeof(T2)))
            {
                throw new UnassignableException($"The child type is not assignable from the parent type: parent {typeof(T1).Name} -> child {typeof(T2).Name}.");
            }
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