namespace filmyeryknigr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tytul = textBox1.Text;
            string rezyser = textBox2.Text;
            string data = dateTimePicker1.Text;
            string aktor = textBox3.Text;
            if (tytul.Length != 0 && rezyser.Length != 0 && data.Length != 0 && aktor.Length != 0)
            {
                DodawanieDanych(tytul, rezyser, data, aktor);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Text = "";
            }
            else
            {
                string message = "WPROWADè WSZYSTKIE DANE";
                MessageBox.Show(message);

            }
        }

        private void usuÒWybraneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuwanieDanych();
            
        }

        private void DodawanieDanych(string tytul, string rezyser, string data, string aktor)
        {
            ListViewItem item = new ListViewItem(new string[] {tytul, rezyser, data, aktor});
            listView1.Items.Add(item);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OdczytZPliku();
        }

        private void UsuwanieDanych()
        {
            foreach(ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
            listView1.Refresh();
        }

        private string[] WierszeDoPliku()
        {
            string[] linie = new string[listView1.Items.Count];
            int i = 0;

            foreach(ListViewItem item in listView1.Items )
            {
                linie[i] = "";
                for(int k = 0; k<item.SubItems.Count; k++)    
                    linie[i] += item.SubItems[k].Text + "*";

                i++;
            }
            return linie;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] linie = WierszeDoPliku();

            File.WriteAllLines("filmy.txt", linie);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OdczytZPliku()
        {
            if (!File.Exists("filmy.txt"))
                return;

            string[] linie = File.ReadAllLines("filmy.txt");
            foreach(string linia in linie)
            {
                string[] temp = linia.Split('*');
                DodawanieDanych(temp[0], temp[1], temp[2], temp[3]);
            }
        }

        private void zAMIE—DANEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

            ZamianaDanych();
        }

        private void ZamianaDanych()
        {
            



        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                item.SubItems[0].Text = textBox1.Text;
                item.SubItems[1].Text = textBox3.Text;
                item.SubItems[2].Text = dateTimePicker1.Text;
                item.SubItems[3].Text = textBox2.Text;
            }
            ZamianaDanych();
        }

        private void contextMenuStrip2_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    textBox1.Text = item.SubItems[0].Text;
                    textBox3.Text = item.SubItems[1].Text;
                    dateTimePicker1.Text = item.SubItems[2].Text;
                    textBox2.Text = item.SubItems[3].Text;
                }
            
        }
    }
}