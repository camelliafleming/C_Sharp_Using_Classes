using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishSurname
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Surname
        {
            public Surname(string name)
            {
                Name = name;
            }
            public string Name { get;}
        }

        List<Surname> Surnames = new List<Surname>();
        

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader namesFile;
            namesFile = File.OpenText("surnames.txt");
            while (!namesFile.EndOfStream)
            {
                string line = namesFile.ReadLine();
                Surname surname = new Surname(line);
                Surnames.Add(surname);
            }

        }

        private void btnLonger_Click(object sender, EventArgs e)
        {
            string input = tbName.Text;
            int count = input.Length;

            var longerNames = Surnames.FindAll(x => x.Name.ToString().Length > count);
            //listBoxResults.Items.Clear();
            foreach(var n in longerNames)
                listBoxResults.Items.Add(n.Name);
        }

        private void btnShorter_Click(object sender, EventArgs e)
        {
            string input = tbName.Text;
            int count = input.Length;

            var shorterNames = Surnames.FindAll(x => x.Name.ToString().Length < count);
            listBoxResults.Items.Clear();
            foreach (var surname in shorterNames)
                listBoxResults.Items.Add(surname.Name);
        }

        private void btnBeginning_Click(object sender, EventArgs e)
        {
            string input = tbName.Text;
            int count = input.Length;

            var beginningNames = Surnames.FindAll(x => x.Name.ToString().StartsWith(input));
            listBoxResults.Items.Clear();
            foreach (var surname in beginningNames)
                listBoxResults.Items.Add(surname.Name);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string input = tbName.Text;
            int count = input.Length;

            var findNames = Surnames.FindAll(x => x.Name.ToString() == input);
            listBoxResults.Items.Clear();
            foreach (var surname in findNames)
                listBoxResults.Items.Add(surname.Name);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbName.Clear();
            tbName.Focus();
            listBoxResults.Items.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
