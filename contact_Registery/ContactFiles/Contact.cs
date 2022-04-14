using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contact_Registery
{
    public class Contact
    {
        //name strings initialization 
        private string m_fisrstName = string.Empty;
        private string m_lastName = string.Empty;
        //"has a "relation with address
        private Address m_address;
        public Contact()
        {
            // create address objec (m_address)
            m_address = new Address();

        }
        public Contact(string firstName,string lastName,Address adr):this()
            
        {
            

            m_lastName = firstName;
            m_lastName = lastName;

        }
        public Contact(Contact theOther)
        {
            this.m_fisrstName = theOther.m_fisrstName;
            this.m_lastName = theOther.m_lastName;
           //calling address constructor
            this.m_address = new Address(theOther.m_address);

        }
        
        public Address AddressData
        {
            // adress property 
            get
            {
                return m_address;

            }
            set
            {
                m_address = value;
            }
        }
        public string FirstName
        {
            get
            {
                return m_fisrstName;
            }
            set
            {
                m_fisrstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return m_lastName;
            }
            set
            {
                m_lastName = value;
            }
        }
        public string FullName
        {
            get
            {
               return m_lastName+","+ m_fisrstName ;
               
            }
           
        }
        public bool validate()
        {
            //m_adress validation and check if the name is entered by user
            bool p_ok = true;
            //
            return p_ok;
        }
        public override string ToString()
        {
            string strOut = string.Format("{0,-20}{1}", FullName ,m_address.ToString());
            return strOut;
        }

    }
}
