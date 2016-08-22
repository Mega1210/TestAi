using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAi
{
    public class Worker : BaseEntity
    {

        public string Name { get; set; }
        public int Tired { get; set; } 
        public int MaxTired { get; set; } 

        public int MaxMoney { get; set; } 
        public int MinMoney { get; set; } 
        public int Money { get; set; } 
        public string Location { get; set; } 
        
        public StateMachine<Worker> _stMachine { get; set; }

        public Worker(int entityId, int tired, int money, int maxTired,
            int minMoney, int maxMoney, string name, string location) : base(entityId)
        {
            EntityID = entityId;
            Name = name;
            Tired = tired;
            Money = money;
            Location = location;
    
            MaxTired = maxTired;
            MinMoney = minMoney;
            MaxMoney = maxMoney;


        }
       /* public void StatusOutput()
        {
            Console.WriteLine($"{this.Name} is {this.Location}. Money: {this.MinMoney} < {this.Money} < {this.MaxMoney} // Tiredness: {this.Tired} < {this.MaxTired}");
        }*/

        public override void Update()
        {
           
            _stMachine.Update();
           // StatusOutput();

        }






        public bool CheckMaxTired(Worker p)
        {
            return p.Tired > p.MaxTired;
        }

        public bool CheckMinMoney(Worker p)
        {
            return p.Money >= p.MinMoney;
        }

        public bool CheckMaxMoney(Worker p)
        {
            return p.Money >= p.MaxMoney;
        }

    }
}
