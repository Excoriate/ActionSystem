using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Entities.DTO.ValueObjects.Enums;

namespace Transversal.Entities.DTO.Utils
{
    public class BindControls
    {
        /// <summary>
        /// ATR: Cast enum types to concret object type, and pass it to List. 
        /// </summary>
        /// <returns></returns>
        public List<EnumStruct.BasicOperationsEnum> BindBasicOperationsToControl()
        {
            return
                Enum.GetValues(typeof (EnumStruct.BasicOperationsEnum)).
                Cast<EnumStruct.BasicOperationsEnum>().ToList();

        } 




    }
}
