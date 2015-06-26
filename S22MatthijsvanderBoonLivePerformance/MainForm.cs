using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S22MatthijsvanderBoonLivePerformance.Controller;
using S22MatthijsvanderBoonLivePerformance.Models;

namespace S22MatthijsvanderBoonLivePerformance
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            tabPage1.Text = "Missie";
            tabPage2.Text = "Beheer";

            MissieController controller = new MissieController();
            lbMissions.DataSource = controller.SearchAllMissions();
        }

        private void btnSIN_Click(object sender, EventArgs e)
        {
            NewSIN newSin = new NewSIN();
            newSin.ShowDialog();
        }

        private void btnHOPE_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Verwijder de geselecteerde missie
            Missie missie = lbMissions.SelectedItem as Missie;
            MissieController controller = new MissieController();
            controller.DeleteMission(missie);
            lbMissions.DataSource = controller.SearchAllMissions();
        }
    }
}
