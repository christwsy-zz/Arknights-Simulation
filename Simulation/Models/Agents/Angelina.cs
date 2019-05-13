using Arknights_Simulation.Simulation.Base;
using Arknights_Simulation.Simulation.Base.Agent;
using Arknights_Simulation.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arknights_Simulation.Simulation.Models.Agents
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
