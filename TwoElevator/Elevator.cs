using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoElevator
{
    class Elevator
    {
        int pozition;
        int status; //0 ha áll
        int startpozition;

        public int Pozition
        {
            get
            {
                return pozition;
            }

            set
            {
                pozition = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Startpozition
        {
            get
            {
                return startpozition;
            }

            set
            {
                startpozition = value;
            }
        }
    }
}
