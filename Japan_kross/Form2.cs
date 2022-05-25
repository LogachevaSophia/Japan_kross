using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Japan_kross
{
    public partial class Form2 : Form
    {
        public int n, m;
        List<string[]> arr = new List<string[]>();
        public Form2()
        {
            InitializeComponent();
        }
        public static void read(ref List<string[]> arr, string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        arr.Add(line.Split(' '));
                    }
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
      
        public Form2 (string level)
        {
            
            switch (level)
            {
                case "1":
                    string path = @"C:\Users\Софийкина\Desktop\ПОЛИТЕХ\дз\Процедурное программирование\2 сем\Japan_kross\levels\1\1.txt";
                    read(ref arr, path);
 
                    setka();
                    break;
                default:
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }
        public void setka()
        {
            Panel panel = new Panel();
            panel.AutoSize = true;
            Controls.Add(panel);

            MessageBox.Show(arr[0].Length.ToString());
            for (int i = 0; i <= arr.Count; i++)
            {
                for (int j = 0; j <= arr[0].Length; j++)
                {
                    if (i == 0 & j==0)
                    {
                        Label lab = new Label();
                        int n = 0;
                        for (int k = 0; k < arr.Count; k++)
                        {
                            if (arr[i][k] == "1")
                            {
                                n += 1;
                            }
                            else
                            {
                                if (n != 0)
                                {
                                    lab.Text += n.ToString() + " ";
                                }
                            }
                        }
                        if (n != 0)
                        {
                            lab.Text += n.ToString();
                        }
                        panel.Controls.Add(lab);
                        
                        
                    }
                    else
                    {
                        if (j==1 & i > 0)
                        {
                            Label lab = new Label();
                            int n = 0;
                            for (int k = 0; k < arr.Count; k++)
                            {
                                if (arr[k][i] == "1")
                                {
                                    n += 1;
                                }
                                else
                                {
                                    if (n != 0)
                                    {
                                        lab.Text += n.ToString() + " ";
                                    }
                                }
                            }
                            if (n != 0)
                            {
                                lab.Text += n.ToString();
                            }
                            panel.Controls.Add(lab);

                        }
                    }
                            
                    Button but = new Button();
                    but.Name = Convert.ToString(i)+ Convert.ToString(j);
                    but.Location = new Point(j*50+50, i*50+50);
                    but.Size = new Size(50,50);
                    panel.Controls.Add(but);
                }
            }

            this.Size = new Size(panel.Width,panel.Height+50);
        }


    }
}
