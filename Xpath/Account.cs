using System;
using System.Collections.Generic;
using System.Text;

namespace myiveco_selenium.Xpath
{
    public class Account
    {
        private String password;
        private String email;
        

        public Account (String email, String password)
        {
            this.email = email;
            this.password = password;
        }

        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}
