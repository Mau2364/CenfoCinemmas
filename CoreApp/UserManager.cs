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
            //validamos si el user es mayor de edad
            if (IsOver18(u))
            {
                uCrud.Create(u);
            }
            else
            {
                throw new Exception("El usuario no comple con la edad minima para el registro");
            }
            if (HasEmptyFields(u))
            {
                throw new Exception("Se deben completar todos los campos ");
            }
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
    }
}
