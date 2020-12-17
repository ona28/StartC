using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lesson7_Task1.GameFolder;

namespace Lesson7_Task1
{
    public partial class MainForm : Form, IView
    {
        public string Number { set => this.lblView.Text = value; }
        public string Counter { set => this.lblCount.Text = value; }       
        public string StartNumber { set => this.lblStart.Text = value; }
        public bool BackEnable { set => this.btnBack.Enabled = value; }

        Game game;
        
        public MainForm()
        {
            InitializeComponent();
            game = new Game(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            game.Start();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            game.Plus();
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            game.Mult();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            game.Clear();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            game.Clear();
            game.Start();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            game.Back();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
