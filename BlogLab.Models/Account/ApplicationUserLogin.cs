using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogLab.Models.Account
{
    public class ApplicationUserLogin
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5,ErrorMessage ="Must be atlease 5 to 10 charecters")]
        [MaxLength(20,ErrorMessage ="Must be atlease 5 to 10 charecters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(10, ErrorMessage = "Must be atlease 10 to 50 charecters")]
        [MaxLength(50, ErrorMessage = "Must be atlease 10 to 500 charecters")]
        public string Password { get; set; }
    }
}
