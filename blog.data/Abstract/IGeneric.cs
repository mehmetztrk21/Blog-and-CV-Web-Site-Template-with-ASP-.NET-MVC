using System.Collections.Generic;

namespace shopapp.data.Abstract
{
    public interface IGeneric<TEntity>
    {
        TEntity GetById(int id);

        void add(TEntity sertfika);


        void delete(int id);


        List<TEntity> GetAll();


        void update(TEntity sertfika);



         
    }
}