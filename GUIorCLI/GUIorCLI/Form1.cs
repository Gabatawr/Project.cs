using System;
using System.Windows.Forms;

namespace GUIorCLI
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        
        private void btnConsole_Click(object sender, EventArgs e) => CLI.Run();
    }
}
