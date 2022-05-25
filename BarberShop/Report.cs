using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop
{
    public static class Report
    {
        public static double GetPay(List<double>ListZP)
        {
            return  (ListZP.Sum() * 0.3) * 0.87;
        }
    }
}
