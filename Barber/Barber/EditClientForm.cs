using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Barber.Form1;

namespace Barber
{
    public partial class EditClientForm : AddClientForm
    {
        override protected void FormLoadHandler()
        {
            Load += EditClientForm_Load;
        }
        public EditClientForm() : base("EditClientForm") { }
        //---------------------------------------------------------------------
        private string oldGender;
        protected void EditClientForm_Load(object sender, EventArgs e)
        {
            Base_Load();

            oldGender = (client.Owner as Form1).Genders.Where<Gender>(g => g.Id == client.Clients[client.CurrentClientIndex].GenderId).First().Name;

            tbSurName.Text = client.Clients[client.CurrentClientIndex].SurName;
            tbName.Text = client.Clients[client.CurrentClientIndex].Name;
            tbSecName.Text = client.Clients[client.CurrentClientIndex].SecName;
            cbGender.Text = oldGender;
            tbPhone.Text = client.Clients[client.CurrentClientIndex].Phone;
            tbEmail.Text = client.Clients[client.CurrentClientIndex].Email;
        }
        //---------------------------------------------------------------------
        override protected bool Check(Client c)
        {
            bool isEqual = tbSurName.Text == client.Clients[client.CurrentClientIndex].SurName
                           && tbName.Text == client.Clients[client.CurrentClientIndex].Name
                           && tbSecName.Text == client.Clients[client.CurrentClientIndex].SecName
                           && cbGender.Text == oldGender
                           && tbPhone.Text == client.Clients[client.CurrentClientIndex].Phone
                           && tbEmail.Text == client.Clients[client.CurrentClientIndex].Email;
            if (isEqual)
                return false;
            else
                return base.Check(c);
        }
        override protected void Save(Client c)
        {
            SqlCommand cmd = new($"update [Clients] set SurName = N'{c.SurName}', Name = N'{c.Name}', SecName = N'{c.SecName}', GenderId = {c.GenderId}, Phone = N'{c.Phone}', Email = N'{c.Email}' where Id = {client.Clients[client.CurrentClientIndex].Id}",
                                 client.Connection
            );
            cmd.ExecuteNonQuery();
            //---------------------------------------------------------------------
            client.Clients[client.CurrentClientIndex].SurName = c.SurName;
            client.Clients[client.CurrentClientIndex].Name = c.Name;
            client.Clients[client.CurrentClientIndex].SecName = c.SecName;
            client.Clients[client.CurrentClientIndex].GenderId = c.GenderId;
            client.Clients[client.CurrentClientIndex].Phone = c.Phone;
            client.Clients[client.CurrentClientIndex].Email = c.Email;
        }
    }
}
