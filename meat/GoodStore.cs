using System;
using System.Collections.Generic;
using meat.development_purchasing;

namespace meat
{
    public class GoodStore
    {
        public virtual void add(int number_of_goods)
        {
            throw new NotImplementedException();
        }

        public virtual void remove_all()
        {
            throw new NotImplementedException();
        }

        public virtual void remove(IEnumerable<Good> goods)
        {
            throw new NotImplementedException();
        }

        public virtual void remove(Good good, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}