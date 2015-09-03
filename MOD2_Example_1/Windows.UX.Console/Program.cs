
using System.Collections.Generic; 
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.UX.Console.Application.ConfigManager;
using Backend.Business.RRHH.Module.PersonManager;
using Transversal.Entities.DTO.DTO;

namespace Windows.UX.Console
{
    class Program
    {
        private static List<PersonDto> lstOfPersonOnMemory = null; 

        static void Main(string[] args)
        {
            //AT: SHow welcome message and main menu. 
            ShowWelcomeMessage();

            //AT: Display main menu, check previously custom input types! (prevent FormatException). 
            ShowCustomMenu();
            //Regex.IsMatch(tuCadena, @"^[\p{L}]+$");


        }
        
    

        static void ShowCustomMenu()
        {
            var startValue = 0;

            System.Console.WriteLine("---------MENU---------");
            System.Console.WriteLine();
            System.Console.WriteLine("1- Listar todos los usuarios");
            System.Console.WriteLine("2- Filtrar por Rut Numerico");
            System.Console.WriteLine("3- Filtrar por Apellido");
            System.Console.WriteLine("4- Insertar un nuevo Usuario");
            System.Console.WriteLine("5- Actualizar un usuario existente");
            System.Console.WriteLine("6- Eliminar un usuario existente");
            System.Console.WriteLine("7- Exit.");

            if (int.TryParse(System.Console.ReadLine(), out startValue))
            {
                if (startValue < 1 || startValue > 7)
                {
                    System.Console.WriteLine("Funciones no reconocidas.");
                }
                else
                {
                    FunctionMenu(startValue);   
                }
                
            }
            else
            {
                System.Console.WriteLine("Error, valor ingresado invalido.  Intentelo nuevamente");
                System.Console.ReadKey(); 
            }     
        }

        static void FunctionMenu(int menuOptions)
        {
            switch (menuOptions)
            {
                case 1:
                    ShowPersonsFromBusienss();
                    System.Console.WriteLine("-------------------------");
                    ShowCustomMenu();
                    break;

                case 2:
                    FilterByRutNumeric();
                    System.Console.WriteLine("-------------------------");
                    ShowCustomMenu();
                    break;

                case 3:
                    FilterByLastName();
                    System.Console.WriteLine("-------------------------");
                    ShowCustomMenu();
                    break;

                case 4:
                    InsertNewPerson();
                    System.Console.WriteLine("-------------------------");
                    ShowCustomMenu();
                    break;

                case 5:
                    UpdatePerson();
                    System.Console.WriteLine("-------------------------");
                    ShowCustomMenu();
                    break;

                case 6:
                    RemovePerson();
                    System.Console.WriteLine("-------------------------");
                    ShowCustomMenu();
                    break;

                case 7:
                    break;

                default:  
                    System.Console.WriteLine("Funcion no reconocida. ");
                    break;

            }
            
        }

        static void RemovePerson()
        {
            System.Console.WriteLine("Ingrese Rut Numerico de la Persona: ");
            var rutNumericOf = System.Console.ReadLine();
            System.Console.WriteLine("Ingrese Rut Dígito Verificador de la Persona: ");
            var rutDvOf = System.Console.ReadLine();
            System.Console.WriteLine("presione [ENTER]");
            System.Console.ReadKey();

            var resultRutNumericOf = default(int);

            if (!int.TryParse(rutNumericOf, out resultRutNumericOf))
            {
                System.Console.WriteLine("El valor para el campo RutNumeric debe ser un número entero válido.");
                System.Console.ReadKey();
            }
            else
            {
                var personManager = new PersonManager();
                var resultListWithNewPerson = personManager.RemovePerson(new PersonDto()
                {   
                    RutNumeric = resultRutNumericOf,
                    RutDiv = rutDvOf
                });

                if (!object.ReferenceEquals(resultListWithNewPerson, null))
                {
                    if (resultListWithNewPerson.Any())
                    {
                        lstOfPersonOnMemory = resultListWithNewPerson;

                        System.Console.WriteLine("1- Lista actualizada. Persona eliminada");
                        System.Console.WriteLine("\n");
                        ShowPersonsFromBusienss();
                        System.Console.ReadKey();

                    }
                }

            }

        }

