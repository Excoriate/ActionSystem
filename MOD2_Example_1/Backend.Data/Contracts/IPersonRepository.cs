using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Entities.DTO.DTO;

namespace Backend.Data.Contracts
{
    /// <summary>
    /// ATR: Contrato, interfaz que despliegua métodos no concretos para trabajar la entidad
    /// PersonRepository. 
    /// </summary>
    public interface IPersonRepository
    {
        PersonDto GetPersonByLastName(string lastName);
        PersonDto GetPersonByRutNumeric(int numeric);
        List<PersonDto> GetAllPersons();
        List<PersonDto> AddNewPerson(PersonDto objDto);
        List<PersonDto> UpdateNewPerson(PersonDto objDto);

        List<PersonDto> DeletePerson(PersonDto objDto);


    }
}
