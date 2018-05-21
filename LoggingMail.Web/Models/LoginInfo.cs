using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LoggingMail.Web.Models
{
    public class LoginInfo
    {

        [Required(ErrorMessage = "Username is required.")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}