using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using RichTextBox = System.Windows.Forms.RichTextBox;

namespace Optimizasyon
{
    public partial class Form1 : Form
    {
        List<RichTextBox> Maliyetler = new List<RichTextBox>();
        List<Label> labels = new List<Label>();
        List<RichTextBox> Arz = new List<RichTextBox>();
        List<RichTextBox> Talep = new List<RichTextBox>();
        public Form1()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen, kaynak ve hedef bilgilerini tam doldurunuz!");
            }
            else
            {

                int kaynak = int.Parse(textBox1.Text);
                int hedef = int.Parse(textBox2.Text);

                this.AutoSize = true;
                button3.Visible = true;
                button5.Visible = true;
                button5.Enabled = true;
                label4.AutoSize = true;


                for (int i = 0; i <= kaynak + 2; i++)
                {
                    for (int j = 0; j <= hedef + 2; j++)
                    {
                        if (i > 0 && j != 0)
                        {
                            if (i - 1 == 0 && j - 1 == 0)
                            {
                                var lbl1 = new System.Windows.Forms.Label();
                                lbl1.AutoSize = true;
                                lbl1.Location = new Point(200 + 55 * (j + 1), (52 * (i + 1)) - 52);
                                lbl1.Text = "      ";
                                Controls.Add(lbl1);
                                labels.Add(lbl1);
                            }
                            else if (i - 1 == 0 && j > 0)
                            {
                                var lbl = new System.Windows.Forms.Label();
                                lbl.AutoSize = true;
                                lbl.Location = new Point(200 + 57 * (j + 1), (60 * (i + 1)) - 51);
                                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);

                                if (j - 2 == hedef)
                                    lbl.Text = "Arzlar";
                                else
                                    lbl.Text = "D" + (j - 1);
                                Controls.Add(lbl);
                                labels.Add(lbl);

                            }
                            else if (i == kaynak + 2 && j - 2 == hedef)
                            {
                                var lbl2 = new System.Windows.Forms.Label();
                                lbl2.AutoSize = true;
                                lbl2.Location = new Point(200 + 55 * (j + 1), (54 * (i + 1)) - 54);
                                lbl2.Text = "      ";
                                Controls.Add(lbl2);

                                labels.Add(lbl2);
                            }
                            else if (i != kaynak + 2 && j - 1 == 0)
                            {
                                var lbl3 = new System.Windows.Forms.Label();
                                lbl3.AutoSize = true;
                                lbl3.Location = new Point(206 + 55 * (j + 1), (54 * (i + 1)) - 54);
                                lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
                                lbl3.Text = "S" + (i - 1);
                                Controls.Add(lbl3);

                                labels.Add(lbl3);
                            }
                            else if (i == kaynak + 2 && j - 1 == 0)
                            {
                                var lbl4 = new System.Windows.Forms.Label();
                                lbl4.AutoSize = true;
                                lbl4.Location = new Point(188 + 55 * (j + 1), (53 * (i + 1)) - 53);
                                lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
                                lbl4.Text = "Talepler";
                                Controls.Add(lbl4);
                                labels.Add(lbl4);

                            }
                            else
                            {

                                var RichTextBox = new RichTextBox();
                                RichTextBox.Location = new Point(185 + 58 * (j + 1), (51 * (i + 1)) - 50);
                                RichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                                RichTextBox.Size = new Size(55, 40);
                                this.Controls.Add(RichTextBox);

                                if (j == hedef + 2)
                                {
                                    Arz.Add(RichTextBox);
                                }
                                else if (i == kaynak + 2)
                                {
                                    Talep.Add(RichTextBox);
                                }
                                else
                                {
                                    Maliyetler.Add(RichTextBox);
                                }

                            }
                        }
                    }
                }
                this.Width += 45;
                this.Height += 45;
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
           /* label4.Visible = false;
            label4.Text = "Toplam Maliyet (Z)  :  ";*/

            int controller = 1000;

            int kucuk = 0;
            int talep = 0;
            int toplam = 0;
            int arz = 0;
            int index = 0;
            int tasiyici = 0;
            int tasiyici2 = 0;
            int kontrol = 0;


            int kaynak = int.Parse(textBox1.Text);
            int hedef = int.Parse(textBox2.Text);

            int[] talepler = new int[Talep.Count()];
            int[] arzlar = new int[Arz.Count()];
            List<int> maliyetler = new List<int>();
            List<string> carpim = new List<string>();


            for (int i = 0; i < Talep.Count(); i++)
            {
                if (Talep[i].Text == "")
                {
                    Talep[i].Text = "0";
                    talep += int.Parse(Talep[i].Text);
                    talepler[i] = int.Parse(Talep[i].Text);
                    Talep[i].Text = "";
                    controller = i;
                }
                else
                {
                    talep += int.Parse(Talep[i].Text);
                    talepler[i] = int.Parse(Talep[i].Text);
                }

            }
            for (int i = 0; i < Arz.Count(); i++)
            {
                if (Arz[i].Text == "")
                {
                    Arz[i].Text = "0";
                    arz += int.Parse(Arz[i].Text);
                    arzlar[i] = int.Parse(Arz[i].Text);
                    Arz[i].Text = "";
                    controller = i;
                }
                else
                {
                    arz += int.Parse(Arz[i].Text);
                    arzlar[i] = int.Parse(Arz[i].Text);
                }
            }
            for (int i = 0; i < Maliyetler.Count(); i++)
            {
                if (Maliyetler[i].Text == "")
                {
                    Maliyetler[i].Text = "0";
                    maliyetler.Add(int.Parse(Maliyetler[i].Text));
                    Maliyetler[i].Text = "";
                    controller = i;
                }
                else
                    maliyetler.Add(int.Parse(Maliyetler[i].Text));
            }

