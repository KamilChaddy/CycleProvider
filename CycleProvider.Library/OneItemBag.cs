using CycleProvider.Contracts;

namespace CycleProvider.Library
{
    public class OneItemBag<T> where T : class
    {
        private T _item;
        private bool _isEmpty = true;

        public void Put(T item)
        {
            if (!_isEmpty) throw new OneItemBagException(InvalidOperationExceptionMessages.BagIsNotEmpty);

            _isEmpty = false;
            _item = item;
        }

        public T Get()
        {
            if (_isEmpty) throw new OneItemBagException(InvalidOperationExceptionMessages.BagIsEmpty);

            _isEmpty = true;
            var returnValue = _item;  //garbage kolektor może to usunąć.
            _item = null;
            return returnValue;
        }
    }
}
