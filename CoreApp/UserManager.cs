using DataAccess.CRUD;
using Entities_DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp
{

    // aca vamos a manejar la logica del negocio
    public class UserManager
    {
        public List<User> RetrieveAllUsers()
        {
            var uCrud = new UserCrudFactory();
           
            return uCrud.RetrieveAll<User>();
        }
        public void Create(User u)
        {
            var uCrud = new UserCrudFactory();

            if (HasEmptyFields(u))
            {
                throw new Exception("Todos los campos son obligatorios");
            }

            if (!IsBirthDateValid(u))
            {
                throw new Exception("La fecha de nacimiento no puede ser futura");
            }

            if (!IsOver18(u))
            {
                throw new Exception("El usuario debe ser mayor de edad");
            }

            if (!IsValidStatus(u))
            {
                throw new Exception("El estado debe ser Activo o Inactivo");
            }

            if (EmailExists(u.Email))
            {
                throw new Exception("El correo ya se encuentra registrado");
            }

            if (UserCodeExists(u.UserCode))
            {
                throw new Exception("El código de usuario ya existe");
            }
            if (!IsValidEmail(u.Email))
            {
                throw new Exception("El correo no tiene un formato válido");
            }
            if (!IsValidPhone(u))
            {
                throw new Exception("El teléfono debe tener al menos 8 dígitos");
            }
            uCrud.Create(u);
        }

        public void Update(User u) { 
        
            var uCrud = new UserCrudFactory();
            uCrud.Update(u);
        }

        public void Delete(User u)
        {
            var uCrud = new UserCrudFactory();
            uCrud.Delete(u);
        }


        //validaciones
        private bool IsOver18(User  user)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.DateBirth.Year;

            if(user.DateBirth>currentDate.AddYears(-age).Date)
            {
                age--;
            }
            return age >= 18;
        }

        private bool HasEmptyFields (User user)
        {
          return string.IsNullOrWhiteSpace(user.UserCode) ||
          string.IsNullOrWhiteSpace(user.Name) ||
          string.IsNullOrWhiteSpace(user.Email) ||
          string.IsNullOrWhiteSpace(user.Password) ||
          string.IsNullOrWhiteSpace(user.Status)||
          user.PhoneNumber <=0;
        }

        private bool IsValidStatus(User user)
        {
            return user.Status == "AC" ||
                   user.Status == "IN";
        }
        private bool IsBirthDateValid(User user)
        {
            return user.DateBirth <= DateTime.Now;
        }
        private bool EmailExists(string email)
        {
            var uCrud = new UserCrudFactory();

            return uCrud.RetrieveByEmail(email.Trim().ToLower()) != null; 
        }
        private bool UserCodeExists(string userCode)
        {
            var uCrud = new UserCrudFactory();

            return uCrud.RetrieveByUserCode(userCode) != null;
        }

        private bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email)
                && email.Contains("@")
                && email.Contains(".");
        }
        private bool IsValidPhone(User user)
        {
            return user.PhoneNumber >= 10000000; // mínimo 8 dígitos
        }
    }
}
