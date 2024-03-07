using Dictionary.Exceptions;
using Dictionary.Extensions;
using Dictionary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Dictionary
{
    public partial class DictionaryApp : Form
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly Dictionary<Word, HashSet<Word>> _wordTranslations = new Dictionary<Word, HashSet<Word>>();
        private readonly List<Language> _languages = new List<Language>();

        public DictionaryApp()
        {
            InitializeComponent();
            LoadLangs();
        }

        private void LoadLangs()
        {
            _languages.AddRange(_client.GetLanguageList());
            TranslationLanguageComboBox.Items.AddRange(_languages.ToArray());
        }

        private void InputWordClearBtn_Click(object sender, EventArgs e)
        {
            OriginalWordTextBox.ResetText();
            TranslationTextBox.ResetText();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            TranslationLanguageComboBox.ResetText();
        }

        private void TranslateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OriginalWordTextBox.Text))
            {
                throw new EmptyOriginalWordError("You need first to enter a word that will be translated");
            }

            var language = TranslationLanguageComboBox.SelectedItem as Language;

            var newTranslation = _client.GetWordTranslation(
                OriginalWordTextBox.Text,
                language.ShortForm);

            var translatedWord = new Word()
            {
                Language = newTranslation.Language,
                WordText = OriginalWordTextBox.Text
            };

            newTranslation.Language = language.ShortForm;

            var getResult = _wordTranslations.TryGetValue(
                translatedWord,
                out var words);

            if (getResult == false)
            {
                _wordTranslations[translatedWord] = new HashSet<Word> { newTranslation };
            }
            else
            {
                words.Add(newTranslation);
            }

            OriginalWords.Items.Clear();
            OriginalWords.Items.AddRange(_wordTranslations.Keys.ToArray());
        }

        private void OriginalWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            WordTranslations.Items.Clear();
            if ((OriginalWords.SelectedItem as Word) != null)
            {
                WordTranslations.Items.AddRange(_wordTranslations[OriginalWords.SelectedItem as Word].ToArray());
            }
        }

        private void LoadFromFileBtn_Click(object sender, EventArgs e)
        {
            var fileName = ShowOpenFileDialog("XML files(*.xml) | *.xml");

            using (var stream = new FileStream(
                fileName,
                FileMode.Open))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<(Word, HashSet<Word>)>));
                var dict = (List<(Word, HashSet<Word>)>)xmlSerializer.Deserialize(stream);

                foreach (var item in dict)
                {
                    if (_wordTranslations.TryGetValue(item.Item1, out var oldTranslations))
                    {
                        foreach (var translation in item.Item2)
                        {
                            oldTranslations.Add(translation);
                        }
                    }
                    else
                    {
                        _wordTranslations[item.Item1] = item.Item2;
                    }
                }

                OriginalWords.Items.Clear();
                OriginalWords.Items.AddRange(_wordTranslations.Keys.ToArray());
            }

            MessageBox.Show("Successfully loaded your dictionary.");
        }

        private void SaveToFileBtn_Click(object sender, EventArgs e)
        {
            var fileName = ShowSaveFileDialog("XML files(*.xml) | *.xml");

            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var xmlSerializer = new XmlSerializer(typeof(List<(Word, HashSet<Word>)>));
                xmlSerializer.Serialize(stream, _wordTranslations.Select(x => (x.Key, x.Value)).ToList());
            }

            MessageBox.Show("Successfully saved your dictionary.");
        }

        private string ShowOpenFileDialog(string filter)
        {
            var ofd = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = filter,
            };

            var dialogResult = ofd.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                throw new FileDialogError("Error while getting the file.");
            }

            return ofd.FileName;
        }

        private string ShowSaveFileDialog(string filter)
        {
            var ofd = new SaveFileDialog()
            {
                CheckPathExists = true,
                Filter = filter,
            };

            var dialogResult = ofd.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                throw new FileDialogError("Error while getting the file.");
            }

            return ofd.FileName;
        }

        private void DeleteTranslationBtn_Click(object sender, EventArgs e)
        {
            _wordTranslations[OriginalWords.SelectedItem as Word].Remove(WordTranslations.SelectedItem as Word);
            WordTranslations.Items.Clear();
            WordTranslations.Items.AddRange(_wordTranslations[OriginalWords.SelectedItem as Word].ToArray());
        }

        private void DeleteOriginalWordBtn_Click(object sender, EventArgs e)
        {
            _wordTranslations.Remove(OriginalWords.SelectedItem as Word);
            WordTranslations.Items.Clear();
            OriginalWords.Items.Clear();
            OriginalWords.Items.AddRange(_wordTranslations.Keys.ToArray());
        }
    }
}