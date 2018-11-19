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

namespace Anno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int count = this.Controls.Count * 2 + 2;
            float[] factor = new float[count];
            int i = 0;
            factor[i++] = Size.Width;
            factor[i++] = Size.Height;
            foreach (Control ctrl in this.Controls)
            {
                factor[i++] = ctrl.Location.X / (float)Size.Width;
                factor[i++] = ctrl.Location.Y / (float)Size.Height;
                ctrl.Tag = ctrl.Size;
            }
            Tag = factor;
        }

        private String title = "Untitled";  //保存打开的文件的标题
        Encoding ec = Encoding.UTF8;          //设置文本的格式为 UTF-8
        private int line = 2;
        private int len = 1;
        private string[] annostring = new string[6000];
        private string[][] d_d = new string[6000][];
        private string[][] d_a = new string[6000][];
        private string[][] entity1 = new string[6000][];
        private string[][] entity2= new string[6000][];
        private string[][] entity3 = new string[6000][];

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") { MessageBox.Show("请先打开文件"); }
            else
            {
                if (richTextBox7.Text == "" & richTextBox3.Text == "" & richTextBox4.Text == "")
                {
                    DialogResult dr = MessageBox.Show("你未做任何标记是否进入下一条？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        string ann = richTextBox1.Text;
                        FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs, ec);
                        int num = int.Parse(textBox1.Text)+1;
                        while (num > 0 && num < len + 1)
                        {
                            richTextBox1.Text = sr.ReadLine();
                            num--;
                        }
                        if (int.Parse(textBox1.Text) < len)
                        {
                            textBox1.Text = (int.Parse(textBox1.Text)+1).ToString();
                            string aFilePath = @"C:\Anno\Anno.txt";

                            FileStream fsaMyfile = new FileStream(aFilePath, FileMode.Create, FileAccess.Write);
                            StreamWriter swaMyfile = new StreamWriter(fsaMyfile);
                            if (ann != "")
                            {
                                annostring[int.Parse(textBox1.Text)-1] = int.Parse(textBox1.Text)-1 +"\t"+ann;
                                foreach (string i in annostring){
                                    if (i != null) { swaMyfile.WriteLine(i); } }
                            }
                            swaMyfile.Flush();
                            swaMyfile.Close();
                            fsaMyfile.Close();
                        }
                        else
                        {
                            textBox1.Text = textBox1.Text; MessageBox.Show("已经是最后一句，恭喜你完成本次工作，真棒！！");
                            string aFilePath = @"C:\Anno\Anno.txt";

                            FileStream fsaMyfile = new FileStream(aFilePath, FileMode.Create, FileAccess.Write);
                            StreamWriter swaMyfile = new StreamWriter(fsaMyfile);
                            if (ann != "")
                            {
                                annostring[int.Parse(textBox1.Text)] = textBox1.Text + "\t" + ann;
                                foreach (string i in annostring)
                                {
                                    if (i != null) { swaMyfile.WriteLine(i); }
                                }
                            }
                            swaMyfile.Flush();
                            swaMyfile.Close();
                            fsaMyfile.Close();
                        }
                        if (line < len + 1) { line++; }
                        richTextBox3.Text = "";
                        richTextBox4.Text = "";
                        richTextBox7.Text = "";
                        richTextBox6.Text = "";
                        richTextBox5.Text = "";
                    }
                }
                else {
                    string ann = richTextBox1.Text;
                    FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs, ec);
                    int num = line;
                    while (num > 0 && num < len + 1)
                    {
                        richTextBox1.Text = sr.ReadLine();
                        num--;
                    }
                    if (int.Parse(textBox1.Text) < len)
                    {
                        textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
                        string aFilePath = @"C:\Anno\Anno.txt";
                        string bFilePath = @"C:\Anno\entity1_entity2.txt";
                        string cFilePath = @"C:\Anno\entity2_entity3.txt";

                        FileStream fsaMyfile = new FileStream(aFilePath, FileMode.Create, FileAccess.Write);
                        StreamWriter swaMyfile = new StreamWriter(fsaMyfile);
                        FileStream fsbMyfile = new FileStream(bFilePath, FileMode.Create, FileAccess.Write);
                        StreamWriter swbMyfile = new StreamWriter(fsbMyfile);
                        FileStream fscMyfile = new FileStream(cFilePath, FileMode.Create, FileAccess.Write);
                        StreamWriter swcMyfile = new StreamWriter(fscMyfile);
                        if (ann != "")
                        {
                            annostring[int.Parse(textBox1.Text)-1] = int.Parse(textBox1.Text) - 1 + "\t" + ann;
                            foreach (string i in annostring)
                            {
                                if (i != null) { swaMyfile.WriteLine(i); }
                            }
                        }
                        if (richTextBox6.Text != "")
                        {
                            string[] dd = richTextBox6.Text.Split('\n');
                            d_d[int.Parse(textBox1.Text) - 1] = dd;
                            foreach (string[] k in d_d)
                            {
                                if (k != null)
                                {
                                    foreach (string j in k)
                                    {
                                        swbMyfile.WriteLine(j);
                                    }
                                }
                            }
                        }
                        else {
                            foreach (string[] k in d_d)
                            {
                                if (k != null)
                                {
                                    foreach (string j in k)
                                    {
                                        swbMyfile.WriteLine(j);
                                    }
                                }
                            }
                        }
                        if (richTextBox5.Text != "")
                        {
                            string[] da = richTextBox5.Text.Split('\n');
                            d_a[int.Parse(textBox1.Text) - 1] = da;
                            foreach (string[] k in d_a)
                            {
                                if (k != null)
                                {
                                    foreach (string j in k)
                                    {
                                        swcMyfile.WriteLine(j);
                                    }
                                }
                            }
                        }
                        else {
                            foreach (string[] k in d_a)
                            {
                                if (k != null)
                                {
                                    foreach (string j in k)
                                    {
                                        swcMyfile.WriteLine(j);
                                    }
                                }
                            }
                        }
                        swaMyfile.Flush();
                        swaMyfile.Close();
                        fsaMyfile.Close();
                        swbMyfile.Flush();
                        swbMyfile.Close();
                        fsbMyfile.Close();
                        swcMyfile.Flush();
                        swcMyfile.Close();
                        fscMyfile.Close();
                        string[] dr = richTextBox3.Text.Split('\n');
                        entity2[int.Parse(textBox1.Text) - 1] = dr;
                        string[] di = richTextBox7.Text.Split('\n');
                        entity1[int.Parse(textBox1.Text) - 1] = di;
                        string[] a = richTextBox4.Text.Split('\n');
                        entity3[int.Parse(textBox1.Text) - 1] = a;
                    }
                    else
                    {
                        textBox1.Text = line.ToString(); MessageBox.Show("已经是最后一句！");
                        string aFilePath = @"C:\Anno\Anno.txt";
                        string bFilePath = @"C:\Anno\entity1_entity2.txt";
                        string cFilePath = @"C:\Anno\entity2_entity3.txt";

                        FileStream fsaMyfile = new FileStream(aFilePath, FileMode.Create, FileAccess.Write);
                        StreamWriter swaMyfile = new StreamWriter(fsaMyfile);
                        FileStream fsbMyfile = new FileStream(bFilePath, FileMode.Create, FileAccess.Write);
                        StreamWriter swbMyfile = new StreamWriter(fsbMyfile);
                        FileStream fscMyfile = new FileStream(cFilePath, FileMode.Create, FileAccess.Write);
                        StreamWriter swcMyfile = new StreamWriter(fscMyfile);
                        if (ann != "")
                        {
                            annostring[int.Parse(textBox1.Text)] = textBox1.Text + "\t" + ann;
                            foreach (string i in annostring)
                            {
                                if (i != null) { swaMyfile.WriteLine(i); }
                            }
                        }
                        if (richTextBox6.Text != "")
                        {
                            string[] dd = richTextBox6.Text.Split('\n');
                            d_d[int.Parse(textBox1.Text)] = dd;
                            foreach (string[] k in d_d)
                            {
                                if (k != null)
                                {
                                    foreach (string j in k)
                                    {
                                        swbMyfile.WriteLine(j);
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (string[] k in d_d)
                            {
                                if (k != null)
                                {
                                    foreach (string j in k)
                                    {
                                        swbMyfile.WriteLine(j);
                                    }
                                }
                            }
                        }
                        if (richTextBox5.Text != "")
                        {
                            string[] da = richTextBox5.Text.Split('\n');
                            d_a[int.Parse(textBox1.Text)] = da;
                            foreach (string[] k in d_a)
                            {
                                if (k != null)
                                {
                                    foreach (string j in k)
                                    {
                                        swcMyfile.WriteLine(j);
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (string[] k in d_a)
                            {
                                if (k != null)
                                {
                                    foreach (string j in k)
                                    {
                                        swcMyfile.WriteLine(j);
                                    }
                                }
                            }
                        }
                        swaMyfile.Flush();
                        swaMyfile.Close();
                        fsaMyfile.Close();
                        swbMyfile.Flush();
                        swbMyfile.Close();
                        fsbMyfile.Close();
                        swcMyfile.Flush();
                        swcMyfile.Close();
                        fscMyfile.Close();
                        string[] dr = richTextBox3.Text.Split('\n');
                        entity2[int.Parse(textBox1.Text)] = dr;
                        string[] di = richTextBox7.Text.Split('\n');
                        entity1[int.Parse(textBox1.Text)] = di;
                        string[] a = richTextBox4.Text.Split('\n');
                        entity3[int.Parse(textBox1.Text)] = a;
                    }
                    if (line < len + 1) { line++; }
                    richTextBox3.Text = "";
                    richTextBox4.Text = "";
                    richTextBox7.Text = "";
                    richTextBox6.Text = "";
                    richTextBox5.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "") { MessageBox.Show("请先打开文件"); }
            else
            {
                if (int.Parse(textBox1.Text) == 1) { MessageBox.Show("已经是第一行"); }
                else {
                    string[] i = new string[5];
                    if(annostring[int.Parse(textBox1.Text) - 1] != null) {
                        i = annostring[int.Parse(textBox1.Text) - 1].Split('\t');
                        richTextBox1.Text = "";
                        for (int j = 1; j < i.Length; j++)
                        {
                            if (i[j] != null) { richTextBox1.Text = richTextBox1.Text + i[j]; }
                        }
                        textBox1.Text = (int.Parse(textBox1.Text) - 1).ToString();
                        line = line - 1;
                    }
                    else
                    {
                        FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs, ec);
                        int num = int.Parse(textBox1.Text) - 1;
                        while (num > 0 && num < len + 1)
                        {
                            richTextBox1.Text = sr.ReadLine();
                            num--;
                        }
                        textBox1.Text = (int.Parse(textBox1.Text) - 1).ToString();
                        line = line - 1;
                    }
                    if (d_a[int.Parse(textBox1.Text)] != null){
                        richTextBox5.Text = "";
                        foreach (string j in d_a[int.Parse(textBox1.Text)]) {
                            if (j != null) {
                                if (richTextBox5.Text == "") { richTextBox5.Text = j; }
                                else { richTextBox5.Text = richTextBox5.Text + '\n' + j; }
                            }
                         }
                    }
                    if (d_d[int.Parse(textBox1.Text)] != null)
                    {
                        richTextBox6.Text = "";
                        foreach (string j in d_d[int.Parse(textBox1.Text)])
                        {
                            if (j != null)
                            {
                                if (richTextBox6.Text == "") { richTextBox6.Text = j; }
                                else { richTextBox6.Text = richTextBox6.Text + '\n' + j; }
                            }
                        }
                    }
                    if (entity2[int.Parse(textBox1.Text)] != null) {
                        richTextBox3.Text = "";
                        foreach (string j in entity2[int.Parse(textBox1.Text)])
                        {
                            if (j != null)
                            {
                                if (richTextBox3.Text == "") { richTextBox3.Text = j; }
                                else { richTextBox3.Text = richTextBox3.Text + '\n' + j; }
                            }
                        }
                    }
                    if (entity1[int.Parse(textBox1.Text)] != null)
                    {
                        richTextBox7.Text = "";
                        foreach (string j in entity1[int.Parse(textBox1.Text)])
                        {
                            if (j != null)
                            {
                                if (richTextBox7.Text == "") { richTextBox7.Text = j; }
                                else { richTextBox7.Text = richTextBox7.Text + '\n' + j; }
                            }
                        }
                    }
                    if (entity3[int.Parse(textBox1.Text)] != null)
                    {
                        richTextBox4.Text = "";
                        foreach (string j in entity3[int.Parse(textBox1.Text)])
                        {
                            if (j != null)
                            {
                                if (richTextBox4.Text == "") { richTextBox4.Text = j; }
                                else { richTextBox4.Text = richTextBox4.Text + '\n' + j; }
                            }
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "") { richTextBox3.Text = richTextBox1.SelectedText; }
            else {
                string[] entity1 = new string[15];
                int num = 0;
                entity1 = richTextBox3.Text.Split('\n');
                foreach (string i in entity1)
                {
                    if (i == richTextBox1.SelectedText) { num = num + 1; }
                }
                if (num != 1) { richTextBox3.Text = richTextBox3.Text + '\n' + richTextBox1.SelectedText; }
            }
            richTextBox1.SelectedText = "[@" + richTextBox1.SelectedText + "#" + "实体2" + "*]";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();//撤销
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();//重做
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("请问打开文件"); }
            else
            {
                if (int.Parse(textBox1.Text) < len + 1)
                {
                    string[] i = new string[2];
                    if (annostring[int.Parse(textBox1.Text)] != null)
                    {
                        i = annostring[int.Parse(textBox1.Text)].Split('\t');
                        richTextBox1.Text = "";
                        for (int j = 1; j < i.Length; j++)
                        {
                            if (i[j] != null) { richTextBox1.Text = richTextBox1.Text + i[j]; }
                        }
                        line = int.Parse(textBox1.Text)+1;
                    }
                    if (d_a[int.Parse(textBox1.Text)] != null)
                    {
                        richTextBox5.Text = "";
                        if (richTextBox5.Text == "")
                        {
                            foreach (string j in d_a[int.Parse(textBox1.Text)])
                            {
                                if (j != null)
                                {
                                    if (richTextBox5.Text == "") { richTextBox5.Text = j; }
                                    else { richTextBox5.Text = richTextBox5.Text + '\n' + j; }
                                }
                            }
                        }
                    }
                    if (d_d[int.Parse(textBox1.Text)] != null)
                    {
                        richTextBox6.Text = "";
                        if (richTextBox6.Text == "")
                        {
                            foreach (string j in d_d[int.Parse(textBox1.Text)])
                            {
                                if (j != null)
                                {
                                    if (richTextBox6.Text == "") { richTextBox6.Text = j; }
                                    else { richTextBox6.Text = richTextBox6.Text + '\n' + j; }
                                }
                            }
                        }
                    }
                    if (entity2[int.Parse(textBox1.Text)] != null)
                    {
                        richTextBox3.Text = "";
                        if (richTextBox3.Text == "")
                        {
                            foreach (string j in entity2[int.Parse(textBox1.Text)])
                            {
                                if (j != null)
                                {
                                    if (richTextBox3.Text == "") { richTextBox3.Text = j; }
                                    else { richTextBox3.Text = richTextBox3.Text + '\n' + j; }
                                }
                            }
                        }
                    }
                    if (entity1[int.Parse(textBox1.Text)] != null)
                    {
                        richTextBox7.Text = "";
                        if (richTextBox7.Text == "")
                        {
                            foreach (string j in entity1[int.Parse(textBox1.Text)])
                            {
                                if (j != null)
                                {
                                    if (richTextBox7.Text == "") { richTextBox7.Text = j; }
                                    else { richTextBox7.Text = richTextBox7.Text + '\n' + j; }
                                }
                            }
                        }
                    }
                    if (entity3[int.Parse(textBox1.Text)] != null)
                    {
                        richTextBox4.Text = "";
                        if (richTextBox4.Text == "")
                        {
                            foreach (string j in entity3[int.Parse(textBox1.Text)])
                            {
                                if (j != null)
                                {
                                    if (richTextBox4.Text == "") { richTextBox4.Text = j; }
                                    else { richTextBox4.Text = richTextBox4.Text + '\n' + j; }
                                }
                            }
                        }
                    }
                    else
                    {

                        line = int.Parse(textBox1.Text);
                        FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs, ec);
                        int num = line;
                        while (num > 0)
                        {
                            richTextBox1.Text = sr.ReadLine();
                            num--;
                        }
                        line=int.Parse(textBox1.Text);
                    }
                }
                else { MessageBox.Show("超出了最大行数"); }
                if (d_a[int.Parse(textBox1.Text)] != null)
                {
                    richTextBox5.Text = "";
                    if (richTextBox5.Text == "")
                    {
                        foreach (string j in d_a[int.Parse(textBox1.Text)])
                        {
                            if (j != null)
                            {
                                if (richTextBox5.Text == "") { richTextBox5.Text = j; }
                                else { richTextBox5.Text = richTextBox5.Text + '\n' + j; }
                            }
                        }
                    }
                }
                if (d_d[int.Parse(textBox1.Text)] != null)
                {
                    richTextBox6.Text = "";
                    if (richTextBox6.Text == "")
                    {
                        foreach (string j in d_d[int.Parse(textBox1.Text)])
                        {
                            if (j != null)
                            {
                                if (richTextBox6.Text == "") { richTextBox6.Text = j; }
                                else { richTextBox6.Text = richTextBox6.Text + '\n' + j; }
                            }
                        }
                    }
                }
                if (entity2[int.Parse(textBox1.Text)] != null)
                {
                    richTextBox3.Text = "";
                    if (richTextBox3.Text == "")
                    {
                        foreach (string j in entity2[int.Parse(textBox1.Text)])
                        {
                            if (j != null)
                            {
                                if (richTextBox3.Text == "") { richTextBox3.Text = j; }
                                else { richTextBox3.Text = richTextBox3.Text + '\n' + j; }
                            }
                        }
                    }
                }
                if (entity1[int.Parse(textBox1.Text)] != null)
                {
                    richTextBox7.Text = "";
                    if (richTextBox7.Text == "")
                    {
                        foreach (string j in entity1[int.Parse(textBox1.Text)])
                        {
                            if (j != null)
                            {
                                if (richTextBox7.Text == "") { richTextBox7.Text = j; }
                                else { richTextBox7.Text = richTextBox7.Text + '\n' + j; }
                            }
                        }
                    }
                }
                if (entity3[int.Parse(textBox1.Text)] != null)
                {
                    richTextBox4.Text = "";
                    if (richTextBox4.Text == "")
                    {
                        foreach (string j in entity3[int.Parse(textBox1.Text)])
                        {
                            if (j != null)
                            {
                                if (richTextBox4.Text == "") { richTextBox4.Text = j; }
                                else { richTextBox4.Text = richTextBox4.Text + '\n' + j; }
                            }
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (richTextBox4.Text == "") { richTextBox4.Text = richTextBox1.SelectedText; }
            else {
                string[] entity1 = new string[15];
                int num = 0;
                entity1 = richTextBox4.Text.Split('\n');
                foreach (string i in entity1)
                {
                    if (i == richTextBox1.SelectedText) { num = num + 1; }
                }
                if (num != 1) { richTextBox4.Text = richTextBox4.Text + '\n' + richTextBox1.SelectedText; }
            }
            richTextBox1.SelectedText = "[@" + richTextBox1.SelectedText + "#" + "实体3" + "*]";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("请先打开文件"); }
            else
            {
                line = int.Parse(textBox1.Text);
                FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, ec);
                int num = line;
                string str = "";
                while (num > 0)
                {
                    str = sr.ReadLine();
                    num--;
                }
                line++;
                string[] entity3 = new string[15];
                string[] entity2 = new string[15];
                if (richTextBox3.SelectedText != "" & richTextBox4.SelectedText != "")
                {
                    entity2 = richTextBox3.SelectedText.Split('\n');
                    entity3 = richTextBox4.SelectedText.Split('\n');
                    foreach (string i in entity3)
                    {
                        foreach (string j in entity2)
                        {
                            if (richTextBox5.Text != "") { richTextBox5.Text = richTextBox5.Text + '\n' + j + ' ' + i + ' ' + "关系B1" + ' ' + str; }
                            else { richTextBox5.Text = j + ' ' + i + ' ' + "关系B1" + ' ' + str; }
                        }
                    }
                }
                else { MessageBox.Show("请选择内容"); }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("请先打开文件"); }
            else
            {
                line = int.Parse(textBox1.Text);
                FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, ec);
                int num = line;
                string str = "";
                while (num > 0)
                {
                    str = sr.ReadLine();
                    num--;
                }
                line++;
                string[] entity3 = new string[15];
                string[] entity2 = new string[15];
                if (richTextBox3.SelectedText != "" & richTextBox4.SelectedText != "")
                {
                    entity2 = richTextBox3.SelectedText.Split('\n');
                    entity3 = richTextBox4.SelectedText.Split('\n');
                    foreach (string i in entity3)
                    {
                        foreach (string j in entity2)
                        {
                            if (richTextBox5.Text != "") { richTextBox5.Text = richTextBox5.Text + '\n' + j + ' ' + i + ' ' + "关系B2" + ' ' + str; }
                            else { richTextBox5.Text = j + ' ' + i + ' ' + "关系B2" + ' ' + str; }
                        }
                    }
                }
                else { MessageBox.Show("请选择内容"); }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("请先打开文件"); }
            else
            {
                line = int.Parse(textBox1.Text);
                FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, ec);
                int num = line;
                string str = "";
                while (num > 0)
                {
                    str = sr.ReadLine();
                    num--;
                }
                line++;
                string[] entity3 = new string[15];
                string[] entity2 = new string[15];
                if (richTextBox3.SelectedText != "" & richTextBox4.SelectedText != "")
                {
                    entity2 = richTextBox3.SelectedText.Split('\n');
                    entity3 = richTextBox4.SelectedText.Split('\n');
                    foreach (string i in entity3)
                    {
                        foreach (string j in entity2)
                        {
                            if (richTextBox5.Text != "") { richTextBox5.Text = richTextBox5.Text + '\n' + j + ' ' + i + ' ' + "关系B3" + ' ' + str; }
                            else { richTextBox5.Text = j + ' ' + i + ' ' + "关系B3" + ' ' + str; }
                        }
                    }
                }
                else { MessageBox.Show("请选择内容"); }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string aFilePath = @"C:\Anno\Anno.txt";
            string bFilePath = @"C:\Anno\entity1_entity2.txt";
            string cFilePath = @"C:\Anno\entity2_entity3.txt";

            FileStream fsaMyfile = new FileStream(aFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter swaMyfile = new StreamWriter(fsaMyfile);
            FileStream fsbMyfile = new FileStream(bFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter swbMyfile = new StreamWriter(fsbMyfile);
            FileStream fscMyfile = new FileStream(cFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter swcMyfile = new StreamWriter(fscMyfile);
            string[] anno= richTextBox1.Text.Split('\n');
            foreach (string i in anno)
            {
                if (i != null) { swaMyfile.WriteLine(i); }
                else { continue; }
            }
            string[] entity2_entity3 = richTextBox5.Text.Split('\n');
            foreach (string i in entity2_entity3)
            {
                if (i != null) { swcMyfile.WriteLine(i); }
                else { continue; }
            }
            string[] entity1_entity2 = richTextBox6.Text.Split('\n');
            foreach (string i in entity1_entity2)
            {
                if (i != null) { swbMyfile.WriteLine(i); }
                else { continue; }
            }
            swaMyfile.Flush();
            swaMyfile.Close();
            fsaMyfile.Close();
            swbMyfile.Flush();
            swbMyfile.Close();
            fsbMyfile.Close();
            swcMyfile.Flush();
            swcMyfile.Close();
            fscMyfile.Close();
        }

        private void opentoolStripButton_Click_1(object sender, EventArgs e)
        {
            /**
            * openFileDialog1 是在设计界面拖出来的控件 OpenFileDialog
            * 
            * 主要是打开 rtf 格式的文件
            */
            openFileDialog1.Filter = "文本文件|*.txt;*.html;*.docx;*.doc;*.rtf|所有文件|*.*"; //文件打开的过滤器
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                title = openFileDialog1.FileName;
                this.Text = title;                  //显示打开的文件名
                richTextBox1.Modified = false;
                string ext = title.Substring(title.LastIndexOf(".") + 1);//获取文件格式
                ext = ext.ToLower();
                FileStream fs = new FileStream(title, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, ec);

                if (ext == "rtf")  //如果后缀是 rtf 加载文件进来
                {
                    richTextBox1.LoadFile(title, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.Text = sr.ReadLine();
                    while (sr.ReadLine() != null)
                    {
                        len++;
                    }
                    if (len == 1) { MessageBox.Show("文件为空"); }
                    else {
                        label1.Text = "共" + len.ToString() + "行";
                        textBox1.Text = (line - 1).ToString();
                    }
                }
                fs.Close();
                sr.Close();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (richTextBox7.Text == "") { richTextBox7.Text = richTextBox1.SelectedText; }
            else {
                string[] entity1 = new string[15];
                int num = 0;
                entity1 = richTextBox7.Text.Split('\n');
                foreach (string i in entity1)
                {
                    if (i == richTextBox1.SelectedText) { num=num+1; }
                }
                if (num != 1) { richTextBox7.Text = richTextBox7.Text + '\n' + richTextBox1.SelectedText; }
            }
            richTextBox1.SelectedText = "[@" + richTextBox1.SelectedText + "#" + "实体1" + "*]";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("请先打开文件"); }
            else
            {
                line = int.Parse(textBox1.Text);
                FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, ec);
                int num = line;
                string str = "";
                while (num > 0)
                {
                    str = sr.ReadLine();
                    num--;
                }
                line++;
                string[] entity1 = new string[15];
                string[] entity2 = new string[15];
                if (richTextBox7.SelectedText != "" & richTextBox3.SelectedText != "")
                {
                    entity2 = richTextBox3.SelectedText.Split('\n');
                    entity1 = richTextBox7.SelectedText.Split('\n');
                    foreach (string i in entity1)
                    {
                        foreach (string j in entity2)
                        {
                            if (richTextBox6.Text != "") { richTextBox6.Text = richTextBox6.Text + '\n' + i + ' ' + j + ' ' + "关系A2" + ' ' + str; }
                            else { richTextBox6.Text = i + ' ' + j + ' ' + "关系A2" + ' ' + str; }
                        }
                    }
                }
                else { MessageBox.Show("请选择内容"); }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("请先打开文件"); }
            else
            {
                line = int.Parse(textBox1.Text);
                FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, ec);
                int num = line;
                string str = "";
                while (num > 0)
                {
                    str = sr.ReadLine();
                    num--;
                }
                line++;
                string[] entity1 = new string[15];
                string[] entity2 = new string[15];
                if (richTextBox7.SelectedText != "" & richTextBox3.SelectedText != "")
                {
                    entity2 = richTextBox3.SelectedText.Split('\n');
                    entity1 = richTextBox7.SelectedText.Split('\n');
                    foreach (string i in entity1)
                    {
                        foreach (string j in entity2)
                        {
                            if (richTextBox6.Text != "") { richTextBox6.Text = richTextBox6.Text + '\n' + i + ' ' + j + ' ' + "关系A1" + ' ' + str; }
                            else { richTextBox6.Text = i + ' ' + j + ' ' + "关系A1" + ' ' + str; }
                        }
                    }
                }
                else { MessageBox.Show("请选择内容"); }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("请先打开文件"); }
            else
            {
                line = int.Parse(textBox1.Text);
                FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, ec);
                int num = line;
                string str = "";
                while (num > 0)
                {
                    str = sr.ReadLine();
                    num--;
                }
                line++;
                string[] entity1 = new string[15];
                string[] entity2 = new string[15];
                if (richTextBox7.SelectedText != "" & richTextBox3.SelectedText != "")
                {
                    entity2 = richTextBox3.SelectedText.Split('\n');
                    entity1 = richTextBox7.SelectedText.Split('\n');
                    foreach (string i in entity1)
                    {
                        foreach (string j in entity2)
                        {
                            if (richTextBox6.Text != "") { richTextBox6.Text = richTextBox6.Text + '\n' + i + ' ' + j + ' ' + "关系A3" + ' ' + str; }
                            else { richTextBox6.Text = i + ' ' + j + ' ' + "关系A3" + ' ' + str; }
                        }
                    }
                }
                else { MessageBox.Show("请选择内容"); }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("请先打开文件"); }
            else
            {
                line = int.Parse(textBox1.Text);
                FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, ec);
                int num = line;
                string str = "";
                while (num > 0)
                {
                    str = sr.ReadLine();
                    num--;
                }
                line++;
                string[] entity3 = new string[15];
                string[] entity2 = new string[15];
                if (richTextBox3.SelectedText != "" & richTextBox4.SelectedText != "")
                {
                    entity2 = richTextBox3.SelectedText.Split('\n');
                    entity3 = richTextBox4.SelectedText.Split('\n');
                    foreach (string i in entity3)
                    {
                        foreach (string j in entity2)
                        {
                            if (richTextBox5.Text != "") { richTextBox5.Text = richTextBox5.Text + '\n' + j + ' ' + i + ' ' + "关系B4" + ' ' + str; }
                            else { richTextBox5.Text = j + ' ' + i + ' ' + "关系B4" + ' ' + str; }
                        }
                    }
                }
                else { MessageBox.Show("请选择内容"); }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("请问打开文件"); }
            else
            {
                if (int.Parse(textBox1.Text) < len + 1)
                {
                    line = int.Parse(textBox1.Text);
                    FileStream fs = new FileStream(this.Text, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs, ec);
                    int num = line;
                    while (num > 0)
                    {
                        richTextBox1.Text = sr.ReadLine();
                        num--;
                    }
                    line++;
                }
                richTextBox3.Text = "";
                richTextBox4.Text = "";
                richTextBox7.Text = "";
                richTextBox6.Text = "";
                richTextBox5.Text = "";
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != null)
            {
                string a = richTextBox1.SelectedText;
                try
                {
                    int i = a.IndexOf("[");
                    a=a.Remove(i, 2);
                    int k = a.IndexOf("#");
                    int j = a.IndexOf("]");
                    a = a.Remove(k, j - k + 1);
                    richTextBox1.SelectedText = a;
                }
                catch { MessageBox.Show("请正确选中"); }
            }
            else { MessageBox.Show("请选中实体标注文字"); }
        }
    }
}
