using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAi
{
    public class Wife:BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public StateMachine<Wife> _stMachine { get; set; }

        public Wife (int entityId, string name, string location):base(entityId)
        {
            EntityID = entityId;
            Location = location;
            Name = name;
        }


        public override void Update()
        {
            _stMachine.Update();
            //StatusOutput();
        }
    }
}
