using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Fuse8.ViewModels
{
    public class EmailSettings
    {
        public string Host { get; set; } = "smtp.";
        public int Port { get; set; } = 587;
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Messange { get; set; }
    }
}