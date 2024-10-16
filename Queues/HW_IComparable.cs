using System;
using System.Collections.Generic;

namespace Queues
{
    public class HW_IComparable : IComparable
    {
        float mass, height;
        public HW_IComparable(float mass, float height)
        {
            this.mass = mass;
            this.height = height;
        }
        public int CompareTo(object e)
        {
            float bmi1 = mass / (height * height);

            HW_IComparable E = (HW_IComparable)e;

            float bmi2 = E.mass / (E.height * E.height);

            if (bmi1 < bmi2)
            {
                return -1;
            }
            if (bmi2 < bmi1)
            {
                return 1;
            }

            return 0;
        }
    }
}
