using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using static Barber.Form1;

namespace Barber
{
    public partial class ClientForm : Form
    {
        public ClientForm() { InitializeComponent(); }
        private void btnClose_Click(object sender, EventArgs e) => Close();
        //---------------------------------------------------------------------
        public SqlConnection Connection { get; private set; }
        public SqlDataAdapter Adapter { get; private set; }
        public DataSet Dataset { get; private set; }
        //---------------------------------------------------------------------
        private void ClientForm_Load(object sender, EventArgs e)
        {
            Connection = (Owner as Form1).Connection;

            SqlCommand cmd = new(@"select Id, SurName, Name, SecName, GenderId, Phone, Email from [Clients]", Connection);
            SqlDataReader reader = cmd.ExecuteReader();

            Clients = new();
            while (reader.Read())
            {
                Clients.Add(new Client()
                {
                    Id = reader.GetInt32(0), //reader["Id"]
                    SurName = reader.GetString(1),
                    Name = reader.GetString(2),
                    SecName = reader.GetString(3),
                    GenderId = reader.GetInt32(4),
                    Phone = reader.GetString(5),
                    Email = reader.GetString(6)
                });
            }
            reader.Close();

            int n = Clients.Count();
            lbCount.Text = n.ToString();

            if (n > 0)
            {
                CurrentClientIndex = 0;
                ShowClient();
            }
        }
        //---------------------------------------------------------------------
        private void bntPrev_Click(object sender, EventArgs e)
        {
            if (CurrentClientIndex - 1 >= 0)
            {
                CurrentClientIndex--;
                btnNext.Enabled = true;
                if (CurrentClientIndex - 1 < 0)
                    btnPrev.Enabled = false;
                ShowClient();
            }
            else
                btnPrev.Enabled = false;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentClientIndex + 1 < Clients.Count())
            {
                CurrentClientIndex++;
                btnPrev.Enabled = true;
                if (CurrentClientIndex + 1 == Clients.Count())
                    btnNext.Enabled = false;
                ShowClient();
            }
            else
                btnNext.Enabled = false;
        }
        //---------------------------------------------------------------------
        public List<Client> Clients;
        public int CurrentClientIndex;
        //---------------------------------------------------------------------
        public void ShowClient()
        {
            Client c = Clients[CurrentClientIndex];

            lbId.Text = c.Id.ToString();
            lbSurName.Text = c.SurName;
            lbName.Text = c.Name;
            lbSecName.Text = c.SecName;
            lbGender.Text = c.GenderId.ToString();
            lbGenderName.Text = (Owner as Form1).Genders.Where<Gender>(g => g.Id == c.GenderId).First().Name;
            toolTip1.SetToolTip(lbGenderName, (Owner as Form1).Genders.Where<Gender>(g => g.Id == c.GenderId).First().Description);
            lbPhone.Text = c.Phone;
            lbEmail.Text = c.Email;
        }
        //----------------------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClientForm addClient = new();
            addClient.ShowDialog(this);

            ShowClient();
            lbCount.Text = Clients.Count.ToString();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditClientForm editClient = new();
            editClient.ShowDialog(this);

            ShowClient();
            lbCount.Text = Clients.Count.ToString();
        }
        //----------------------------------------------------------------------
    }
    public class Client
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string SecName { get; set; }
        public int GenderId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
