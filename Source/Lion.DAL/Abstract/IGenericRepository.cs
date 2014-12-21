using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.DAL.Abstract
{
    public interface IGenericRepository<LBEntity>:IDisposable where LBEntity:class 
    {
       IQueryable<LBEntity> GetAll();

       IQueryable<LBEntity> FindBy(Func<LBEntity, bool> delegateMethod);

       bool Add(LBEntity entity);

       bool Delete(LBEntity entity);

       bool Save(LBEntity entity);

    }
}
