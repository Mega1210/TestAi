using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAi
{
    abstract public class BaseEntity
    {
        public int EntityID { get; set; }
        private int NextID { get; set; }

        public BaseEntity(int entityId)
        {
            EntityID = entityId;
        }

        public int SetID(int val)

        {
            if (val >= NextID)
            {
                NextID = val + 1;
                return val;
            }
            else
            {
                NextID++;
                return NextID;
            }
        }

        public abstract void Update();
    }
}
