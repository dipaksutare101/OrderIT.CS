using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;

namespace OrderIT.DomainModel.Tests
{
    internal class FakeObjectSet<T> : IObjectSet<T> where T: class
    {
        private List<T> innerList = new List<T>();
        public List<T> InnerList
        {
            get { return this.innerList; }
        }

        public FakeObjectSet()
        {
        }

        public FakeObjectSet(IEnumerable<T> items)
        {
            this.innerList = new List<T>(items);
        }

        #region IObjectSet<T> Members

        public void AddObject(T entity)
        {
            this.innerList.Add(entity);
        }

        public void Attach(T entity)
        {
            if (!this.innerList.Contains(entity))
                this.innerList.Add(entity);
        }

        public void DeleteObject(T entity)
        {
            
        }

        public void Detach(T entity)
        {
            if (this.innerList.Contains(entity))
                this.innerList.Remove(entity);
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.innerList.GetEnumerator();
        }

        #endregion

        #region IQueryable Members

        public Type ElementType
        {
            get { return typeof(T); }
        }

        public Expression Expression
        {
            get { return this.innerList.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return this.innerList.AsQueryable().Provider; }
        }

        #endregion
    }
}
