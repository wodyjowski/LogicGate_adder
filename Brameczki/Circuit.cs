using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brameczki
{
    class Circuit
    {
        public int Input1 { get; set; }
        public int Input2 { get; set; }


        private List<Adder> AdderList = new List<Adder>();

        public Circuit(int numberOfAdders)
        {
            for (int i = 0; i < numberOfAdders; i++)
            {
                AdderList.Add(new Adder());
            }
        }

        public int Sum()
        {
            for (int i = 0; i < AdderList.Count; i++)
            {
                AdderList[i].Input1 = ((Input1 >> i) & 1) == 1;
                AdderList[i].Input2 = ((Input2 >> i) & 1) == 1;
            }

            int result = 0;

            for (int i = 0; i < AdderList.Count; i++)
            {
                if(i > 0)
                {
                    AdderList[i].Transfer = AdderList[i - 1].TransferOut;
                }

                result += (AdderList[i].Add() ? 1 : 0) << i;
            }

            return result;
        }


    }
}