            kontrol = talep;

            if (talep != arz || controller != 1000)
                if (talep != arz)
                    MessageBox.Show("Arz ve Talep miktarları eşit olmalıdır!");
                else
                    MessageBox.Show("Lütfen tüm verileri giriniz!");
            else
            {
                button4.Visible = true;
                button4.Enabled = true;
                button3.Enabled = false;
                this.AutoSize = false;
                this.Height = 580;
                while (kontrol != 0)
                {
                    for (int i = 0; i < maliyetler.Count(); i++)
                    {
                        if (i == 0)
                        {

                            kucuk = maliyetler[i];
                            index = i;

                        }
                        if (maliyetler[i] < kucuk)
                        {

                            kucuk = maliyetler[i];
                            index = i;

                        }

                    }
                    if (talepler[index % hedef] == arzlar[index / hedef] )
                    {
                        toplam += kucuk * talepler[index % hedef];
                        tasiyici2 = talepler[index % hedef];
                        talepler[index % hedef] = 0;
                        arzlar[index / hedef] = 0;
                      
                    }
                    else if (talepler[index % hedef] < arzlar[index / hedef] )
                    {
                        toplam += kucuk * talepler[index % hedef];
                        tasiyici = arzlar[index / hedef] - talepler[index % hedef];
                        arzlar[index / hedef] = tasiyici;
                        tasiyici2 = talepler[index % hedef];
                        talepler[index % hedef] = 0;
                       
                    }
                    else if (talepler[index % hedef] > arzlar[index / hedef])
                    {
                        toplam += kucuk * arzlar[index / hedef];
                        tasiyici = talepler[index % hedef] - arzlar[index / hedef];
                        talepler[index % hedef] = tasiyici;
                        tasiyici2 = arzlar[index / hedef];
                        arzlar[index / hedef] = 0; 
                    }

                    if(tasiyici2 != 0)
                    {
                        Maliyetler[index].AppendText("\r\n" + "      " + tasiyici2);
                        string smaliyet = (maliyetler[index]).ToString();
                        string scarpim = " (" + smaliyet + "*" + tasiyici2 + ") ";
                        carpim.Add(scarpim);
                    }

                    int yeniKontrol = 0;
                    for (int i = 0; i < Talep.Count(); i++)
                    {
                        yeniKontrol += talepler[i];
                    }
                    kontrol = yeniKontrol;

                    maliyetler[index] = 10000;

                }

                for (int i = 0; i < Maliyetler.Count(); i++)
                {
                    Maliyetler[i].Enabled = false;
                }

                for (int i = 0; i < Talep.Count(); i++)
                {
                    Talep[i].Enabled = false;
                    Talep[i].AppendText("\r\n" + "         0");
                }

                for (int i = 0; i < Arz.Count(); i++)
                {
                    Arz[i].Enabled = false;
                    Arz[i].AppendText("\r\n" + "         0");
                }
                for (int i = 0; i < carpim.Count(); i++)
                {
                    if (i < carpim.Count() - 1)
                    {
                        label4.Text += carpim[i] + " + ";

                    }
                    if (i == carpim.Count() - 1)
                    {
                        label4.Text += carpim[i];
                    }
                }
                label4.Text += " =  " + toplam.ToString();
                label4.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            label4.Visible = false;
            label4.Text = "Toplam Maliyet (Z)  :  ";

            for (int i = 0; i < Maliyetler.Count(); i++)
            {

                Maliyetler[i].Enabled = true;
                Maliyetler[i].Text = Maliyetler[i].Lines[0];
            }
            for (int i = 0; i < Talep.Count(); i++)
            {
                Talep[i].Enabled = true;
                Talep[i].Text = Talep[i].Lines[0];
            }
            for (int i = 0; i < Arz.Count(); i++)
            {
                Arz[i].Enabled = true;
                Arz[i].Text = Arz[i].Lines[0];
            }

            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label4.Text = "Toplam Maliyet (Z)  :  ";
            button1.Enabled = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button3.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            this.AutoSize = false;

            this.Width = 315;
            this.Height = 365;

            int count = Maliyetler.Count();
            int count1 = Talep.Count();
            int count2 = Arz.Count();
            int count3 = labels.Count();

            for (int i = 0; i < count; i++)
            {
                Controls.Remove(Maliyetler[0]);
                Maliyetler.RemoveAt(0);

            }
            for (int i = 0; i < count1; i++)
            {
                Controls.Remove(Talep[0]);
                Talep.RemoveAt(0);
            }
            for (int i = 0; i < count2; i++)
            {
                Controls.Remove(Arz[0]);
                Arz.RemoveAt(0);
            }
            for (int i = 0; i < count3; i++)
            {
                Controls.Remove(labels[0]);
                labels.RemoveAt(0);             
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 315;
            this.Height = 365;
        }
    }
}