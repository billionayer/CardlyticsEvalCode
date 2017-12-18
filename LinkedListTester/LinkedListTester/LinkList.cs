using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTester
{
    public enum MyLinkListSearchDirection
    {
        Ascending,
        Descending
    }
    public class MyLinkList<T>
    {
        private MyLinkedListItem<T> _start;
        private MyLinkedListItem<T> _end;
        public MyLinkedListItem<T> Start
        {
            get
            {
                return _start;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return (_start == null);
            }
        }

        /// <summary>
        /// FindItemDescending - Finds the the nth number item from the end of the list
        /// The algorithm requires at least one full pass on the entire list so that we can find the end of the list
        /// Because we can only traverse the list once, we have to save each reference for each item access into
        /// a revolving collection stored in arrayOfReference which is the size of the item trying to be found
        ///
        /// </summary>
        /// <param name="nth"> This parameter is assumed to be index 1 instead of index 0 based.</param>
        /// <returns></returns>
        private MyLinkedListItem<T> FindItemDescending(ulong nth)
        {
            MyLinkedListItem<T>[] arrayOfReferences = new MyLinkedListItem<T>[nth];
            MyLinkedListItem<T> temp = _start;
            MyLinkedListItem<T> retItem = null;

            //If there is a null linked list then return null;
            if (_start == null || nth == 0)
            {
                return null;
            }

            ulong index = 0;
            while (temp.Next != null)
            {
                //Continue writing items into array.  If we exceed nth then 
                //the mod operation will begin overwriting entries at the beginning of
                //the array.
                arrayOfReferences[index++ % nth] = temp;
                temp = temp.Next;
            }

            if (index >= nth)
            {
                retItem = arrayOfReferences[index % nth];
            }
            return retItem;

        }

        /// <summary>
        /// FindItemDescending - Finds the the nth number item from the start of the list
        ///
        /// </summary>
        /// <param name="nth"> This parameter is assumed to be index 1 instead of index 0 based.</param>
        /// <returns></returns>
        private MyLinkedListItem<T> FindItemAscending(ulong nth)
        {
            if (_start == null)
            {
                return null;
            }

            //No need to search the list if item is index 1 since that is the start item.
            if(nth == 1)
            {
                return _start;
            }
            MyLinkedListItem<T> temp = _start;
            ulong index = 0;
            while(temp != null)
            {
                //Once item index found return that item and terminate search.
                if(++index == nth)
                {
                    return temp;
                }
                temp = temp.Next;
            }

            //If itemNumber index is not reached then there were not enough items in the list.
            return null;
        }

        public void Push(T itemVal)
        {
            if(_start == null)
            {
                _start = new MyLinkedListItem<T>(itemVal);
                _end = _start;
            }
            else
            {
                _end = _end.Add(itemVal);
            }
        }

        public void Clear()
        {
          
            if (_start == null)
            {
                return;
            }
            
            MyLinkedListItem<T> current = _start;
            MyLinkedListItem<T> next = _start.Next;
            while (next != null)
            {
                next = current.Next;
                current.Unlink();
            }
            _start = null;
        }
        
        public MyLinkedListItem<T> FindItem(ulong itemNumber, MyLinkListSearchDirection direction)
        {
            MyLinkedListItem<T> retItem = null;
            switch(direction)
            {
                case MyLinkListSearchDirection.Ascending:
                    retItem = FindItemAscending(itemNumber);
                    break;
                case MyLinkListSearchDirection.Descending:
                    retItem = FindItemDescending(itemNumber);
                    break;
            }       
            return retItem;
        }
        

    }
}
