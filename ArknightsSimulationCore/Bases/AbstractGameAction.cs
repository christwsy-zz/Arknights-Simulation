using ArknightsSimulationCore.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArknightsSimulationCore.Base
{
    public abstract class AbstractGameAction : IGameActionable
    {
        public enum ActionType
        {
            [Description("部署")]
            Deploy,
            [Description("重新部署")]
            Redeploy,
            [Description("撤退")]
            Retract,
            [Description("击杀")]
            Destroyed
        }
        ActionType action;
        int timing;

        public void performAction()
        {
            throw new NotImplementedException();
        }
    }
}
