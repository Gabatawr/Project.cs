using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Barber.Form1;

namespace Barber
{
    public partial class EditClientForm : Form
    {
        public EditClientForm() { InitializeComponent(); }
        private void btnClose_Click(object sender, EventArgs e) => Close();
        //---------------------------------------------------------------------
        ClientForm client;
        private void EditClientForm_Load(object sender, EventArgs e)
        {
            client = Owner as ClientForm;

            cbGender.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbGender.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbGender.Items.AddRange((client.Owner as Form1).Genders.Select<Gender, string>(g => g.Name).ToArray());

            tbSurName.Text = client.Clients[client.CurrentClientIndex].SurName;
            tbName.Text = client.Clients[client.CurrentClientIndex].Name;
            tbSecName.Text = client.Clients[client.CurrentClientIndex].SecName;
            cbGender.Text = (client.Owner as Form1).Genders.Where<Gender>(g => g.Id == client.Clients[client.CurrentClientIndex].GenderId).First().Name;
            tbPhone.Text = client.Clients[client.CurrentClientIndex].Phone;
            tbEmail.Text = client.Clients[client.CurrentClientIndex].Email;

        }
        //---------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            int genderid;
            if (cbGender.Items.Contains(cbGender.Text))
                genderid = (client.Owner as Form1).Genders.Where<Gender>(g => g.Name == cbGender.Text).Select<Gender, int>(g => g.Id).First();
            else
            {
                MessageBox.Show("Incorrect Gender!");
                return;
            }

            string surname;
            if (tbSurName.Text != string.Empty)
                surname = tbSurName.Text;
            else
            {
                MessageBox.Show("SurName is empty!");
                return;
            }

            string name;
            if (tbName.Text != string.Empty)
                name = tbName.Text;
            else
            {
                MessageBox.Show("Name is empty!");
                return;
            }

            string secname;
            if (tbSecName.Text != string.Empty)
                secname = tbSecName.Text;
            else
            {
                MessageBox.Show("SecName is empty!");
                return;
            }

            string phone;
            if (tbPhone.Text != string.Empty)
                phone = tbPhone.Text;
            else
            {
                MessageBox.Show("Phone is empty!");
                return;
            }

            string email;
            if (tbEmail.Text != string.Empty)
                email = tbEmail.Text;
            else
            {
                MessageBox.Show("Email is empty!");
                return;
            }
            //---------------------------------------------------------------------
            SqlCommand cmd = new($"update [Clients] set SurName = N'{surname}', Name = N'{name}', SecName = N'{secname}', GenderId = {genderid}, Phone = N'{phone}', Email = N'{email}' where Id = {client.Clients[client.CurrentClientIndex].Id}",
                                 client.Connection
            );
            cmd.ExecuteNonQuery();
            //---------------------------------------------------------------------
            client.Clients[client.CurrentClientIndex].SurName = surname;
            client.Clients[client.CurrentClientIndex].Name = name;
            client.Clients[client.CurrentClientIndex].SecName = secname;
            client.Clients[client.CurrentClientIndex].GenderId = genderid;
            client.Clients[client.CurrentClientIndex].Phone = phone;
            client.Clients[client.CurrentClientIndex].Email = email;
            //---------------------------------------------------------------------
            MessageBox.Show("Client Edited!");
            Close();
        }
    }
}
