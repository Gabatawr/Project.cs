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
    public partial class AddClientForm : Form
    {
        public AddClientForm() { InitializeComponent(); }
        private void btnClose_Click(object sender, EventArgs e) => Close();
        //---------------------------------------------------------------------
        ClientForm client;
        private void AddClientForm_Load(object sender, EventArgs e)
        {
            client = Owner as ClientForm;

            cbGender.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbGender.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbGender.Items.AddRange((client.Owner as Form1).Genders.Select<Gender, string>(g => g.Name).ToArray());
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
            if (tbSurName.Text != string.Empty) surname = tbSurName.Text;
            else
            {
                MessageBox.Show("SurName is empty!");
                return;
            }

            string name;
            if (tbName.Text != string.Empty) name = tbName.Text;
            else
            {
                MessageBox.Show("Name is empty!");
                return;
            }

            string secname;
            if (tbSecName.Text != string.Empty) secname = tbSecName.Text;
            else
            {
                MessageBox.Show("SecName is empty!");
                return;
            }

            string phone;
            if (tbPhone.Text != string.Empty) phone = tbPhone.Text;
            else
            {
                MessageBox.Show("Phone is empty!");
                return;
            }

            string email;
            if (tbEmail.Text != string.Empty) email = tbEmail.Text;
            else
            {
                MessageBox.Show("Email is empty!");
                return;
            }
            //---------------------------------------------------------------------
            SqlCommand cmd = new($"insert into [Clients] (SurName, Name, SecName, GenderId, Phone, Email) values (N'{surname}', N'{name}', N'{secname}', {genderid}, N'{phone}', N'{email}')",
                                 client.Connection
            );
            cmd.ExecuteNonQuery();
            //---------------------------------------------------------------------
            cmd.CommandText = $"select max(Id) from [Clients]";
            client.Clients.Add(new Client
            {
                Id = (int)cmd.ExecuteScalar(),
                SurName = surname,
                Name = name,
                SecName = secname,
                GenderId = genderid,
                Phone = phone,
                Email = email
            });

            client.CurrentClientIndex = client.Clients.Count - 1;
            //---------------------------------------------------------------------
            MessageBox.Show("Client Added");
            Close();
        }
    }
}
