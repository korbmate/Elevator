using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoElevator
{
    public partial class TwoElevators : Form
    {
        List<Button> consoleA = new List<Button>();
        List<Button> consoleB = new List<Button>();
        List<Button> showA = new List<Button>();
        List<Button> showB = new List<Button>();
        List<Button> ups = new List<Button>();
        List<Button> downs = new List<Button>();

        Elevator A = new Elevator();
        Elevator B = new Elevator();

        int countOfAllPass = 0;
        int allnotarrived = 0;

        List<Passenger> waitForC = new List<Passenger>();
        List<Passenger> waitForA = new List<Passenger>();
        List<Passenger> waitForB = new List<Passenger>();
        List<Passenger> pasInA = new List<Passenger>();
        List<Passenger> pasInB = new List<Passenger>();
        List<Passenger> arrivedPas = new List<Passenger>();

        public TwoElevators()
        {
            InitializeComponent();

            ButtonsToLists();

            A.Pozition = 0;
            A.Status = 0;
            A.Startpozition = 0;
            B.Pozition = 7;
            B.Status = 0;
            B.Startpozition = 7;

            showA[A.Pozition].BackColor = Color.Red;
            showB[B.Pozition].BackColor = Color.Red;

            timer1.Start();

        }

        private void ButtonsToLists()
        {
            consoleA.Add(btnConsoleA00);
            consoleA.Add(btnConsoleA01);
            consoleA.Add(btnConsoleA02);
            consoleA.Add(btnConsoleA03);
            consoleA.Add(btnConsoleA04);
            consoleA.Add(btnConsoleA05);
            consoleA.Add(btnConsoleA06);
            consoleA.Add(btnConsoleA07);
            consoleA.Add(btnConsoleA08);
            consoleA.Add(btnConsoleA09);
            consoleA.Add(btnConsoleA10);
            consoleB.Add(btnConsoleB00);
            consoleB.Add(btnConsoleB01);
            consoleB.Add(btnConsoleB02);
            consoleB.Add(btnConsoleB03);
            consoleB.Add(btnConsoleB04);
            consoleB.Add(btnConsoleB05);
            consoleB.Add(btnConsoleB06);
            consoleB.Add(btnConsoleB07);
            consoleB.Add(btnConsoleB08);
            consoleB.Add(btnConsoleB09);
            consoleB.Add(btnConsoleB10);
            showA.Add(btnShowA00);
            showA.Add(btnShowA01);
            showA.Add(btnShowA02);
            showA.Add(btnShowA03);
            showA.Add(btnShowA04);
            showA.Add(btnShowA05);
            showA.Add(btnShowA06);
            showA.Add(btnShowA07);
            showA.Add(btnShowA08);
            showA.Add(btnShowA09);
            showA.Add(btnShowA10);
            showB.Add(btnShowB00);
            showB.Add(btnShowB01);
            showB.Add(btnShowB02);
            showB.Add(btnShowB03);
            showB.Add(btnShowB04);
            showB.Add(btnShowB05);
            showB.Add(btnShowB06);
            showB.Add(btnShowB07);
            showB.Add(btnShowB08);
            showB.Add(btnShowB09);
            showB.Add(btnShowB10);
            ups.Add(btnUp00);
            ups.Add(btnUp01);
            ups.Add(btnUp02);
            ups.Add(btnUp03);
            ups.Add(btnUp04);
            ups.Add(btnUp05);
            ups.Add(btnUp06);
            ups.Add(btnUp07);
            ups.Add(btnUp08);
            ups.Add(btnUp09);
            ups.Add(btnUp10);
            downs.Add(btnDown00);
            downs.Add(btnDown01);
            downs.Add(btnDown02);
            downs.Add(btnDown03);
            downs.Add(btnDown04);
            downs.Add(btnDown05);
            downs.Add(btnDown06);
            downs.Add(btnDown07);
            downs.Add(btnDown08);
            downs.Add(btnDown09);
            downs.Add(btnDown10);
        }

        private void btnAddPas_Click(object sender, EventArgs e)
        {
            if (allnotarrived < 10)
            {
                countOfAllPass++;
                allnotarrived++;
                Passenger p = new Passenger();
                p.Name = countOfAllPass;
                Random rnd = new Random();
                p.From = rnd.Next(11);
                //p.From = 0;
                p.To = p.From;
                while (p.To == p.From)
                {
                    p.To = rnd.Next(11);
                }
                if (p.From > p.To)
                {
                    downs[p.From].BackColor = Color.Green;
                }
                else
                {
                    ups[p.From].BackColor = Color.Green;
                }
                Classification(p, waitForA,waitForB);

            }
            else
            {
                MessageBox.Show("It is full.");
            }
        }

        private void Classification(Passenger passenger, List<Passenger> waitForA, List<Passenger> waitForB)
        {
            if (A.Status == 0 && B.Status == 0)
            {
                if (A.Pozition == B.Pozition)
                {
                    waitForA.Add(passenger);
                }
                else if (Math.Abs(A.Pozition - passenger.From) < Math.Abs(B.Pozition - passenger.From))
                {
                    waitForA.Add(passenger);
                }
                else
                {
                    waitForB.Add(passenger);
                }
            }
            else if(A.Status ==0 && B.Status !=0)
            {
                if (Math.Abs(A.Pozition-passenger.From)<Math.Abs(B.Pozition-passenger.From))
                {
                    waitForA.Add(passenger);
                }
                else if (B.Status == 1)
                {
                    if (waitForB[0].From < waitForB[0].To)//ha B felfelé halad
                    {
                        if (passenger.From < passenger.To)//ha az utas felfelé akar menni
                        {
                            waitForB.Add(passenger);
                        }
                        else
                        {
                            waitForA.Add(passenger);
                        }
                    }
                    else if (waitForB[0].From > waitForB[0].To)// ha b lefelé halad
                    {
                        if (passenger.From > passenger.To)
                        {
                            waitForB.Add(passenger);
                        }
                        else
                        {
                            waitForA.Add(passenger);
                        }
                    }
                    
                }
                else if (B.Status == 2)
                {
                    if(pasInB[0].From < pasInB[0].To)
                    {
                        if (passenger.From > B.Pozition)
                        {
                            waitForB.Add(passenger);
                        }
                        else
                        {
                            waitForA.Add(passenger);
                        }
                    }
                    else if (pasInB[0].From > pasInB[0].To)
                    {
                        if (passenger.From < B.Pozition)
                        {
                            waitForB.Add(passenger);
                        }
                        else
                        {
                            waitForA.Add(passenger);
                        }
                    }
                }
            }
            else if (A.Status != 0 && B.Status == 0)
            {
                if (Math.Abs(B.Pozition-passenger.From)<Math.Abs(A.Pozition-passenger.From))
                {
                    waitForB.Add(passenger);
                }
                else if (A.Status == 1)
                {
                    if (waitForA[0].From < waitForA[0].To)//ha A felfelé halad
                    {
                        if (passenger.From < passenger.To)
                        {
                            waitForA.Add(passenger);
                        }
                        else
                        {
                            waitForB.Add(passenger);
                        }
                    }
                    else if (waitForA[0].From > waitForA[0].To)
                    {
                        if (passenger.From > passenger.To)
                        {
                            waitForA.Add(passenger);
                        }
                        else
                        {
                            waitForB.Add(passenger);
                        }
                    }
                }
                else if (A.Status == 2)
                {
                    if (pasInA[0].From < pasInA[0].To)
                    {
                        if (passenger.From > A.Pozition)
                        {
                            waitForA.Add(passenger);
                        }
                        else
                        {
                            waitForB.Add(passenger);
                        }
                    }
                    else if (pasInA[0].From > pasInA[0].To)
                    {
                        if (passenger.From < B.Pozition)
                        {
                            waitForA.Add(passenger);
                        }
                        else
                        {
                            waitForB.Add(passenger);
                        }
                    }
                }
            }
            else //if (A.Status != 0 && B.Status != 0)
            {
                waitForC.Add(passenger);
                Writeout();
            }



            Writeout();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Stepper(A,waitForA,pasInA,arrivedPas);
            Writeout();
            Stepper(B,waitForB,pasInB,arrivedPas);
            Writeout();
        }

        private void Writeout()
        {
            tbWaiting.Text = "";
            tbA.Text = "";
            tbB.Text = "";
            foreach (Passenger item in waitForC)
            {
                tbWaiting.Text = tbWaiting.Text + "Passenger" + item.Name + "    from " + item.From + "    to " + item.To + " \n";
            }
            foreach (Passenger item in waitForA)
            {
                tbWaiting.Text = tbWaiting.Text + "Passenger" + item.Name + "    from " + item.From + "    to " + item.To + " \n";
            }
            foreach (Passenger item in waitForB)
            {
                tbWaiting.Text = tbWaiting.Text + "Passenger" + item.Name + "    from " + item.From + "    to " + item.To + " \n";
            }
            foreach (Passenger item in pasInA)
            {
                tbA.Text = tbA.Text + "Passenger" + item.Name + "    from " + item.From + "    to " + item.To + " \n";
            }
            foreach (Passenger item in pasInB)
            {
                tbB.Text = tbB.Text + "Passenger" + item.Name + "    from " + item.From + "    to " + item.To + " \n";
            }
            
        }

        private void Stepper(Elevator elevator, List<Passenger> wait, List<Passenger> pasIn, List<Passenger> arriwed)
        {
            if(wait.Count == 0 && elevator.Status == 0)
            {
                if (waitForC.Count > 0)
                {
                    Classification(waitForC[0], waitForA, waitForB);
                    waitForC.Remove(waitForC[0]);
                }
            }
            else if(elevator.Status == 0)
            {
                if (elevator.Pozition == wait[0].From)
                {
                    GetInFirst(elevator, wait, pasIn, arriwed);
                    elevator.Status = 2;
                    elevator.Startpozition = elevator.Pozition;
                }
                else
                {
                    elevator.Status = 1;
                }
            }
            else if (elevator.Status == 1)
            {
                FirstDirection(elevator, wait, pasIn, arriwed);
            }
            else if (elevator.Status == 2)
            {
                SeccondDirection(elevator, wait, pasIn, arriwed);
            }
            else if (elevator.Status == 3)
            {

            }
            else if (elevator.Status == 4)
            {

            }
        }

        private void SeccondDirection(Elevator elevator, List<Passenger> wait, List<Passenger> pasIn, List<Passenger> arriwed)
        {
            GetInFirst(elevator, wait, pasIn, arriwed);
            GetInFirst(elevator, waitForC, pasIn, arriwed);
            TakeOff(elevator, wait, pasIn, arriwed);
            if (pasIn.Count == 0)
            {
                elevator.Status = 0;
                elevator.Startpozition = elevator.Pozition;
            }
            else
            {
                if (pasIn[0].From > pasIn[0].To)
                {
                    MoveDown(elevator, wait, pasIn, arriwed);
                }
                else if (pasIn[0].From < pasIn[0].To)
                {
                    MoveUp(elevator, wait, pasIn, arriwed);
                }
            }
            
        }
        

        private void TakeOff(Elevator elevator, List<Passenger> wait, List<Passenger> pasIn, List<Passenger> arriwed)
        {
            for (int i = 0; i < pasIn.Count; i++)
            {
                if (pasIn[i].To == elevator.Pozition)
                {

                    arriwed.Add(pasIn[i]);
                    pasIn.Remove(pasIn[i]);
                    allnotarrived--;
                    i--;
                    foreach (Button item in consoleA)
                    {
                        item.BackColor = Color.White;
                    }
                    foreach (Button item in consoleB)
                    {
                        item.BackColor = Color.White;
                    }
                    foreach (Passenger item in pasInA)
                    {
                        consoleA[item.To].BackColor = Color.Green;
                    }
                    foreach (Passenger item in pasInB)
                    {
                        consoleB[item.To].BackColor = Color.Green;
                    }
                    tbArrived.Text = "";
                    foreach (var item in arrivedPas)
                    {
                        tbArrived.Text = tbArrived.Text + "Passenger" + item.Name + "    from " + item.From + "    to " + item.To + " \n";
                    }
                }
            }
            if (pasIn.Count == 0)
            {
                elevator.Status = 0;
                elevator.Startpozition = elevator.Pozition;
            }
        }

        private void GetInFirst(Elevator elevator, List<Passenger> wait, List<Passenger> pasIn, List<Passenger> arriwed)
        {
            
            for (int i = 0; i < wait.Count; i++)
            {
                if (wait[i].From == elevator.Pozition)
                {
                    if (wait[i].From > wait[i].To)
                    {
                        downs[elevator.Pozition].BackColor = Color.White;
                    }
                    else
                    {
                        ups[elevator.Pozition].BackColor = Color.White;
                    }
                    pasIn.Add(wait[i]);
                    wait.Remove(wait[i]);
                    i--;
                }
            }
            foreach (Passenger item in pasInA)
            {
                consoleA[item.To].BackColor = Color.Green;
            }
            foreach (Passenger item in pasInB)
            {
                consoleB[item.To].BackColor = Color.Green;
            }
        }

        private void FirstDirection(Elevator elevator, List<Passenger> wait, List<Passenger> pasIn, List<Passenger> arriwed)
        {
            if (elevator.Startpozition > wait[0].From)
            {
                int min = wait[0].From;
                foreach (Passenger item in wait)
                {
                    if (item.From < min)
                    {
                        min = item.From;
                    }
                }

                if (elevator.Pozition > min)
                {
                    MoveDown(elevator, wait, pasIn, arriwed);
                }
                else if (elevator.Pozition == min)
                {
                    GetInFirst(elevator, wait, pasIn, arriwed);
                    elevator.Status = 2;
                    elevator.Startpozition = elevator.Pozition;
                }
            }
            else if (elevator.Startpozition < wait[0].From)
            {
                int max = wait[0].From;
                foreach (Passenger item in wait)
                {
                    if (item.From > max)
                    {
                        max = item.From;
                    }
                }
                if (elevator.Pozition < max)
                {
                    MoveUp(elevator, wait, pasIn, arriwed);
                }
                else if (elevator.Pozition == max)
                {
                    GetInFirst(elevator, wait, pasIn, arriwed);
                    elevator.Status = 2;
                    elevator.Startpozition = elevator.Pozition;
                }
                
            }
        }

        private void MoveUp(Elevator elevator, List<Passenger> wait, List<Passenger> pasIn, List<Passenger> arriwed)
        {
            elevator.Pozition++;
            for (int i = 0; i < showA.Count; i++)
            {
                if (i == A.Pozition)
                {
                    showA[i].BackColor = Color.Red;
                }
                else
                {
                    showA[i].BackColor = Color.White;
                }
            }
            for (int i = 0; i < showB.Count; i++)
            {
                if (i == B.Pozition)
                {
                    showB[i].BackColor = Color.Red;
                }
                else
                {
                    showB[i].BackColor = Color.White;
                }
            }
        }

        private void MoveDown(Elevator elevator, List<Passenger> wait, List<Passenger> pasIn, List<Passenger> arriwed)
        {
            elevator.Pozition--;

            for (int i = 0; i < showA.Count; i++)
            {
                if (i == A.Pozition)
                {
                    showA[i].BackColor = Color.Red;
                }
                else
                {
                    showA[i].BackColor = Color.White;
                }
            }
            for (int i = 0; i < showB.Count; i++)
            {
                if (i == B.Pozition)
                {
                    showB[i].BackColor = Color.Red;
                }
                else
                {
                    showB[i].BackColor = Color.White;
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            arrivedPas.Clear();
            tbArrived.Text = "";
        }

        private void btnSpeed_Click(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(2200 - numSpeed.Value * 200);
        }
    }
}
