using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGateAdder
{
    class Adder
    {
        public bool Input1 { get; set; }
        public bool Input2 { get; set; }
        public bool Output { get; set; }
        public bool Transfer { get; set; }
        public bool TransferOut { get; set; }

        private LogicGateInput g1 = new LogicGateInput(GateType.XOR);
        private LogicGateInput g2 = new LogicGateInput(GateType.AND);
        private LogitGateHybrid g3 = new LogitGateHybrid(GateType.XOR);
        private LogitGateHybrid g4 = new LogitGateHybrid(GateType.AND);
        private LogicGate g5 = new LogicGate(GateType.OR);

        public Adder()
        {
            g3.Input2 = g1;
            g4.Input2 = g1;

            g5.Input1 = g4;
            g5.Input2 = g2;   
        }

        public bool Add()
        {
            g1.Input1 = Input1;
            g1.Input2 = Input2;
            g2.Input1 = Input1;
            g2.Input2 = Input2;

            g3.Input1 = Transfer;
            g4.Input1 = Transfer;


            TransferOut = g5.GetResult();

            return g3.GetResult();
        }


    }
}
