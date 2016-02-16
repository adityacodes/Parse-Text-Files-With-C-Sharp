using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Parsetextfile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = " Text File | *.txt";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null)
            {
                StreamReader str = new StreamReader(textBox1.Text);
                string text = str.ReadToEnd();
                string[] stringSeparators = new string[] { "<option value=\"","\">","</option>" };
                string[] strig = text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                

                    
                    if (textBox3.Text != null)
                    {
                        
                        StreamWriter sw = new StreamWriter(textBox3.Text);
                        foreach (string s in strig)
                        {
                            //MessageBox.Show(String.IsNullOrWhiteSpace(s) ? " " : s);
                            sw.WriteLine(s);
                        }
                   
                     }


                
                str.Dispose();

            }
            else
            {
                MessageBox.Show("Please select a file.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = " Text Files | *.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = sfd.FileName;
            }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(textBox1.Text);
            lines = lines.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToArray();
            File.WriteAllLines(textBox3.Text, lines);
        }
    }
}
