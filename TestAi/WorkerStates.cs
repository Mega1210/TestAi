using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAi
{
    class WorkerStates
    {
    }
    
    class EnterOfficeAndWork : State<Worker>
    {

        public override void Enter(Worker p)
        {
            if (p.Location != "Office")
            {
                p.Location = "Office";
                Console.WriteLine($" {p.Name}: I'm going to the office!");
                //p.StatusOutput();
              //  Console.ReadLine();
            }
        }

        public override void Execute(Worker p)
        {
            p.Money++;
            p.Tired++;
            Console.WriteLine($" {p.Name}: I'm in the office working!");
            
         //   Console.ReadLine();
            if (p.CheckMaxMoney(p) && !p.CheckMaxTired(p))
            {
                p._stMachine.ChangeState(new GoToPub());
                //p.StatusOutput();

            }
            else
            {
                if (p.CheckMaxTired(p))
                {
                    p._stMachine.ChangeState(new GoHomeRest());
                  //  p.StatusOutput();
                }
            }

        }

        public override void Exit(Worker p)
        {
            Console.WriteLine($" {p.Name}: I've worked enough I'm leaving the office!");
          //  p.StatusOutput();
          //  Console.ReadLine();
        }


    }

    class GoToPub : State<Worker>
    {
        public override void Enter(Worker p)
        {
            p.Location = "Pub";
            Console.WriteLine($" {p.Name}: I'm going to the Pub, I'm full of money!");
         //   p.StatusOutput();
          //  Console.ReadLine();
        }
        public override void Execute(Worker p)
        {
            p.Money--;
            p.Tired++;
            Console.WriteLine($" {p.Name}: a pint of beer please");
           // p.StatusOutput();
            if (p.CheckMaxTired(p))
            {
                p._stMachine.ChangeState(new GoHomeRest());
           //     p.StatusOutput();
            }
            else
            {
                if (!p.CheckMinMoney(p))
                {
                    p._stMachine.ChangeState(new EnterOfficeAndWork());
           //         p.StatusOutput();
                }
            }

        }
        public override void Exit(Worker p)
        {
            Console.WriteLine($" {p.Name}: Time to leave the pub!");
         //   p.StatusOutput();
        //    Console.ReadLine();

        }
    }


    class GoHomeRest : State<Worker>
    {
        public override void Enter(Worker p)
        {
            p.Location = "Home";
            Console.WriteLine($" {p.Name}: Home sweet home! I'm going to sleep");
         //   p.StatusOutput();
         //   Console.ReadLine();
        }

        public override void Execute(Worker p)
        {

            if (!p.CheckMaxTired(p))
            {
                if (p.CheckMinMoney(p))
                {
                    p._stMachine.ChangeState(new GoToPub());
            //        p.StatusOutput();
                }
                else
                {
                    if (p.Tired==0)
                    {
                        p._stMachine.ChangeState(new EnterOfficeAndWork());
               //         p.StatusOutput();
                    }
                    else
                    {
                        Console.WriteLine($" {p.Name}: Zzzz...");
                        p.Tired--;
                  //      p.StatusOutput();

                  //      Console.ReadLine();
                    }
                    
                }

            }
            else
            {
                Console.WriteLine($" {p.Name}: Zzzz...");
                p.Tired--;
             //   p.StatusOutput();

              //  Console.ReadLine();
            }
        }

        public override void Exit(Worker p)
        {
            Console.WriteLine($" {p.Name}: I've rested enough time to leave Home");
          //  p.StatusOutput();

          //  Console.ReadLine();
        }
    }
}