        static void InsertNewPerson()
        {
            System.Console.WriteLine("Ingrese Nombre de la Persona: ");
            var nameOf       = System.Console.ReadLine();
            System.Console.WriteLine("Ingrese Apellido de la Persona: ");
            var lastNameOf   = System.Console.ReadLine();
            System.Console.WriteLine("Ingrese Rut Numerico de la Persona: ");
            var rutNumericOf = System.Console.ReadLine();
            System.Console.WriteLine("Ingrese Rut Dígito Verificador de la Persona: ");
            var rutDvOf      = System.Console.ReadLine();
            System.Console.WriteLine("presione [ENTER]");
            System.Console.ReadKey();

            int resultRutNumericOf = default(int);
            if (!int.TryParse(rutNumericOf, out resultRutNumericOf))
            {
                System.Console.WriteLine("El valor para el campo RutNumeric debe ser un número entero válido.");
                System.Console.ReadKey();
            }
            else
            {
                var personManager = new PersonManager();
                var resultListWithNewPerson = personManager.InsertNewPerson(new PersonDto()
                {
                    Name       = nameOf,
                    LastName   = lastNameOf,
                    RutNumeric = resultRutNumericOf,
                    RutDiv     = rutDvOf
                }, lstOfPersonOnMemory);

                if (!object.ReferenceEquals(resultListWithNewPerson, null))
                {
                    if (resultListWithNewPerson.Any())
                    {
                        System.Console.WriteLine("1- Lista actualizada. Nueva persona ingresada");
                        System.Console.WriteLine("\n");

                        lstOfPersonOnMemory = resultListWithNewPerson;
                        ShowPersonsFromBusienss();
                    }
                }

            }

        }

        static void UpdatePerson()
        {   
            var lastNameOf = System.Console.ReadLine();
            System.Console.WriteLine("Ingrese Rut Numerico de la Persona que desea actualizar datos: ");
            var rutNumericOf = System.Console.ReadLine(); 
            System.Console.WriteLine("presione [ENTER]");
            System.Console.ReadKey();

            int resultRutNumericOf = default(int);
            if (!int.TryParse(rutNumericOf, out resultRutNumericOf))
            {
                System.Console.WriteLine("El valor para el campo RutNumeric debe ser un número entero válido.");
                System.Console.ReadKey();
            }
            else
            {
                //at: Acá buscamos a la persona 
                var personManager       = new PersonManager();
                var findedPerson        = personManager.GetPersonByNumeric(resultRutNumericOf);
                var updateListOfPersons = default(List<PersonDto>);

                if (!object.ReferenceEquals(findedPerson, null))
                {
                    System.Console.WriteLine("Ingrese nuevo data para: [Nombre (antes: {0})]", findedPerson.Name);
                    findedPerson.Name = System.Console.ReadLine();
                    System.Console.ReadKey();

                    System.Console.WriteLine("Ingrese nuevo data para: [Apellido (antes: {0})]", findedPerson.LastName);
                    findedPerson.LastName = System.Console.ReadLine();
                    System.Console.ReadKey();
                    System.Console.WriteLine("[ENTER] para actualizar");
                    System.Console.ReadKey();

                    updateListOfPersons = personManager.UpdatePerson(findedPerson, lstOfPersonOnMemory);
                }
                 

                if (!object.ReferenceEquals(updateListOfPersons, null))
                {
                    if (updateListOfPersons.Any())
                    {
                        System.Console.WriteLine("1- Lista actualizada. Nueva persona ingresada");
                        System.Console.WriteLine("\n");

                        lstOfPersonOnMemory = updateListOfPersons;
                        ShowPersonsFromBusienss();
                    }
                }

            }

        }

