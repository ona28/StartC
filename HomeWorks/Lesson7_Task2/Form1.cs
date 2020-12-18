using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7_Task2
{
    public partial class Form1 : Form, IForm
    {
        public string Message { set => this.lblMsg.Text = value; }
        public string Counter { set => this.lblCount.Text = value; }
        public int Unknown 
        {
            set => this.tbAswer.Text = value.ToString();
            get => Int32.Parse(this.tbAswer.Text); 
        }        

        Game game;

        public Form1()
        {
            InitializeComponent();
            game = new Game(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game.Start();
        }
        
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            game.Start();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            game.Check();
        }
    }
}
