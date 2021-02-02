using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static Barber.Form1;

namespace Barber
{
    public sealed class EditClientForm : AddClientForm
    {
        private Client currentClient;
        //---------------------------------------------------------------------
        override protected void FormLoadHandler() => Load += EditClientForm_Load;
        public EditClientForm() : base("EditClientForm") {}
        //---------------------------------------------------------------------
        private void EditClientForm_Load(object sender, EventArgs e)
        {
            Base_Load();

            currentClient = clientForm.Clients[clientForm.CurrentClientIndex];
            cbGender.Text = (clientForm.Owner as Form1).Genders
                .Where<Gender>(g => g.Id == currentClient.GenderId)
                .First().Name;

            tbSurName.Text = currentClient.SurName;
            tbName.Text = currentClient.Name;
            tbSecName.Text = currentClient.SecName;
            tbPhone.Text = currentClient.Phone;
            tbEmail.Text = currentClient.Email;
        }
        //---------------------------------------------------------------------
        override protected void Save(Client c)
        {
            SqlCommand cmd = new($"update [Clients] set SurName = N'{c.SurName}', Name = N'{c.Name}', SecName = N'{c.SecName}', GenderId = {c.GenderId}, Phone = N'{c.Phone}', Email = N'{c.Email}' where Id = {currentClient.Id}",
                                 clientForm.Connection
            );
            cmd.ExecuteNonQuery();

            currentClient.SurName = c.SurName;
            currentClient.Name = c.Name;
            currentClient.SecName = c.SecName;
            currentClient.GenderId = c.GenderId;
            currentClient.Phone = c.Phone;
            currentClient.Email = c.Email;
        }
    }
}
