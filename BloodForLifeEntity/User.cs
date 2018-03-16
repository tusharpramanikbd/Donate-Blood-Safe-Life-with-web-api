
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodForLifeEntity
{
    public class User: Entity
    {
       

        [Required(ErrorMessage ="User Name Is Required. "),MaxLength(50)]
        public string userName { get; set; }

        [Required(ErrorMessage = "Full Name Is Required. "), MaxLength(50)]
        public string fullName { get; set; }

       
        public string  gender { get; set; }

        [Required(ErrorMessage = "Password Is Required. "), MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

       
        public int age { get; set; }


        [Required(ErrorMessage = "Weight Is Required. ")]
        public string weight { get; set; }

        public string bloodGroup { get; set; }

        [Required(ErrorMessage = "Mobile Number Is Required. "), MaxLength(13)]
        public string mobileNumber { get; set; }

        [Required(ErrorMessage ="Email Address Is Required")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = " Address Is Required"), MaxLength(100)]
        public string address { get; set; }

        public string division { get; set; }
        public string available { get; set; }
    }
}