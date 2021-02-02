using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static Barber.Form1;

namespace Barber
{
    public partial class AddClientForm : Form
    {
        protected ClientForm client;
        //---------------------------------------------------------------------
        virtual protected void FormLoadHandler() => Load += AddClientForm_Load;
        public AddClientForm(string title = "AddClientForm")
        {
            InitializeComponent();

            Name = title;
            Text = title;

            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;

            FormLoadHandler();
        }
        protected void btnClose_Click(object sender, EventArgs e) => Close();
        //---------------------------------------------------------------------
        protected void Base_Load()
        {
            client = Owner as ClientForm;

            cbGender.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbGender.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbGender.Items.AddRange((client.Owner as Form1).Genders
                .Select<Gender, string>(g => g.Name)
                .ToArray());
        }
        private void AddClientForm_Load(object sender, EventArgs e) => Base_Load();
        //---------------------------------------------------------------------
        protected bool Check(Client c)
        {
            if (cbGender.Items.Contains(cbGender.Text))
                c.GenderId = (client.Owner as Form1).Genders.Where<Gender>(g => g.Name == cbGender.Text).Select<Gender, int>(g => g.Id).First();
            else
            {
                MessageBox.Show("Incorrect Gender!");
                return false;
            }

            if (tbSurName.Text != string.Empty)
                c.SurName = tbSurName.Text;
            else
            {
                MessageBox.Show("SurName is empty!");
                return false;
            }

            if (tbName.Text != string.Empty)
                c.Name = tbName.Text;
            else
            {
                MessageBox.Show("Name is empty!");
                return false;
            }

            if (tbSecName.Text != string.Empty)
                c.SecName = tbSecName.Text;
            else
            {
                MessageBox.Show("SecName is empty!");
                return false;
            }

            if (tbPhone.Text != string.Empty)
                c.Phone = tbPhone.Text;
            else
            {
                MessageBox.Show("Phone is empty!");
                return false;
            }

            if (tbEmail.Text != string.Empty)
                c.Email = tbEmail.Text;
            else
            {
                MessageBox.Show("Email is empty!");
                return false;
            }

            return true;
        }
        virtual protected void Save(Client c)
        {
            SqlCommand cmd = new($"insert into [Clients] (SurName, Name, SecName, GenderId, Phone, Email) values (N'{c.SurName}', N'{c.Name}', N'{c.SecName}', {c.GenderId}, N'{c.Phone}', N'{c.Email}')",
                                 client.Connection
            );
            cmd.ExecuteNonQuery();

            cmd.CommandText = $"select max(Id) from [Clients]";
            c.Id = (int)cmd.ExecuteScalar();
            client.Clients.Add(c);

            client.CurrentClientIndex = client.Clients.Count - 1;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Client c = new();

            if (Check(c))
            {
                Save(c);
                MessageBox.Show("Done!");
                Close();
            }
        }
    }
}
