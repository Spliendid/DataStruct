using System;
using System.Collections.Generic;

namespace StackAndQueue
{
    public interface QueueInterface<E>
    {
        void Enqueue(E e);
        E Dequeue();
        E GetFront();
        int GetSize();
        bool IsEmpty();
    }
}
