using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LogicGateAdder
{
    class Circuit
    {
        public BigInteger Input1 { get; set; }
        public BigInteger Input2 { get; set; }


        private List<Adder> AdderList = new List<Adder>();

        public Circuit(int numberOfAdders)
        {
            for (int i = 0; i < numberOfAdders; i++)
            {
                AdderList.Add(new Adder());
            }
        }

        public BigInteger Sum()
        {
            for (int i = 0; i < AdderList.Count; i++)
            {
                AdderList[i].Input1 = ((Input1 >> i) & 1) == 1;
                AdderList[i].Input2 = ((Input2 >> i) & 1) == 1;
            }

            BigInteger result = new BigInteger();

            for (int i = 0; i < AdderList.Count; i++)
            {
                if(i > 0)
                {
                    AdderList[i].Transfer = AdderList[i - 1].TransferOut;
                }

                result += new BigInteger(AdderList[i].Add() ? 1 : 0) << i;
            }

            return result;
        }


    }
}
