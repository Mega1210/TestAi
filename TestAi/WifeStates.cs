using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TestAi
{
    
    class WifeStates
    {
     
    }

    class GlobalState:State<Wife>
    {
        public override void Enter(Wife w)
        {

        }

        public override void Exit(Wife w)
        {
            
        }

        public override void Execute(Wife w)
        {
           
            if (Program.rndNr.Next(0, 99) < 10) w._stMachine.ChangeState(new GoToBathroom());
        }
    }

    class DoHomeWork : State<Wife>
    {
        public override void Enter(Wife w)
        {

        }

        public override void Exit(Wife w)
        {

        }

        public override void Execute(Wife w)
        {
            switch (Program.rndNr.Next(0,3))
            {
                case 0:
                    Console.WriteLine($" {w.Name}: Mopping the floor");
                   // Console.ReadLine();
                    break;
                case 1:
                    Console.WriteLine($" {w.Name}: Cleaning the windows");
                   // Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine($" {w.Name}: Washing the dirty clothes");
                  //  Console.ReadLine();
                    break;

            }
        }
    }

    class GoToBathroom : State<Wife>
    {
        public override void Enter(Wife w)
        {
            Console.WriteLine($" {w.Name}: Need to go to the bathroom!");
          //  Console.ReadLine();
        }

        public override void Exit(Wife w)
        {
            Console.WriteLine($" {w.Name}: Going back to my homework!");
          
         //   Console.ReadLine();
        }

        public override void Execute(Wife w)
        {
            Console.WriteLine($" {w.Name}: Ahhhhhh!");
            w._stMachine.RevertToPreviousState();
         //   Console.ReadLine();
        }
    }
}
