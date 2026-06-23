using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTOS
{ 
    public class User : BaseDTO //para que pueda circular a traves de toda la arquitectura
{
    public string UserCode { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } 
   
    public DateTime DateBirth { get; set; }
    public string Status { get; set; }
    public int PhoneNumber { get; set; }    
}
}
