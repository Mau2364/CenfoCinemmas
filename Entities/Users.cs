using System;
using System.Collections.Generic;
using System.Text;

namespace Entities-DTOS
{
    public class Users : BaseDTO //para que pueda circular a traves de toda la arquitectura
{
    public string UserCode { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
   
    public string DateBirth { get; set; }
    public string Status { get; set; }
    public int PhoneNumber { get; set; }    
}
}
