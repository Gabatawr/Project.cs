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
            //Connection = (Owner as Form1).Connection;

            //SqlCommand cmd = new(@"select * from [Clients]", Connection);
            //Adapter = new(cmd);
            //SqlCommandBuilder cmds = new(Adapter);

            //Dataset = new();

            //Adapter.Fill(Dataset);

            //DataTable table = Dataset.Tables[0];
            //table.Columns["Id"].ReadOnly = true;

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dataGridView1.DataSource = table;
        }
        //----------------------------------------------------------------------
    }
}
