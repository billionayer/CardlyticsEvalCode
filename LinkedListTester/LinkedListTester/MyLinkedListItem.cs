using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTester
{
    public class MyLinkedListItem<T>
    {
        protected MyLinkedListItem<T> _next;

        public T Value { get; set; }
        public MyLinkedListItem<T> Next
        {
            get
            {
                return _next;
            }
        }

        public MyLinkedListItem(T item)
        {
            Value = item;
            _next = null;
        }

        public MyLinkedListItem<T> Add(T item)
        {
            this._next = new MyLinkedListItem<T>(item);
            return this._next;
        }
        
        public void Add( MyLinkedListItem<T> item)
        {
            _next = item;
        }

        public void Unlink()
        {
            _next = null;
        }

        public MyLinkedListItem<T> Modify( MyLinkedListItem<T> newItem)
        {
            MyLinkedListItem<T> temp = _next;
            _next = newItem;
            return _next;
        }
    }
}
