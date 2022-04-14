using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contact_Registery
{
    
    public class ContactManager
    {
        //object declaration
        private List<Contact> m_contactRegistry;
        public ContactManager()
        {
            m_contactRegistry = new List<Contact>();
        }
        public Contact GetContact(int index)
        {
            if (index < 0 || index >= m_contactRegistry.Count)
            {
                return null;
            }
            return m_contactRegistry[index];
        }


        public bool AddContact(string firstName, string lastName, Address addresIn)
        {
            return true;
        }
        public bool AddContact(Contact contactIn)
        {
          
            m_contactRegistry.Add(contactIn);
           
            return true;
        }
        public bool ChangeContact(Contact ContactIn)
        {
            for (int i = 0; i < m_contactRegistry.Count; i++)
            {
                if (ContactIn == m_contactRegistry[i])
                {
                    m_contactRegistry.Remove(m_contactRegistry[i]);
                    //m_contactRegistry.RemoveAt(i);
                   m_contactRegistry.Add(ContactIn);
                }
            }
            return true;
         
        }
        public bool DeleteContact(int index)
        {
            //delete from the list  
           for(int i=0;i< m_contactRegistry.Count; i++)
            {
                if (i == index)
                {
                    m_contactRegistry.RemoveAt(i);
                }
            }
            return true;
        }
    
        public string[] GetContactInfo()
        {
            string[] strInfoStrings = new string[m_contactRegistry.Count];
            int i = 0;
            foreach (Contact contactObj  in m_contactRegistry)
            {
                strInfoStrings[i++] = contactObj.ToString();

            }
          
            return strInfoStrings;
        }
    }
}
