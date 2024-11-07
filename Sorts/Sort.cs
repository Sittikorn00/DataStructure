using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    public interface Sort
    {
        void add(object e);
        void clear();
        int size();
        bool isEmpty();
        void view();

    }
}
