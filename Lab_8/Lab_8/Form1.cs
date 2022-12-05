namespace Lab_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.ShowDialog();
        }
    }
}