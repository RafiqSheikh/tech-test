using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.VAT
{
    public class VatRateOther : IVatRate
    {
        public double GetVatRate()
        {
            return 0;
        }
    }
}
