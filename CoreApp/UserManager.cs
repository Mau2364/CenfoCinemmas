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
    }
}
