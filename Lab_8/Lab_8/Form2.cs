using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public Form2(Form1 f)
        {
            InitializeComponent();
            f1 = f;

            int size = buttons();
            string animal = animal_type();
            //string chosen_button = bind(size);
            //button_Click();
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
        public string bind(int size)
        {
            Random rnd = new Random();
            string name = "";

            int index_i = rnd.Next(0, size + 1);
            int index_j = rnd.Next(0, size + 1);

            Button b = new Button();
            b.Name = string.Format("button_{0}{1}", index_i, index_j);

            foreach (Button button in this.Controls.OfType<Button>())
            {
                if(button.Name == b.Name)
                {
                    name = button.Name;
                    MessageBox.Show(name);
                   b.Dispose();
                }
            }
            return name;

        }

        public int buttons()
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

                    string chosen_button = bind(size);

                    button.Click += new EventHandler(this.button_Click);
                }
            }
            return size;

        }


        public void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Name + "Clicked");
        }

    }
}
