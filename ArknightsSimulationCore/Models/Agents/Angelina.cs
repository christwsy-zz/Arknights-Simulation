using ArknightsSimulationCore.Base;
using ArknightsSimulationCore.Base.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArknightsSimulationCore.Models.Agents
{
    class Angelina : AbstractDpsAgent
    {
        public Angelina()
        {
            this.name = "Angelina";
        }

        public override void Attack(List<AbstractEnemy> enemies)
        {
            foreach (AbstractEnemy enemy in enemies)
            {
                Console.WriteLine(this.name + " attacked " + enemy.name);
            }
        }

        public override void PerformSuperchargedAction<T>(IList<T> targets)
        {
            foreach (ITarget target in targets)
            {
                if (target is AbstractAgent)
                {

                } else if (target is AbstractEnemy)
                {
                    Console.WriteLine("Angelina performed action on " + ((AbstractEnemy)target).name);
                }
            }
        }
    }
}
