using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Fuse8.ViewModels
{
    public class EmailSettings
    {
        [Required(ErrorMessage = "Enter value")]
        [RegularExpression(@"^smtp.[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Error host")]
        public string Host { get; set; } = "smtp.";

        [Required(ErrorMessage = "Enter value")]
        public int Port { get; set; } = 587;

        [Required(ErrorMessage = "Enter value")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Error address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter value")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter value")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Error address")]
        public string Address { get; set; }

        public string Subject { get; set; }

        public string Messange { get; set; }
    }
}