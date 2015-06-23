using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S22MatthijsvanderBoonLivePerformance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Database.Database database = new Database.Database();

            if (database.Connect())
            {
                MessageBox.Show("Succes");
                database.Close();
            }
            else
            {
                MessageBox.Show("Faal");
            }
        }
    }
}
