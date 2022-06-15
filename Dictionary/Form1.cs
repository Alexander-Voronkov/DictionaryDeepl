using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Linq;
namespace Dictionary
{    

    public partial class Dictionary1 : Form
    {
        private List<Language> Langs;
        private Dictionary<Word,List<Word>> WordList = new Dictionary < Word, List<Word>>();
        public Dictionary1()
        {
            InitializeComponent();
            LoadLangs();
            LoadWords();
        }
        private void LoadWords()
        {
            try
            {
                using (System.IO.Stream stream = new System.IO.FileStream("WordList.xml", System.IO.FileMode.Open))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(WordSerializer[]));
                    Dictionary<Word, List<Word>> dict = ((WordSerializer[])xmlSerializer.Deserialize(stream)).ToDictionary(i => i.w1, i => i.w2);
                    if (dict != null)
                        this.WordList = dict;
                    foreach (var item in WordList)
                    {
                        listBox1.Items.Add(item.Key);
                    }
                }
            }
            catch { }
        }
        private void LoadLangs()
        {
            string jsonresp = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api-free.deepl.com/v2/languages?auth_key=efa4d06d-47da-2ba1-b759-00dc069d4693:fx");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream= response.GetResponseStream())
            {
                using (StreamReader sr=new StreamReader(stream))
                {
                    jsonresp = sr.ReadToEnd();
                }
            }
            response.Close();
            Langs=JsonConvert.DeserializeObject<List<Language>>(jsonresp);
            foreach (var item in Langs)
            {
                comboBox1.Items.Add(item.LongLangForm);
                comboBox2.Items.Add(item.LongLangForm);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length == 0 || comboBox2.Text.Length == 0)
            {
                MessageBox.Show("You forgot to choose one of the languages!", "Language choose exception", MessageBoxButtons.OK);
                return;
            }
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("You forgot to enter the translated word!", "Word receival exception", MessageBoxButtons.OK);
                return;
            }
            string r = new Regex(@"\s", RegexOptions.Compiled).Replace(textBox1.Text, "+");
            string jsonresp = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api-free.deepl.com/v2/translate?auth_key=efa4d06d-47da-2ba1-b759-00dc069d4693:fx&text={r}&target_lang={(comboBox2.GetItemWithText(comboBox2.Text, Langs) as Language).ShortLangForm}&source_lang={(comboBox1.GetItemWithText(comboBox1.Text, Langs) as Language).ShortLangForm}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    jsonresp = sr.ReadToEnd();
                }
            }
            response.Close();
            WordJson w = JsonConvert.DeserializeObject<WordJson>(jsonresp);
            textBox2.Text = w.json[0].word;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string t = comboBox1.Text;
            comboBox1.Text = comboBox2.Text;
            comboBox2.Text = t;
            string t1 = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = t1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length==0||textBox2.Text.Length==0)
            {
                MessageBox.Show("There's nothing to save! Translate some words","Word receival exception",MessageBoxButtons.OK);
                return;
            }
            Word word = new Word(textBox2.Text, comboBox2.GetItemWithText(comboBox2.Text,Langs) as Language);
            if (WordList.ContainsKey(new Word(textBox1.Text,comboBox1.GetItemWithText(comboBox1.Text,Langs)as Language)))
            {
                DialogResult dr = MessageBox.Show("You already have this word in your library, do you want to add a new translation for it?", "Warning", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if ((WordList[new Word(textBox1.Text, comboBox1.GetItemWithText(comboBox1.Text,Langs)as Language)]).Contains(word)==false) { WordList[new Word(textBox1.Text, (comboBox1.GetItemWithText(comboBox1.Text, Langs) as Language))].Add(word); }
                        MessageBox.Show("The word has just been successfully saved to your library!", "Success", MessageBoxButtons.OK);
                        break;
                    case DialogResult.No:
                        break;
                }               
            }
            else
            {
                WordList[new Word(textBox1.Text, (comboBox1.GetItemWithText(comboBox1.Text, Langs) as Language))]=new List<Word>() { word};
                listBox1.Items.Add(new Word(textBox1.Text, (comboBox1.GetItemWithText(comboBox1.Text, Langs) as Language)));
                MessageBox.Show("The word has just been successfully saved to your library!", "Success", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string q = (listBox1.SelectedItem as Word)?.Word_;
            int i = 0;
            bool f = false;
            while (i < listBox1.Items.Count)
            {
                if (listBox1.GetSelected(i))
                    f = true;
                i++;
            }
            if (f)
            {
                if(WordList.Remove(listBox1.SelectedItem as Word))
                {
                    MessageBox.Show($"You have successfully removed the word {q} and its translations");
                    listBox1.Items.Remove(listBox1.SelectedItem as Word); listBox2.Items.Clear(); 
                }
            }
            else
            {
                MessageBox.Show("You didn't choose any of the words", "Warning", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string q = (listBox2.SelectedItem as Word)?.Word_;
            int i = 0;
            bool f = false;
            while(i<listBox2.Items.Count)
            {
                if (listBox2.GetSelected(i))
                    f = true;
                i++;
            }
            if (f)
            {
                switch (WordList[listBox1.SelectedItem as Word].Remove(listBox2.SelectedItem as Word))
                {
                    case true: MessageBox.Show($"You have successfully removed the translation {(listBox2.SelectedItem as Word).Word_} of the word {(listBox1.SelectedItem as Word).Word_}");
                        listBox2.Items.Remove(listBox2.SelectedItem as Word);if ((WordList[listBox1.SelectedItem as Word].Count == 0)) { WordList.Remove(listBox1.SelectedItem as Word); listBox1.Items.Remove(listBox1.SelectedItem as Word); } break;
                    case false: MessageBox.Show("You didn't choose any of the words", "Warning", MessageBoxButtons.OK); break;
                }
            }
            else
            {
                MessageBox.Show("You didn't choose any of the translations","Warning",MessageBoxButtons.OK);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (listBox1.SelectedItem as Word != null)
            {
                foreach (var item in WordList[listBox1.SelectedItem as Word])
                {
                    listBox2.Items.Add(item);
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem as Word != null)
            {
                saveFileDialog1.Title = "Save to:";
                saveFileDialog1.AddExtension = true;
                saveFileDialog1.DefaultExt = ".txt";
                saveFileDialog1.Filter = "Translation|*.txt";
                if(saveFileDialog1.ShowDialog()==DialogResult.OK&&saveFileDialog1.FileName.Length>0&&saveFileDialog1.CheckPathExists)
                {
                    using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                    {
                        using (StreamWriter sw = new StreamWriter(stream))
                        {
                            sw.WriteLine($"The \"{(listBox1.SelectedItem as Word).Word_}\" word of {(listBox1.SelectedItem as Word).lang} language can be translated as:");
                            foreach (var item in listBox2.Items)
                            {
                                sw.WriteLine($"\"{(item as Word).Word_}\" in {(item as Word).lang}");
                            }
                        }
                    }
                }
            }
        }
    }
    public class WordJson
    {
        [JsonProperty("translations")]
        public List<TempWord> json;
    }
    public class TempWord
    {
        [JsonProperty("text")]
        public string word { get; set; }
    }
    [Serializable]
    public class Word:IEquatable<Word>
    {
        public Language lang=new Language();
        public string Word_ { get; set; }= default(string);
        public Word() { }
        public Word(string w, Language l) { Word_ = w; lang=l; }
        public override string ToString()
        {
            return $"{Word_} {lang}";
        }
        public bool Equals(Word other)
        {
            return this.lang.Equals(other.lang)&&this.Word_==other.Word_;
        }


        public override int GetHashCode()
        {
            return 0;
        }
    }
    [Serializable]
    public class Language:IEquatable<Language>
    {
        [JsonProperty("language")]
        public string ShortLangForm { get; set; } = default(string);
        [JsonProperty("name")]
        public string LongLangForm { get; set; } = default(string);
        
        public override string ToString()
        {
            return LongLangForm;
        }
        public bool Equals(Language other)
        {
            return this.LongLangForm==other.LongLangForm && this.ShortLangForm == other.ShortLangForm;
        }

        public override bool Equals(object obj)
        {
            return this.LongLangForm==((obj as Language).LongLangForm) && this.ShortLangForm == (obj as Language).ShortLangForm;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
    public static class ExtensionMethod
    {
        public static object GetItemWithText(this ComboBox q,string text,List<Language>list)
        {
            return list.Find((Language l) => { return (q.Text == l.LongLangForm); });
        }
    }
    public class WordSerializer
    {
        public Word w1 { get; set; }
        public List<Word> w2 { get; set; }
    }
}
