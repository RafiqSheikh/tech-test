using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany.Types;

namespace AnyCompany.VAT
{
    public class VatService : IVatService
    {
        public double GetVatRate(string  country)
        {
            IVatRate vatRate = GetVatObject(country );
            
            return vatRate.GetVatRate();
        }

        private IVatRate GetVatObject(string countryString)
        {
            Country country;
            try
            {
                country = Helper.ParseEnum<Country>(countryString);
            }
            catch (Exception ex)
            {
                country =  Country.Other;
            }


            switch (country)
            {
                case Country.UK:
                    return new VatRateUK();
                default:
                    return new VatRateOther();
            }
        }
    }
}
