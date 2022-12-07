using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab_8
{
    public partial class Form2 : Form
    {
        public Form1 f1;
        public string chosen_button = "";
        public string animal = "";
        private int counter = 3;

        public Form2(Form1 f)
        {
            InitializeComponent();
            f1 = f;

            animal = animal_type();
            buttons();
            
        }

        public string animal_type()
        {
            int index = f1.comboBox1.SelectedIndex;
            string animal = "";

            if (index == 0)
                animal = "croc";
            else if (index == 1)
                animal = "squirrel";
            else if (index == 2)
                animal = "monkey";
            else
                MessageBox.Show("wybierz typ zwierzęcia");

            return animal;
        }
        public string rand(int size)
        {
            Random rnd = new Random();
            string name = "";


            int index_i = rnd.Next(0, size);
            int index_j = rnd.Next(0, size);

            name = string.Format("button_{0}{1}", index_i, index_j);

            return name;
        }

        public void buttons()
        {
            int size = 0;

            int index = f1.comboBox2.SelectedIndex;
            if (index == 0)
                size = 3;
            else if (index == 1)
                size = 4;
            else if (index == 2)
                size = 5;
            else
                MessageBox.Show("wybierz rozmiar planszy");

            chosen_button = rand(size);


            this.tableLayoutPanel1.ColumnCount = size;
            this.tableLayoutPanel1.RowCount = size;

            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < size; i++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / size));
            }
            for (int i = 0; i < size; i++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / size));
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    Button button = new Button();
                    button.Name = string.Format("button_{0}{1}", i, j);
                    button.Dock = DockStyle.Fill;
                    this.tableLayoutPanel1.Controls.Add(button, j, i);

                    button.Click += new EventHandler(button_Click);
                    timer1.Start();
                }
            }

        }


        public void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Name == chosen_button && animal == "croc")
            {
                counter = -1;
                timer1.Dispose();

                List<string> list = new List<string>(new string[] { "Zostałeś zjedzony!\nPrzegrałeś!", "*********************************\n\tWygrałeś!\t\n*********************************" }) ;
                Random rnd = new Random();
                int r = rnd.Next(list.Count);

                if(r == 0)
                {
                    button.Image = Resource1.angry_croc;

                } else if (r == 1) 
                {
                    button.Image = Resource1.happy_croc;
                }

                button.BackgroundImageLayout = ImageLayout.Stretch;

                MessageBox.Show((string)list[r]);
                this.Close();

            }
            else if(button.Name == chosen_button && animal != "croc")
            {
                counter = -1;
                timer1.Dispose();

                if(animal == "squirrel")
                    button.Image = Resource1.squirrel; 
                else if(animal =="monkey")
                    button.Image = Resource1.monkey;

                button.BackgroundImageLayout = ImageLayout.Stretch;

                MessageBox.Show("*********************************\n\tWygrałeś!\t\n*********************************");
                this.Close();

            }
            else
            {
                button.Dispose();
            }

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                MessageBox.Show("\tSkończył się czas\t\n\tPrzegrałeś!\t");
                this.Close();
            }
                
        }
    }
}