        static void FilterByRutNumeric()
        {
            //AT: Lectura desde pantalla. 
            System.Console.WriteLine("Ingrese Rut Numerico: ");
            var screenArgument = System.Console.ReadLine();

            if (!string.IsNullOrEmpty(screenArgument))
            {
                var flagIsNumeric = default(int);
                //var convertedInt = int.Parse(screenArgument);

                if (int.TryParse(screenArgument, out flagIsNumeric))
                {
                    var instanceOfBusiness = new PersonManager();
                    var listOfPersons = instanceOfBusiness.GetPersonByNumeric(flagIsNumeric);

                    if (object.ReferenceEquals(listOfPersons, null))
                    {
                        System.Console.WriteLine("No se han encontrado coincidencias");
                        System.Console.ReadKey();
                    }
                    else
                    {
                        System.Console.WriteLine("Resultado de busqueda: \n");
                        System.Console.WriteLine(string.Format("Persona encontrada: {0} ** {1}", 
                            listOfPersons.Name, listOfPersons.LastName));
                        System.Console.ReadKey();
                    }


                }
                else
                {
                    System.Console.WriteLine("Valor invalido. Presiona una tecla para intentar nuevamente");                    
                    System.Console.ReadKey(); 
                }

            }

        }

        static void FilterByLastName()
        {
            var personManagerInstance = new PersonManager();
            var lstOfPersons = personManagerInstance.GetAllPersons();
            
            var findedPerson = default(PersonDto);

            if(!object.ReferenceEquals(lstOfPersons, null))
            {
                if (lstOfPersons.Any())
                {
                    System.Console.WriteLine("Ingrese apellido para realizar la búsqueda:");
                    var lastNameByConsole = System.Console.ReadLine();

                    if (string.IsNullOrEmpty(lastNameByConsole))
                    {
                        System.Console.WriteLine("Valor vacio, intentelo nuevamente");
                    }
                    else
                    {
                        findedPerson = personManagerInstance.GetPersonByLastName(lastNameByConsole, lstOfPersonOnMemory); 
                    }
                }
            }

            if (!object.ReferenceEquals(findedPerson, null))
            {
                System.Console.WriteLine("Resultado búsqueda: \n");
                System.Console.WriteLine("Persona: {0} \t {1} \t Rut : {2}", findedPerson.Name, 
                    findedPerson.LastName, findedPerson.RutNumeric);
                System.Console.ReadKey();
            }
            else
            {
                System.Console.WriteLine("No se han encontrado resultados");
                System.Console.ReadKey();
            }

        }

        static void ShowPersonsFromBusienss()
        {   

            if (object.ReferenceEquals(lstOfPersonOnMemory, null))
            {
                var businessInstance         = new PersonManager();
                lstOfPersonOnMemory          = businessInstance.GetAllPersons(); 
            }

            if (!object.ReferenceEquals(lstOfPersonOnMemory, null))
            {
                if (lstOfPersonOnMemory.Any())
                {
                    System.Console.WriteLine("1- Nomina de personas desde BE. ");
                    System.Console.WriteLine("\n");

                    foreach (var item in lstOfPersonOnMemory)
                    {
                        System.Console.WriteLine(string.Format("Persona: {0} ** {1} Rut Numerico: {2}\t Rut Dv: {3}",
                            item.Name, item.LastName, item.RutNumeric, item.RutDiv));
                    }
                    System.Console.ReadKey();
                }
            }  
        }
          
        static void ShowWelcomeMessage()
        {
            //AT: Instancia de ConfigReader. 
            var configInstance = new ConfigReader();
            var myName = configInstance.GetNameFromConfigFile();

            if (string.IsNullOrEmpty(myName))
            {
                System.Console.WriteLine("No se ha encontrado");
                System.Console.ReadKey();
            }
            else
            {
                //AT: Concatenando cadenas de forma eficiente, también se puede
                //realizar con string.concat.  Jamás concatenación via string1+string2, etc. 
                string welcomeMessage = string.Format("Bienvenido: {0}", myName);


                System.Console.WriteLine(welcomeMessage);
                System.Console.WriteLine("Presione cualquier tecla para iniciar el Menu. ");
                System.Console.WriteLine("*********************************");
                System.Console.ReadKey();

            }
        }
    }
}
