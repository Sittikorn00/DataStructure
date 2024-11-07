using System;


namespace Buffers
{
    public interface Buffer
    {
        void add(object e);
        void clear();
        int size();
        bool isEmpty();
        void view();
    }
}
