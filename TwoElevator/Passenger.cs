using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoElevator
{
    class Passenger
    {
        int name;
        int from;
        int to;

        public int From
        {
            get
            {
                return from;
            }

            set
            {
                from = value;
            }
        }

        public int To
        {
            get
            {
                return to;
            }

            set
            {
                to = value;
            }
        }

        public int Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
