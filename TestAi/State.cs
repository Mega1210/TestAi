using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAi
{

    abstract public class State<T>
    {


        public abstract void Enter(T entity);
        public abstract void Execute(T entity);
        public abstract void Exit(T entity);


    }
}
