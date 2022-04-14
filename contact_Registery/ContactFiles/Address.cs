using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contact_Registery
{
    public class Address
    {
        private Countries country;//from enum Countries
        private string street;
        private string city;
        private string zipcode;
        public Address():
            this(string.Empty,string.Empty,"Malmö")
        {

        }
        public Address(Address theOther )
            
        {
            street = theOther.street;
            city = theOther.city;
            zipcode = theOther.zipcode;

        }
        public Address(string street, string zip, string city) :

            this(street, zip, city, Countries.Sverige)
        {

        }
        public Address(string street, string zip, string city, Countries country)
        {

        }
    
        public void DefaultValues()
        {
            //foreach variables on the form assign default value




        }
        public Countries Country
        {
            //countries enum property to return a selected country from the combobox
            get
            {
                return (Countries.Sverige == country) ? Countries.Sverige : country;
            }
            set
            {

                country = (Countries)value;
            }

        }

        public string Streets
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }
        public string ZipCodes
        {
            get
            {
                return zipcode;
            }
            set
            {
                zipcode = value;
            }
        }
        public string Cities
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public string GetCountryString()
        {
            //deletes underscore from country name in combobox
            string strCountry = country.ToString();
            strCountry= strCountry.Replace("_","");
            return strCountry;



        }
        public override string ToString()
        {
            string strOut = string.Format("{0,-25}{1,-8}{2,-10}{3}",street,zipcode,city,GetCountryString());
            return strOut;
        }
    }
}
