using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;

namespace OrderIT.DomainModel
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IObjectContext context;
        internal IObjectContext Context
        {
            get { return context; }
        }
        private IObjectSet<T> entitySet;
        internal IObjectSet<T> EntitySet
        {
            get { return entitySet; }
        }

        public Repository(IObjectContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            this.context = context;
            this.entitySet = context.CreateObjectSet<T>();
        }

        public virtual IQueryable<T> OfType()
        {
            return this.entitySet.OfType<T>();
        }

        #region IRepository<T> Members

        public virtual IEnumerable<T> Query(Func<T, bool> predicate)
        {
            return this.entitySet.Where(predicate);
        }

        public virtual T GetSingle(Func<T, bool> predicate)
        {
            T res = this.GetSingleOrDefault(predicate);
            if (res == null)
                throw new InvalidOperationException("Predicate returned no results");

            return res;
        }
        
        public virtual T GetSingleOrDefault(Func<T, bool> predicate)
        {
            return this.Query(predicate).SingleOrDefault();
        }

        public virtual void Add(T entity)
        {
            //if (!this.Contains(entity))
                this.entitySet.AddObject(entity);
        }

        public virtual void Update(T entity)
        {
            if (!this.Contains(entity))
                this.entitySet.Attach(entity);
        }

        public virtual bool Remove(T entity)
        {
            if (!this.Contains(entity))
                return false;

            this.entitySet.DeleteObject(entity);

            return true;
        }

        public virtual bool Contains(T item)
        {
            ObjectStateEntry state;
            
            if (!this.context.ObjectStateManager.TryGetObjectStateEntry(item, out state))
                return false;

            return (state.State != EntityState.Detached);
        }

        #endregion

        #region ICollection<T> Members


        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }



        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return entitySet.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
			return entitySet.GetEnumerator();
        }

        #endregion
    }
}
