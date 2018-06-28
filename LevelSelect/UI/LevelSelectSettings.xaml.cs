using LevelSelect.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace LevelSelect.UI
{
    /// <summary>
    /// Interaction logic for LevelSelectSettings.xaml
    /// </summary>
    public partial class LevelSelectSettings : Window
    {
        public LevelSelectSettings(LevelSelectModel levelSelectModel)
        {
            InitializeComponent();

            comboBox1.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox1.SelectedIndex = 0;
            comboBox2.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox2.SelectedIndex = 1;
            comboBox3.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox3.SelectedIndex = 2;
            comboBox4.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox4.SelectedIndex = 3;
            comboBox5.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox5.SelectedIndex = 4;
            comboBox6.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox6.SelectedIndex = 5;
            comboBox7.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox7.SelectedIndex = 6;
            comboBox8.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox8.SelectedIndex = 7;
            comboBox9.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox9.SelectedIndex = 8;
            comboBox10.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox10.SelectedIndex = 9;
            comboBox11.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox11.SelectedIndex = 10;
            comboBox12.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox12.SelectedIndex = 11;
            lblFileSelection.Content = levelSelectModel.fileName;

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load("Settings.xml");
                XmlNodeList hotkeysList = doc.GetElementsByTagName("Hotkey");

                textBox1.Text = hotkeysList[0].Attributes["key"].InnerText;
                comboBox1.SelectedItem = hotkeysList[0].Attributes["level"].InnerText;
                textBox2.Text = hotkeysList[1].Attributes["key"].InnerText;
                comboBox2.SelectedItem = hotkeysList[1].Attributes["level"].InnerText;
                textBox3.Text = hotkeysList[2].Attributes["key"].InnerText;
                comboBox3.SelectedItem = hotkeysList[2].Attributes["level"].InnerText;
                textBox4.Text = hotkeysList[3].Attributes["key"].InnerText;
                comboBox4.SelectedItem = hotkeysList[3].Attributes["level"].InnerText;
                textBox5.Text = hotkeysList[4].Attributes["key"].InnerText;
                comboBox5.SelectedItem = hotkeysList[4].Attributes["level"].InnerText;
                textBox6.Text = hotkeysList[5].Attributes["key"].InnerText;
                comboBox6.SelectedItem = hotkeysList[5].Attributes["level"].InnerText;
                textBox7.Text = hotkeysList[6].Attributes["key"].InnerText;
                comboBox7.SelectedItem = hotkeysList[6].Attributes["level"].InnerText;
                textBox8.Text = hotkeysList[7].Attributes["key"].InnerText;
                comboBox8.SelectedItem = hotkeysList[7].Attributes["level"].InnerText;
                textBox9.Text = hotkeysList[8].Attributes["key"].InnerText;
                comboBox9.SelectedItem = hotkeysList[8].Attributes["level"].InnerText;
                textBox10.Text = hotkeysList[9].Attributes["key"].InnerText;
                comboBox10.SelectedItem = hotkeysList[9].Attributes["level"].InnerText;
                textBox11.Text = hotkeysList[10].Attributes["key"].InnerText;
                comboBox11.SelectedItem = hotkeysList[10].Attributes["level"].InnerText;
                textBox12.Text = hotkeysList[11].Attributes["key"].InnerText;
                comboBox12.SelectedItem = hotkeysList[11].Attributes["level"].InnerText;

                if (!levelSelectModel.LevelHotkeys.Any())
                {
                    LevelHotkeys = new List<string>();
                    LevelHotkeys.Add(hotkeysList[0].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[1].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[2].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[3].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[4].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[5].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[6].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[7].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[8].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[9].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[10].Attributes["key"].InnerText);
                    LevelHotkeys.Add(hotkeysList[11].Attributes["key"].InnerText);
                }
                else
                {
                    LevelHotkeys = levelSelectModel.LevelHotkeys;
                }
            }
            // keep blank to prevent crash on empty file or not enough elements found
            catch
            {
                    LevelHotkeys = new List<string>();
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");
                    LevelHotkeys.Add("Press a Key");

            }

            if (levelSelectModel.fileName == "Pick a File in Settings")
            {
                textBox1.IsEnabled = false;
                textBox2.IsEnabled = false;
                textBox3.IsEnabled = false;
                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;
                textBox6.IsEnabled = false;
                textBox7.IsEnabled = false;
                textBox8.IsEnabled = false;
                textBox9.IsEnabled = false;
                textBox10.IsEnabled = false;
                textBox11.IsEnabled = false;
                textBox12.IsEnabled = false;
                lblFileSelection.Content = "Pick a File";
            }

        }

        public List<string> LevelHotkeys { get; set; }
        public LevelSelector ParentWindow { get; internal set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();

                XmlNodeList hotkeysList = doc.GetElementsByTagName("Hotkey");

                doc.LoadXml("<Settings></Settings>");
                XmlElement entryElement = doc.DocumentElement;
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox1.Text);
                entryElement.SetAttribute("level", comboBox1.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox2.Text);
                entryElement.SetAttribute("level", comboBox2.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox3.Text);
                entryElement.SetAttribute("level", comboBox3.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox4.Text);
                entryElement.SetAttribute("level", comboBox4.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox5.Text);
                entryElement.SetAttribute("level", comboBox5.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox6.Text);
                entryElement.SetAttribute("level", comboBox6.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox7.Text);
                entryElement.SetAttribute("level", comboBox7.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox8.Text);
                entryElement.SetAttribute("level", comboBox8.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox9.Text);
                entryElement.SetAttribute("level", comboBox9.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox10.Text);
                entryElement.SetAttribute("level", comboBox10.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox11.Text);
                entryElement.SetAttribute("level", comboBox11.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);
                entryElement = doc.CreateElement("Hotkey");
                entryElement.SetAttribute("key", textBox12.Text);
                entryElement.SetAttribute("level", comboBox12.SelectedItem.ToString());
                doc.DocumentElement.AppendChild(entryElement);

            if (lblFileSelection.Content.ToString() != "Pick a File")
            {
                entryElement = doc.CreateElement("File");
                entryElement.SetAttribute("filename", LevelSelector.levelSelectModel.fileName);
                entryElement.SetAttribute("filepath", LevelSelector.levelSelectModel.filePath);
                doc.DocumentElement.AppendChild(entryElement);
            }
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            // Save the document to a file and auto-indent the output.
            XmlWriter writer = XmlWriter.Create("Settings.xml", settings);
            doc.Save(writer);
            writer.Close();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.SafeFileName == "SavedGame0")
                {
                    MessageBox.Show("Pick a different save file. the autosave file has known issues.");
                }
                else if (!openFileDialog.SafeFileName.Contains("SavedGame"))
                {
                    MessageBox.Show("Not a recognized save file.");
                }
                else
                {
                    if (ProperFile(openFileDialog.FileName))
                    {
                        lblFileSelection.Content = openFileDialog.SafeFileName;
                        LevelSelector.levelSelectModel.fileName = openFileDialog.SafeFileName;
                        LevelSelector.levelSelectModel.filePath = openFileDialog.FileName;

                        textBox1.IsEnabled = true;
                        textBox2.IsEnabled = true;
                        textBox3.IsEnabled = true;
                        textBox4.IsEnabled = true;
                        textBox5.IsEnabled = true;
                        textBox6.IsEnabled = true;
                        textBox7.IsEnabled = true;
                        textBox8.IsEnabled = true;
                        textBox9.IsEnabled = true;
                        textBox10.IsEnabled = true;
                        textBox11.IsEnabled = true;
                        textBox12.IsEnabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Not a valid save file, pick one that exists in your profile within Psychonauts and not the autosave.");
                    }
                }
            }
        }

        public bool ProperFile(string fileName)
        {
            var fileContents = File.ReadAllLines(fileName);
            if (fileContents.Count() < 2)
            {
                return false;
            }
            return true;
        }

        #region textbox handlers

        private string FormatKey(KeyEventArgs e)
        {
            if (e.Key >= Key.F1 && e.Key <= Key.F12)
            {
                return e.Key.ToString();
            }
            else if (e.SystemKey == Key.F10)
            {
                return "F10";
            }
            else
            {
                switch(e.Key)
                {
                    case Key.OemTilde:
                    case Key.NumPad0:
                    case Key.NumPad1:
                    case Key.NumPad2:
                    case Key.NumPad3:
                    case Key.NumPad4:
                    case Key.NumPad5:
                    case Key.NumPad6:
                    case Key.NumPad7:
                    case Key.NumPad8:
                    case Key.NumPad9:
                    case Key.OemBackslash:
                    case Key.Multiply:
                    case Key.Subtract:
                    case Key.Add:
                    case Key.Divide:
                    case Key.Decimal:
                    case Key.OemComma:
                    case Key.OemCloseBrackets:
                    case Key.OemOpenBrackets:
                    case Key.OemPipe:
                    case Key.OemSemicolon:
                    case Key.OemQuotes:
                    case Key.OemQuestion:
                    case Key.OemPlus:
                    case Key.OemPeriod:
                    case Key.OemMinus:
                        return "";
                    default:
                        return e.Key.ToString();
                }
            }
        }

        public void RefreshBoxes()
        {
            textBox1.Text = LevelHotkeys[0];
            textBox2.Text = LevelHotkeys[1];
            textBox3.Text = LevelHotkeys[2];
            textBox4.Text = LevelHotkeys[3];
            textBox5.Text = LevelHotkeys[4];
            textBox6.Text = LevelHotkeys[5];
            textBox7.Text = LevelHotkeys[6];
            textBox8.Text = LevelHotkeys[7];
            textBox9.Text = LevelHotkeys[8];
            textBox10.Text = LevelHotkeys[9];
            textBox11.Text = LevelHotkeys[10];
            textBox12.Text = LevelHotkeys[11];
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            char tbNumber1 = tb.Name[tb.Name.Length - 1];
            char tbNumber2 = tb.Name[tb.Name.Length - 2];
            int finalTbNumber = 0;
            if (tbNumber2 != 'x')
            {
                string finalNumber = Char.GetNumericValue(tbNumber2).ToString() + Char.GetNumericValue(tbNumber1).ToString();
                finalTbNumber = Convert.ToInt32(finalNumber);
            }
            else
            {
                finalTbNumber = (int)Char.GetNumericValue(tbNumber1);
            }
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[finalTbNumber - 1] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[finalTbNumber - 1] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[finalTbNumber - 1] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[finalTbNumber - 1] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                
                tb.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                tb.Text = "";
            }
            else
            {
                e.Handled = true;
            }

        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
        }

        private void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            char tbNumber1 = tb.Name[tb.Name.Length - 1];
            char tbNumber2 = tb.Name[tb.Name.Length - 2];
            int finalTbNumber = 0;
            if (tbNumber2 != 'x')
            {
                string finalNumber = Char.GetNumericValue(tbNumber2).ToString() + Char.GetNumericValue(tbNumber1).ToString();
                finalTbNumber = Convert.ToInt32(finalNumber);
            }
            else
            {
                finalTbNumber = (int)Char.GetNumericValue(tbNumber1);
            }
            if (tb.Text == "" && LevelHotkeys[finalTbNumber - 1] == "")
            {
                tb.Text = "Press a Key";
                LevelHotkeys[finalTbNumber - 1] = "Press a Key";
            }
            else
            {
                tb.Text = LevelHotkeys[finalTbNumber - 1];
            }
        }

       
        #endregion

    }
}
