using System;

namespace Pipes
{
    public interface Pipe
    {
        object add(object e);
        void clear();
        int size();
        bool isEmpty();

        void view();
    }
}
