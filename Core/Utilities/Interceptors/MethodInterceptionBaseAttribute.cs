using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        #region Properties
        public int Priority { get; set; }
        #endregion

        #region Virtual Methods
        public virtual void Intercept(IInvocation invocation)
        {
        }
        #endregion
    }
}
