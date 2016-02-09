using System;

namespace Lidico
{
    public interface IContainer
    {
        T Resolve<T>();

        object Resolve(Type typeToResolve);

        void Register<T1, T2>();
    }
}