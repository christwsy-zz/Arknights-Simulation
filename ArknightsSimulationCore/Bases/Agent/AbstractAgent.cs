using ArknightsSimulationCore.Protocols;
using System;
using System.Collections.Generic;

namespace ArknightsSimulationCore.Base.Agent
{
    public abstract class AbstractAgent : ITarget
    {
        public String name;
        public int healthPoint;
        public int attackPoint;
        public int physicalDefensePoint;
        public int magicalDefensePoint;
        public int deployCost;
        public int redeployCost;
        public int perfectDeployCost;
        public int maxBlockingCount;

        public abstract void PerformSuperchargedAction<T>(IList<T> targets) where T:ITarget;
    }
}
