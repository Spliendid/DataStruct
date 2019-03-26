using System;
using System.Collections.Generic;
using System.Text;

namespace StackAndQueue
{
    interface StackInterface<E>
    {
        void Push(E e);
        E Pop();
        E Peek();
        int GetSize();
        bool IsEmpty();
    }
}
