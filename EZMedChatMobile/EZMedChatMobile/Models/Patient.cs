using System;
using System.Collections.Generic;
using System.Text;

namespace EZMedChatMobile.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        { get => FirstName + " " + LastName;
            set { } 
        }
    }
}
