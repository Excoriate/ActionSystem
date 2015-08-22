using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Business.Injector;
using Backend.Data.Contracts;
using Backend.Data.Repository;
using Transversal.Entities.DTO.DTO;

namespace Backend.Business.RRHH.Module.PersonManager
{
    /// <summary>
    /// ATR: Sealed, implica que la clase en si está bloqueada para ser heredada. 
    /// Se deniega su extension. 
    /// </summary>
    public sealed class PersonManager
    {
        private  IPersonRepository GetRepositoryInstance()
        {
            //var instanceOf = default(IPersonRepository);
            var instanceIoc = new InjectorIoC(new PersonRepository());
            return instanceIoc.GetInjectedInstanceOfPersonRepository();
        }


        /// <summary>
        /// AT: Instancia inyectada de forma asistida via constructor de la clase.
        /// </summary>
        /// <returns></returns>
        public  List<PersonDto>GetAllPersons()
        {
            return GetRepositoryInstance().GetAllPersons();  
        }

        /// <summary>
        /// AT:  Instancia inyectada de forma asistida via constructor de la clase.
        /// </summary>
        /// <param name="numeric"></param>
        /// <returns></returns>
        public PersonDto GetPersonByNumeric(int numeric)
        {
            return GetRepositoryInstance().GetPersonByRutNumeric(numeric);
        }

    }
}
