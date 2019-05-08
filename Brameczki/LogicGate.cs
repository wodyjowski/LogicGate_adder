using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brameczki
{

    public class LogicGateBase
    {
        protected GateType type;

        protected bool input1;
        protected bool input2;

        public virtual bool GetResult()
        {
            switch (type)
            {
                case GateType.AND:
                    return input1 & input2;
                case GateType.OR:
                    return input1 | input2;
                case GateType.XOR:
                    return input1 ^ input2;
                default:
                    throw new InvalidOperationException("WTF");
            }
        }
    }


    public class LogicGate : LogicGateBase
    {
        public LogicGateBase Input1 { get; set; }
        public LogicGateBase Input2 { get; set; }


        public LogicGate(GateType type)
        {
            this.type = type;
        }

        public override bool GetResult()
        {
            input1 = Input1.GetResult();
            input2 = Input2.GetResult();

            return base.GetResult();
        }
    }

    public class LogicGateInput : LogicGateBase
    {
        public bool Input1 { get; set; }
        public bool Input2 { get; set; }
        public LogicGateInput(GateType type)
        {
            this.type = type;
        }

        public override bool GetResult()
        {
            input1 = Input1;
            input2 = Input2;

            return base.GetResult();
        }
    }

    public class LogitGateHybrid : LogicGateBase
    {
        public bool Input1 { get; set; }
        public LogicGateBase Input2 { get; set; }
        public LogitGateHybrid(GateType type)
        {
            this.type = type;
        }

        public override bool GetResult()
        {
            input1 = Input1;
            input2 = Input2.GetResult();

            return base.GetResult();
        }
    }


    public enum GateType
    {
        AND,
        OR,
        XOR
    }


}
