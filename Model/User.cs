using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace React_Asp.Model

{
    public class User
    {
      
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        
        public string  Email { get; set; }
        [Required]
        public int Phonenumber { get; set; }
        [Required]
        public string Location { get; set; }
        public string Userstatus { get; set; }
        public int Userdonation { get; set; }
     



    }
}
