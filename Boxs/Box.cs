using System;

namespace Boxs
{
    public interface Box
    {
        void add(int e);
        void remove(int e);
        int size();
        bool isEmpty();
        void view();
    }
}
