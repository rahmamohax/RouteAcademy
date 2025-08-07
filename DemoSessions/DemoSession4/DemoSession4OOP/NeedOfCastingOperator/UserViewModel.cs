using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession4OOP.NeedOfCastingOperator
{
    //View : Html 
    internal class UserViewModel
    {
        public string? FName { get; set; } 
        public string? LName { get; set; } 
        public string? Email { get; set; }    
        public string? Password { get; set; }  

        public static explicit operator UserViewModel(User user)
        {
            string[]? names=user.FullName?.Split(' ');
            return new UserViewModel()
            {
                FName = names?.Length > 0 ? names[0] : string.Empty,
                LName = names?.Length > 1 ? names[1] : string.Empty,
                Email = user?.Email ?? string.Empty,
                Password = user?.Password ?? string.Empty,
            };
        }

        public override string ToString()
        {
            return $" FName : {FName} , Lname : {LName} , Email : {Email } , Password : {Password}";
        }
    }
}
