using AnyCompany.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.VAT
{
   public  interface IVatService
    {
        double GetVatRate(string  country);
    }
}
