using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAi
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Tired { get; set; }
        public int Money { get; set; }
        public string Location { get; set; }
        public State Status { get; set; }

        public void Update()
        {
            Console.WriteLine($"{Name} is {Location}. Money: {Money} Tiredness: {Tired}");
            Status.Execute(this);

        }

        public void ChangeState(State st)
        {
            Status.Exit(this);
            Status = st;
            Status.Enter(this);
        }

        public Person(int id, int tired, int money, string name)
        {
            ID = id;
            Name = name;
            Tired = tired;
            Money = money;
            

        }
    }

    abstract public class State
    {
        

        public abstract void Enter(Person person);
        public abstract void Execute(Person person);
        public abstract void Exit(Person person);

       
    }

    class EnterOfficeAndWork:State
    {
        
        public override void Enter(Person p)
        {
            if (p.Location!="Office")
            {
                p.Location = "Office";
                Console.WriteLine($" {p.Name}: I'm going to the office!");
                Console.ReadLine();
            }
        }

        public override void Execute(Person p)
        {
            p.Money++;
            p.Tired++;
            Console.WriteLine($" {p.Name}: I'm in the office working!");
            Console.ReadLine();
            if (p.Money>5 && p.Tired<5)
            {
                p.ChangeState(new GoToPub());

            } else
            {
                if (p.Tired >= 5)
                {
                    p.ChangeState(new GoHomeRest());
                }
            }
            
        }

        public override void Exit(Person p)
        {
            Console.WriteLine($" {p.Name}: I've worked enough I'm leaving the office!");
            Console.ReadLine();
        }


    }

    class GoToPub:State
    {
        public override void Enter(Person p)
        {
            p.Location = "Pub";
            Console.WriteLine($" {p.Name}: I'm going to the Pub, I'm full of money!");
            Console.ReadLine();
        }
            public override void Execute(Person p)
        {
            p.Money--;
            p.Tired++;
            Console.WriteLine($" {p.Name}: a pint of beer please");
            if (p.Tired>7)
            {
                p.ChangeState(new GoHomeRest());
            }else
            {
                if (p.Money <= 2)
                {
                    p.ChangeState(new EnterOfficeAndWork());
                }
            }
            
        }
            public override void Exit(Person p)
        {
            Console.WriteLine($" {p.Name}: Time to leave the pub!");
            Console.ReadLine();

        }
    }


    class GoHomeRest : State
    {
        public override void Enter(Person p)
        {
            p.Location = "Home";
            Console.WriteLine($" {p.Name}: Home sweet home!");
            Console.ReadLine();
        }

        public override void Execute(Person p)
        {
           
            if (p.Tired<=3)
            {
               if (p.Money>5)
                {
                    p.ChangeState(new GoToPub());
                } else  p.ChangeState(new EnterOfficeAndWork());

            } else
            {
                Console.WriteLine($" {p.Name}: I'm going to sleep!");
                p.Tired--;
                Console.ReadLine();
            }
        }

        public override void Exit(Person p)
        {
            Console.WriteLine($" {p.Name}: I've rested enough time to leave Home");
            Console.ReadLine();
        }
    }

    public 

    class Program
    {
        static void Main(string[] args)
        {
            string Exit;
            Person Gab = new Person(1,0,0,"Gab");
            Gab.Status = new EnterOfficeAndWork();
            Gab.Status.Enter(Gab);
            do
            {
                Gab.Update();
                Console.Write("Another turn?");
                Exit = Console.ReadLine();
            } while (Exit != "n" && Exit != "N");
            
          
            
                           
        }
    }
}
