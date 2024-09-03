using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Interceptors
{
    public abstract class MethodInterception : MethodInterceptorBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception exception) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSucess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                isSucess = false;
                OnException(invocation, exception);
                throw;
            }
            finally
            {
                if (isSucess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
