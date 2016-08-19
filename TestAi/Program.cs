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
        public int MaxTired { get; set; }
        public int MinTired { get; set; }
        public int MaxMoney { get; set; }
        public int MinMoney { get; set; }
        public int Money { get; set; }
        public string Location { get; set; }
        public State Status { get; set; }

        public void StatusOutput(Person p)
        {
            Console.WriteLine($"{p.Name} is {p.Location}. Money: {p.MinMoney} < {p.Money} < {p.MaxMoney} // Tiredness: {p.MinTired} < {p.Tired} < {p.MaxMoney}");
        }
        public void Update()
        {
            StatusOutput(this);
            Status.Execute(this);
            StatusOutput(this);

        }

        public void ChangeState(State st)
        {
            Status.Exit(this);
            Status = st;
            Status.Enter(this);
        }

        public bool CheckMinTired(Person p)
        {
            return p.Tired > p.MinTired;
        }

        public bool CheckMaxTired(Person p)
        {
            return p.Tired > p.MaxTired;
        }

        public bool CheckMinMoney(Person p)
        {
            return p.Money >= p.MinMoney;
        }

        public bool CheckMaxMoney(Person p)
        {
            return p.Money >= p.MaxMoney;
        }

        public Person(int id, int tired, int money, int minTired, int maxTired, int minMoney, int maxMoney, string name)
        {
            ID = id;
            Name = name;
            Tired = tired;
            Money = money;
            MinTired = minTired;
            MaxTired = maxTired;
            MinMoney = minMoney;
            MaxMoney = maxMoney;
            

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
                p.StatusOutput(p);
                Console.ReadLine();
            }
        }

        public override void Execute(Person p)
        {
            p.Money++;
            p.Tired++;
            Console.WriteLine($" {p.Name}: I'm in the office working!");
            p.StatusOutput(p);
            Console.ReadLine();
            if (p.CheckMaxMoney(p) && !p.CheckMaxTired(p)) /*(p.Money>5 && p.Tired<5)*/
            {
                p.ChangeState(new GoToPub());
                p.StatusOutput(p);

            } else
            {
                if (p.CheckMinTired(p)) /*(p.Tired >= 5)*/
                {
                    p.ChangeState(new GoHomeRest());
                    p.StatusOutput(p);
                }
            }
            
        }

        public override void Exit(Person p)
        {
            Console.WriteLine($" {p.Name}: I've worked enough I'm leaving the office!");
            p.StatusOutput(p);
            Console.ReadLine();
        }


    }

    class GoToPub:State
    {
        public override void Enter(Person p)
        {
            p.Location = "Pub";
            Console.WriteLine($" {p.Name}: I'm going to the Pub, I'm full of money!");
            p.StatusOutput(p);
            Console.ReadLine();
        }
            public override void Execute(Person p)
        {
            p.Money--;
            p.Tired++;
            Console.WriteLine($" {p.Name}: a pint of beer please");
            p.StatusOutput(p);
            if (p.CheckMaxTired(p))   /*(p.Tired>7)*/
            {
                p.ChangeState(new GoHomeRest());
                p.StatusOutput(p);
            }
            else
            {
                if (!p.CheckMinMoney(p)) /*(p.Money <= 2)*/
                {
                    p.ChangeState(new EnterOfficeAndWork());
                    p.StatusOutput(p);
                }
            }
            
        }
            public override void Exit(Person p)
        {
            Console.WriteLine($" {p.Name}: Time to leave the pub!");
            p.StatusOutput(p);
            Console.ReadLine();

        }
    }


    class GoHomeRest : State
    {
        public override void Enter(Person p)
        {
            p.Location = "Home";
            Console.WriteLine($" {p.Name}: Home sweet home!");
            p.StatusOutput(p);
            Console.ReadLine();
        }

        public override void Execute(Person p)
        {
           
            if (!p.CheckMaxTired(p) && !p.CheckMinTired(p)) /*(p.Tired<=3)*/
            {
                if (p.CheckMinMoney(p)) /*(p.Money > 5)*/
                {
                    p.ChangeState(new GoToPub());
                    p.StatusOutput(p);
                }
                else
                {
                    p.ChangeState(new EnterOfficeAndWork());
                    p.StatusOutput(p);
                }

                }
            else
            {
                Console.WriteLine($" {p.Name}: I'm going to sleep!");
                p.Tired--;
                p.StatusOutput(p);

                Console.ReadLine();
            }
        }

        public override void Exit(Person p)
        {
            Console.WriteLine($" {p.Name}: I've rested enough time to leave Home");
            p.StatusOutput(p);

            Console.ReadLine();
        }
    }

    

    public class Program
    {
        

        static void Main(string[] args)
        {
            string Exit;
            Person Gab = new Person(1,0,0,3,9,7,15,"Gab");
            Person Val = new Person(2, 0, 0,5, 9, 4, 8, "Val");
            Gab.Status = new EnterOfficeAndWork();
            Gab.Status.Enter(Gab);
            Val.Status = new EnterOfficeAndWork();
            Val.Status.Enter(Val);
            do
            {
                Gab.Update();
                Val.Update();
                Console.Write("Another turn?");
                Exit = Console.ReadLine();
            } while (Exit != "n" && Exit != "N");
            
          
            
                           
        }
    }
}
