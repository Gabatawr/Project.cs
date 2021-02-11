using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Barber
{
    public partial class ClientForm : Form
    {
        public ClientForm() => InitializeComponent();
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
        public List<Client> Clients;
        public int CurrentClientIndex;
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
        public void ShowClient()
        {
            Client c = Clients[CurrentClientIndex];

            lbId.Text = c.Id.ToString();

            lbSurName.Text = c.SurName;
            lbName.Text = c.Name;
            lbSecName.Text = c.SecName;

            lbGender.Text = c.GenderId.ToString();
            lbGenderName.Text = (Owner as Form1).Genders
                .Where(g => g.Id == c.GenderId)
                .FirstOrDefault()?.Name ?? "Invalid gender!";
            toolTip1.SetToolTip(lbGenderName, (Owner as Form1).Genders
                .Where(g => g.Id == c.GenderId)
                .FirstOrDefault()?.Description ?? "Invalid gender!");

            lbPhone.Text = c.Phone;
            lbEmail.Text = c.Email;
        }
        //----------------------------------------------------------------------
        private enum TypeForm { Add, Edit }
        private void OpenForm(TypeForm type)
        {
            Form form = (type == TypeForm.Add ? new AddClientForm() : new EditClientForm());
            form.ShowDialog(this);

            ShowClient();
            lbCount.Text = Clients.Count.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e) => OpenForm(TypeForm.Add);
        private void btnEdit_Click(object sender, EventArgs e) => OpenForm(TypeForm.Edit);
        private void btnDel_Click(object sender, EventArgs e)
        {
            string msg = "Delete clietn: "
                         + Clients[CurrentClientIndex].SurName + ' '
                         + Clients[CurrentClientIndex].Name + ' '
                         + Clients[CurrentClientIndex].SecName + '?';

            if (MessageBox.Show(msg) == DialogResult.OK)
            {
                SqlCommand cmd = new($"delete from [Clients] where Id = {Clients[CurrentClientIndex].Id}",
                                 Connection
                );
                cmd.ExecuteNonQuery();

                bool last = CurrentClientIndex == Clients.Count - 1;
                Clients.Remove(Clients[CurrentClientIndex]);
                if (last)  CurrentClientIndex--;

                ShowClient();
            }
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

        public override string ToString()
        {
            return string.Join(' ', SurName, Name, SecName);
        }
    }
}
