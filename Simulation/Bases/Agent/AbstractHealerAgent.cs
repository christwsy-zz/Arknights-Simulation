﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arknights_Simulation.Simulation.Base.Agent
{
    public abstract class AbstractHealerAgent : AbstractAgent
    {
        public abstract void Attack(List<AbstractEnemy> enemies);
        public abstract void Heal(List<AbstractAgent> agents);
    }
}
