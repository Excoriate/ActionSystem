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

        /// <summary>
        /// AT: Obtiene una persona por su apellido. 
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public PersonDto GetPersonByLastName(string lastName)
        {
            return GetRepositoryInstance().GetPersonByLastName(lastName);
        }

        /// <summary>
        /// AT: Agrega una nueva instancia de Persona Dto. 
        /// </summary>
        /// <param name="objPersonDto"></param>
        /// <returns></returns>
        public List<PersonDto> InsertNewPerson(PersonDto objPersonDto)
        {
            //AT: Acá se debería de modificar, considerando que siempre trae la coleccion
            //seteada en "duro" desde Persistencia.
            return GetRepositoryInstance().AddNewPerson(objPersonDto);
        }

        /// <summary>
        /// AT: Actualiza una entidad existente de la coleccion de Personas.
        /// </summary>
        /// <param name="objPersonDto"></param>
        /// <returns></returns>
        public List<PersonDto> UpdatePerson(PersonDto objDto , List<PersonDto> currentListOfPerson)
        {
            var resultUpdateCollection = default(List<PersonDto>);
            var auxCollection          = default(List<PersonDto>);

            if (!object.ReferenceEquals(objDto, null))
            {
                auxCollection = object.ReferenceEquals(currentListOfPerson, null) ?
                    GetRepositoryInstance().GetAllPersons() : currentListOfPerson;

                foreach (var item in auxCollection)
                {  
                    if (string.Equals(item.RutDiv, objDto.RutDiv, StringComparison.InvariantCultureIgnoreCase) &&
                        (item.RutNumeric.Equals(objDto.RutNumeric)))
                    {
                        auxCollection.Remove(item);
                        auxCollection.Add(objDto);
                        break; 
                    }
                }   
            }

            return auxCollection;
        }

        /// <summary>
        /// AT: Remueve una instancia de PersonDto desde memoria. Retorna la colección
        /// actualizada. 
        /// </summary>
        /// <param name="objPersonDto"></param>
        /// <returns></returns>
        public List<PersonDto> RemovePerson(PersonDto objPersonDto)
        {
            return GetRepositoryInstance().DeletePerson(objPersonDto);

        }



}
}
