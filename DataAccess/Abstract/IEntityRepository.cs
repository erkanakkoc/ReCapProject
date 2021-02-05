using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic Constraint - Generic Kısıt
    //class : Referans Tip
    //IEntity : IEntity olabilir ya da IEntity implemente eden bir nesne olabilir.
    //new() : new'lenebilir olmalıdır. Bu sayede IEntity'yi kullanmayı engelliyoruz.
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>>filter=null);

        //Tek bir dosya getirmek için aşağıdakini yazmak gerekiyor
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
