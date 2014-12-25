using Lion.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lion.DAL.Abstract
{
    public abstract class GenericRepository<LBEntity>:IGenericRepository <LBEntity> where LBEntity:class 
    {
        LionBudgetDBContext dbContext;

        DbSet<LBEntity> dbSet;

        bool disposed = false;

        public GenericRepository()
        {
            dbContext = new LionBudgetDBContext();
            dbSet = dbContext.Set<LBEntity>();
        }

        public virtual IQueryable<LBEntity> GetAll()
        {
            return dbSet.AsQueryable();
        }

        public virtual IQueryable<LBEntity> FindBy(Func<LBEntity, bool> delegateMethod)
        {
            return dbSet.Where(delegateMethod).AsQueryable();
        }

        public virtual bool Add(LBEntity entity)
        {
            bool success = false;

            try
            {
                dbSet.Add(entity);
                success = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return success;
        }

        public virtual bool Delete(LBEntity entity)
        {
            bool success = false;
            try
            {
                dbSet.Remove(entity);
                success = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return success;
        }

        public virtual bool Save(LBEntity entity)
        {
            bool success = false;
            try
            {
                dbSet.Attach(entity);
                success = true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return success;
        }

        public void Dispose()
        {
            if(!disposed)
            {
                Dispose(true);

                GC.SuppressFinalize(this);
            }
        }

        private void Dispose(bool disposing)
        {
            if(!this.disposed && disposing)
            {
                dbContext.Dispose();
                dbContext = null;
            }

            disposed = true;
        }

        ~GenericRepository ()
        {
            Dispose(false);
        }
    }
}
