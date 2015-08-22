using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Data.Contracts;
using Transversal.Entities.DTO.DTO;

namespace Backend.Data.Repository
{
    public class PersonRepository: IPersonRepository
    {
        /// <summary>
        /// AT: Implementacion explícita de la interfaz. 
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public PersonDto GetPersonByLastName(string lastName)
        {
            var resultObject = default(PersonDto);

            if (!string.IsNullOrEmpty(lastName))
            {
                var auxAllRecords = GetAllPersons();

                //if(!auxAllRecords.Equals(default(object)))
                if (!auxAllRecords.Equals(default(List<PersonDto>)))
                {
                    //if (!auxAllRecords.Count.Equals(default(int)))
                    //{
                    //    //algo
                    //    if (!auxAllRecords.Count.Equals(0))
                    //    {
                            
                    //    }
                    //}
                    if (auxAllRecords.Any())
                    {
                        foreach (var item in auxAllRecords)
                        {
                            //AT: Se utiliza el método de cla clase String, se compara además ignorando
                            //case y valores relativos a la cultura. 
                            if (string.Equals(lastName, item.LastName, 
                                StringComparison.InvariantCultureIgnoreCase))
                            {
                                resultObject = item;
                                break;
                            }
                        }

                    }
                }
            }

            return resultObject;
        }

        /// <summary>
        /// AT: Implementacion implicita. 
        /// </summary>
        /// <param name="numeric"></param>
        /// <returns></returns>
        public PersonDto GetPersonByRutNumeric(int numeric)
        {
            var resultObject = default(PersonDto);

            //AT: Se comprueba de manera eficiente que el valor parametrizado
            //sea distinto del valor por defecto del primitivo int32
            if (!numeric.Equals(default(int)))
            {
                var auxAllRecords = GetAllPersons();

                if (!auxAllRecords.Equals(default(List<PersonDto>)))
                {
                    //ATR: Iteramos sobre la coleccion para encontrar el objetoc on el 
                    //parametro especificado, se puede hacer con Linq. 
                    foreach (var item in auxAllRecords)
                    {
                        if (item.RutNumeric.Equals(numeric))
                        {
                            resultObject = item;
                            break;
                        }
                    }

                    //AT: Tambien, se puede haber abordado la solución así:
                    //foreach (var item in auxAllRecords.Where(item =>
                    //item.RutNumeric.Equals(numeric)))
                    //{
                    //    resultObject = item;
                    //    break;
                    //}

                }

            }
            return resultObject;

        }

        public List<PersonDto> GetAllPersons()
        {
            var allRecords = default(List<PersonDto>);

            //ATR: Creando nuevas instancias del objeto DTO PersonDto. 
            //Se pretende simular la recepción de éstos datos desde alguna fuente de datos. 


            //ATR: Otras formas de inicializar objetos e instanciar.
            //var objExample = new PersonDto();
            //PersonDto objExample2 = new PersonDto();  
            //objExample2.LastName = string.Empty;

            //List<PersonDto> objNadaQueVer = new List<PersonDto>();
            //List<PersonDto> resultCollection = new List<PersonDto>();

            //foreach (var item in objNadaQueVer.Where(x=> !object.ReferenceEquals(x, null)))
            //{
            //    resultCollection.Add(item);
            //}


            var objPerson1 = new PersonDto()
            {
                LastName = "testLastname1",
                Name = "name1",
                RutDiv = "K",
                RutNumeric = 12345789
            };

            var objPerson2 = new PersonDto()
            {
                LastName = "testLastname2",
                Name = "name2",
                RutDiv = "Y",
                RutNumeric = 987654321
            };

            var objPerson3 = new PersonDto()
            {
                LastName = "testLastname3",
                Name = "name3",
                RutDiv = "Z",
                RutNumeric = 222555444
            };

            //AT: Recien, en este punto se genera una instancia en el Heap. 
            //Se utiliza un inicializado de colecciones.- 
            allRecords = new List<PersonDto>
                () { objPerson1, objPerson2, objPerson3 };

            //var algo = new List<PersonDto>();
            //algo.Add(objPerson1);

            return allRecords;

        }


    }
}
