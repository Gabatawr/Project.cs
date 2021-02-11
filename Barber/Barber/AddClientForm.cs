using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Barber.Form1;

namespace Barber
{
    public partial class AddClientForm : Form
    {
        protected ClientForm clientForm;
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
            clientForm = Owner as ClientForm;

            cbGender.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbGender.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbGender.Items.AddRange
            (
                (clientForm.Owner as Form1).Genders
                                           .Select(g => g.Name)
                                           .ToArray()
            );
            
            cbGender.DrawMode = DrawMode.OwnerDrawFixed;
            cbGender.DrawItem += cbGender_DrawItem;
            cbGender.DropDownClosed += cbGender_DropDownClosed;
        }
        //---------------------------------------------------------------------
        private ToolTip ttGenderDescription = new ToolTip();
        private void cbGender_DropDownClosed(object sender, EventArgs e)
            => ttGenderDescription.Hide(cbGender);
        private void cbGender_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string text = cbGender.Items[e.Index].ToString();
            string hint = (clientForm.Owner as Form1).Genders
                                                     .Where(g => g.Name == text)
                                                     .Select(g => g.Description)
                                                     .First();
            
            e.DrawBackground();
            {
                using (SolidBrush br = new SolidBrush(e.ForeColor))
                    e.Graphics.DrawString(text, e.Font, br, e.Bounds);

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    ttGenderDescription.Show(hint, cbGender, e.Bounds.Right, e.Bounds.Bottom);
            }
            e.DrawFocusRectangle();
        }
        //---------------------------------------------------------------------
        private void AddClientForm_Load(object sender, EventArgs e) => Base_Load();
        //---------------------------------------------------------------------
        protected bool Check(Client c)
        {
            if (cbGender.Items.Contains(cbGender.Text))
                c.GenderId = (clientForm.Owner as Form1).Genders
                    .Where<Gender>(g => g.Name == cbGender.Text)
                    .Select<Gender, int>(g => g.Id)
                    .First();
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
                                 clientForm.Connection
            );
            cmd.ExecuteNonQuery();

            cmd.CommandText = $"select max(Id) from [Clients]";
            c.Id = (int)cmd.ExecuteScalar();
            clientForm.Clients.Add(c);

            clientForm.CurrentClientIndex = clientForm.Clients.Count - 1;
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
