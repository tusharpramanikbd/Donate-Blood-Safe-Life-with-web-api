
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeEntity
{
    public class Admin : Entity
    {
       

        [Required(ErrorMessage ="User Name Is Required. "),MaxLength(50)]
        public string userName { get; set; }

     

        [Required(ErrorMessage = "Password Is Required. "), MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}