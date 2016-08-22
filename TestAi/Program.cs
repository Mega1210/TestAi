using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAi
{

    public static class Program
    {
        public static Random rndNr = new Random();

        static void Main(string[] args)
        {
            
            Worker Gab = new Worker(1,0,0,3,7,15,"Gab","Home");
            Wife Val = new Wife(1, "Val", "Home");
            Gab._stMachine = new StateMachine<Worker>(Gab, new GoHomeRest(), null);
           Val._stMachine=new StateMachine<Wife>(Val,new DoHomeWork(), new GlobalState());
            for (int i=0; i<20;i++)
            {
                
                Gab.Update();
                Val.Update();
                Console.ReadLine();
            }

            
            
                           
        }
    }
}
