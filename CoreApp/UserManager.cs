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
    }
}
