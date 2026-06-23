using DataAccess.DAO;
using Entities_DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{

    //padre de los CRUDS de la arquitectura
    // define el contraro que debe implementar todo CRUD
    public abstract class CrudFactory
    {

        protected SqlDao sqlDao;
        //DEFINIR los metodos que hacen parte del contraro

        // CREATE

        // RETRIEVE

        //UPDATE

        //DELETE

        public abstract void Create(BaseDTO baseDTO);

        public abstract void Update (BaseDTO baseDTO);

        public abstract void Delete (BaseDTO baseDTO);

        public abstract T RetrieveById <T>(int id);

        public abstract List<T> RetrieveAll<T>();

            
    }
}


