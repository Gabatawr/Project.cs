using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barber
{
    public partial class GendersForm : Form
    {
        public GendersForm() { InitializeComponent(); }
        private void btnClose_Click(object sender, EventArgs e) => Close();
        //---------------------------------------------------------------------
        public SqlConnection Connection { get; private set; }
        public SqlDataAdapter Adapter { get; private set; }
        public DataSet Dataset { get; private set; }
        //---------------------------------------------------------------------
        private void Genders_Load(object sender, EventArgs e)
        {
            Connection = (Owner as Form1).Connection;

            SqlCommand cmd = new(@"select * from [Gender]", Connection);
            Adapter = new(cmd);
            Dataset = new();

            Adapter.Fill(Dataset);

            DataTable table = Dataset.Tables[0];
            table.Columns["Id"].ReadOnly = true;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DataSource = table;
        }
    }
}
