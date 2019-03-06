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

namespace Görsel_vize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listbox 1 de olup listbox 2 de olmayanları listbox3 e atan kod
            foreach (var v in listBox1.Items)
                if (!listBox2.Items.Contains(v))
                    listBox3.Items.Add(v);
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //button clik oldugunda form ıcındekı secılı olan checkboxları secılmemıs yapsın.
            //secılmemıs olanları secılı yapan program
            foreach(var v in this.Controls)   //formin icindeki kontrolleri bir degıskene atadık
                if(v is CheckBox) 
                {
                    CheckBox cb = (CheckBox)v; //checkboxdan nesne türettik
                    cb.Checked = !cb.Checked; //secılı veya degilse terisne cevirme ozellıgı (true false)
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //textboxdaki merhaba yazını listboxa abahrem şeklinde yukardan asagı yazan kod


            string s = textBox1.Text;                      //textboxın text özelligini string degişkene atadık
            for (int i = s.Length-1; i >= 0; i--)           //dizinin boyutu kadar döngüyu tersten  kurduk 
                listBox4.Items.Add(s[i]);                   //listboxa items olarak ekledik
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //deneme dosyasının içinde satırdaki kelime sayısı 5 den buyuk olan satırları yedek dosyasına atan kod


            StreamReader sr = new StreamReader("deneme.txt",Encoding.Default); //bin klasorundeki txt dosyasının ıcındekı verileri okur
            StreamWriter sw = new StreamWriter("yedek.txt");           //bin klasorunde yeni bir txt dosyası olusturur
            while(!sr.EndOfStream)                                   //metın dosyasındakı satır soonuna kadar gitmesi in dongü
            {
                string satir = sr.ReadLine();                    //her bir satırı string degiskene atadık
                string[] dizi = satir.Split(' ');            //string degişkeni  bosluk ile parcalayarak diziye dolduruk
                if (dizi.Length > 5)   //
                {
                    sw.WriteLine(satir);
                }
            }
            sw.Close();
            sr.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //kullanıcı tarafından klasorun acılması ıcın nesne turettık
            ofd.Filter = "Belgelerim|*.txt";      //filtreleme işlemi
            ofd.Multiselect = true;   //1den fazla secmeye imkan sunmak
            StreamWriter sw = new StreamWriter("temp.txt");
            if (ofd.ShowDialog() == DialogResult.OK)   //belgeler secılıp kullanıcı ok tusuna bastıgında islem yapmaya baslıyacak
            {
                foreach (var v in ofd.FileNames)
                    sw.WriteLine(v);
            }
        }
    }
}
