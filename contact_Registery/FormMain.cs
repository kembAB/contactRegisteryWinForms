using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contact_Registery
{
    public partial class FormMain : Form
    {
        private ContactManager m_conactMngr;
        public FormMain()
        {
            InitializeComponent();
            //instance of contact Registery
            m_conactMngr = new ContactManager();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
         
            cmbCountry.Items.AddRange(Enum.GetNames(typeof(Countries)));
            cmbCountry.SelectedIndex = (int)Countries.Sverige;
          //  m_conactMngr.TestValues();
            UpdateGUI();

           
            InitializeInputControls();
        }
       
        private bool ReadInput()
        {
            //Read the input by the user 
            Contact contact = new Contact();
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
          
            Address address = ReadAddress();
            contact.AddressData = address;
            bool ok = false;
            if (!string.IsNullOrEmpty(txtFirstName.Text)&&!string.IsNullOrEmpty(txtLastName.Text))
            {
                ok = true ;
                m_conactMngr.AddContact(contact);
            }
            else
            {
                string strMessage = "First name Last Name and city are required.";
                MessageBox.Show(strMessage);
            }
           
            return ok;
        }
        private bool ReadName()
        {
            return true;
        }
        // Read addresss
        private Address ReadAddress()
        {
            Address add = new Address();
            add.Streets = txtStreet.Text;
            add.Cities = txtCity.Text;
            add.ZipCodes = txtZipCode.Text;
            add.Country = (Countries)cmbCountry.SelectedIndex;
            return add;
            
        }


        private void InitializeInputControls()
        {

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            txtCity.Text = string.Empty;

        }
        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Countries selectedCountry = (Countries)Enum.Parse(typeof(Countries), cmbCountry.SelectedItem.ToString());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
       

        private void lstContactRegistery_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
             UpdateContactInfoFormRegistry();
          
        }
        private void UpdateContactInfoFormRegistry()
        {
            int index = lstContactRegistery.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Contact contact = m_conactMngr.GetContact(index);
            cmbCountry.SelectedIndex = (int)contact.AddressData.Country;
            txtFirstName.Text = contact.FirstName;
            txtLastName.Text = contact.LastName;
            

        }
  
        private void UpdateGUI()
        {
            string[] strContacts = m_conactMngr.GetContactInfo();
            if (strContacts != null)
            {
                lstContactRegistery.Items.Clear();
                lstContactRegistery.Items.AddRange(strContacts);
                lblRegisteredRecords.Text = lstContactRegistery.Items.Count.ToString();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
           //read and update the listbox as well as the list 
              if (ReadInput() == true)
               {
                   UpdateGUI();
               }
           

       
        }
        
        private void btnChange_Click(object sender, EventArgs e)
        {
       
            // the index of the listbox selected item
            int index = lstContactRegistery.SelectedIndex;
            
               
            if (index >= 0)
            {





                //Read the input by the user 
                Contact contact = new Contact();
                contact.FirstName = txtFirstName.Text;
                contact.LastName = txtLastName.Text;

                Address address = ReadAddress();
                contact.AddressData = address;
                if (!string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text))
                {
                    bool updatedlist = false;

                    //remove the contact from the listbox
                    lstContactRegistery.Items.RemoveAt(index);

                    //update the list collection
                    updatedlist = m_conactMngr.ChangeContact(contact);
                    //add the contact to the listbox after removal of the previous
                    lstContactRegistery.Items.Insert(index, contact.ToString());
                }
                else
                {
                    string strMessage = "First name Last Name and city are required.";
                    MessageBox.Show(strMessage);
                }

              
               
                   


               
            }
            else
                MessageBox.Show("Select an item from the ListBox!", "Error");

            InitializeInputControls();
            btnAdd.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstContactRegistery.SelectedIndex >= 0)
            {
                DialogResult dlg = MessageBox.Show("Sure to delete?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == DialogResult.Yes)
                {
                    int index = lstContactRegistery.SelectedIndex;
                    if (index >= 0)
                    {
                       
                       //first get the contact to delete
                        Contact contact = m_conactMngr.GetContact(index);
                        //delete contact from the list
                        m_conactMngr.DeleteContact(index);
                            //delete contact from the listbox
                        lstContactRegistery.Items.RemoveAt(index);
                        
                        
                    }
                    //update the count on the form label
                    lblRegisteredRecords.Text = lstContactRegistery.Items.Count.ToString();
                }
            }
            else
            {
                
                MessageBox.Show("no element to delete selected", "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            InitializeInputControls();
           
        }
    }
}
