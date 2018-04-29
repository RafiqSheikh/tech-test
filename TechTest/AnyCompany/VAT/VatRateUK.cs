using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany.Types;

namespace AnyCompany.VAT
{
    class VatRateUK : IVatRate
    {
        public double GetVatRate()
        {
           return 0.2d;
        }
    }
}
