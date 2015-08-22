using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data.Contracts;

namespace Backend.Business.Injector
{
    /// <summary>
    /// AT: Clase que implementa el patrón IOC / Inyeccion de dependencias. 
    /// </summary>
    public sealed class InjectorIoC
    {
        private IPersonRepository injectedInstance = null;


        public InjectorIoC(IPersonRepository injectedInstance)
        {
            if (!object.ReferenceEquals(injectedInstance, default(object)))
            {
                this.injectedInstance = injectedInstance;
            }
            
        }

        public IPersonRepository GetInjectedInstanceOfPersonRepository()
        {
            return injectedInstance;
        }
    }
}
