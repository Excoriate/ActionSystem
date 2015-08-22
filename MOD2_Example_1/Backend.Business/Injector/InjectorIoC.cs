
using Backend.Data.Contracts;

namespace Backend.Business.Injector
{
    /// <summary>
    /// AT: Clase que implementa el patrón IOC / Inyeccion de dependencias. 
    /// </summary>
    public sealed class InjectorIoC
    {
        private IPersonRepository injectedInstance = null;


        /// <summary>
        /// ATR: Constructor sobrecargado, permite parametrizar una instancia
        /// inyectada, sin una clase concreta. 
        /// </summary>
        /// <param name="injectedInstance"></param>
        public InjectorIoC(IPersonRepository injectedInstance)
        {
            if (!object.ReferenceEquals(injectedInstance, default(object)))
            {
                this.injectedInstance = injectedInstance;
            }

        }

        /// <summary>
        /// Constuctor público. 
        /// </summary>
        public InjectorIoC()
        {
            
        }

        public IPersonRepository GetInjectedInstanceOfPersonRepository()
        {
            return injectedInstance;
        }
    }
}
