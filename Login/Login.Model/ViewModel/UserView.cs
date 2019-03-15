using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Model.ViewModel
{
    public class UserView
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage = "Password  is Required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Password  is Required.")]
        public string LastName { get; set; }
        
        public DateTime BirthDate { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int EntryBy { get; set; }

        [Required(ErrorMessage = "Password  is Required.")]
        public string Password { get; set; }
    }
}
