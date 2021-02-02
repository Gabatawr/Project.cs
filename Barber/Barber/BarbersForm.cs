using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Barber
{
    public partial class BarbersForm : Form
    {
        public BarbersForm() => InitializeComponent();
        private void btnClose_Click(object sender, EventArgs e) => Close();
        //---------------------------------------------------------------------
        public SqlConnection Connection { get; private set; }
        public SqlDataAdapter Adapter { get; private set; }
        public DataSet Dataset { get; private set; }
        //---------------------------------------------------------------------
        private void Barbers_Load(object sender, EventArgs e)
        {
            Connection = (Owner as Form1).Connection;

            SqlCommand cmd = new(@"select * from [Barbers]", Connection);
            Adapter = new(cmd);
            SqlCommandBuilder cmds = new(Adapter);

            Dataset = new();

            Adapter.Fill(Dataset);

            DataTable table = Dataset.Tables[0];
            table.Columns["Id"].ReadOnly = true;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.DataSource = table;
        }
        //---------------------------------------------------------------------
        private void bntSave_Click(object sender, EventArgs e)
        {
            try
            {
                Adapter.Update(Dataset);
                MessageBox.Show("Saved");
            }
            catch (Exception) { MessageBox.Show("OMG!"); }
        }
    }
}
