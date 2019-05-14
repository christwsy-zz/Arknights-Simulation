using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArknightsSimulationCore.Base.Agent
{
    public abstract class AbstractDpsAgent : AbstractAgent
    {
        public abstract void Attack(List<AbstractEnemy> enemies);
    }
}
