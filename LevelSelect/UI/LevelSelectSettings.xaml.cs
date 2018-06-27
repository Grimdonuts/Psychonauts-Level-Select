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

            this.Close();

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
                    case Key.D0:
                    case Key.D1:
                    case Key.D2:
                    case Key.D3:
                    case Key.D4:
                    case Key.D5:
                    case Key.D6:
                    case Key.D7:
                    case Key.D8:
                    case Key.D9:
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

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "" && LevelHotkeys[0] == "")
            {
                textBox1.Text = "Press a Key";
                LevelHotkeys[0] = "Press a Key";
            }
            else
            {
                textBox1.Text = LevelHotkeys[0];
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[0] != "Press a Key" && LevelHotkeys.FirstOrDefault(x=> x == keyPressed) != keyPressed)
            {
                LevelHotkeys[0] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[0] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[0] = keyPressed;
            }
            
            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox1.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox1.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text == "" && LevelHotkeys[1] == "")
            {
                textBox2.Text = "Press a Key";
                LevelHotkeys[1] = "Press a Key";
            }
            else
            {
                textBox2.Text = LevelHotkeys[1];
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[1] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[1] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[1] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[1] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox2.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox2.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox3.Text == "" && LevelHotkeys[2] == "")
            {
                textBox3.Text = "Press a Key";
                LevelHotkeys[2] = "Press a Key";
            }
            else
            {
                textBox3.Text = LevelHotkeys[2];
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[2] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[2] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[2] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[2] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox3.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox3.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox4_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox4.Text == "" && LevelHotkeys[3] == "")
            {
                textBox4.Text = "Press a Key";
                LevelHotkeys[3] = "Press a Key";
            }
            else
            {
                textBox4.Text = LevelHotkeys[3];
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[3] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[3] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[3] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[3] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox4.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox4.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox5_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox5.Text = "";
        }

        private void textBox5_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox5.Text == "" && LevelHotkeys[4] == "")
            {
                textBox5.Text = "Press a Key";
                LevelHotkeys[4] = "Press a Key";
            }
            else
            {
                textBox5.Text = LevelHotkeys[4];
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[4] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[4] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[4] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[4] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox5.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox5.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox6_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox6.Text = "";
        }

        private void textBox6_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox6.Text == "" && LevelHotkeys[5] == "")
            {
                textBox6.Text = "Press a Key";
                LevelHotkeys[5] = "Press a Key";
            }
            else
            {
                textBox6.Text = LevelHotkeys[5];
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[5] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[5] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[5] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[5] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox6.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox6.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox7_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox7.Text = "";
        }

        private void textBox7_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox7.Text == "" && LevelHotkeys[6] == "")
            {
                textBox7.Text = "Press a Key";
                LevelHotkeys[6] = "Press a Key";
            }
            else
            {
                textBox7.Text = LevelHotkeys[6];
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[6] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[6] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[6] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[6] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox7.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox7.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox8_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox8.Text = "";
        }

        private void textBox8_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox8.Text == "" && LevelHotkeys[7] == "")
            {
                textBox8.Text = "Press a Key";
                LevelHotkeys[7] = "Press a Key";
            }
            else
            {
                textBox8.Text = LevelHotkeys[7];
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[7] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[7] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[7] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[7] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox8.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox8.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox9_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox9.Text = "";
        }

        private void textBox9_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox9.Text == "" && LevelHotkeys[8] == "")
            {
                textBox9.Text = "Press a Key";
                LevelHotkeys[8] = "Press a Key";
            }
            else
            {
                textBox9.Text = LevelHotkeys[8];
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[8] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[8] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[8] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[8] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox9.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox9.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox10_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox10.Text = "";
        }

        private void textBox10_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox10.Text == "" && LevelHotkeys[9] == "")
            {
                textBox10.Text = "Press a Key";
                LevelHotkeys[9] = "Press a Key";
            }
            else
            {
                textBox10.Text = LevelHotkeys[9];
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[9] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[9] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[9] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[9] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox10.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox10.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox11_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox11.Text = "";
        }

        private void textBox11_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox11.Text == "" && LevelHotkeys[10] == "")
            {
                textBox11.Text = "Press a Key";
                LevelHotkeys[10] = "Press a Key";
            }
            else
            {
                textBox11.Text = LevelHotkeys[10];
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[10] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[10] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[10] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[10] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox11.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox11.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox12_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox12.Text = "";
        }

        private void textBox12_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox12.Text == "" && LevelHotkeys[11] == "")
            {
                textBox12.Text = "Press a Key";
                LevelHotkeys[11] = "Press a Key";
            }
            else
            {
                textBox12.Text = LevelHotkeys[11];
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            string keyPressed = FormatKey(e);
            if (LevelHotkeys[11] != "Press a Key" && LevelHotkeys.FirstOrDefault(x => x == keyPressed) != keyPressed)
            {
                LevelHotkeys[11] = keyPressed;
            }
            else if (LevelHotkeys.FirstOrDefault(x => x == keyPressed) == keyPressed)
            {
                int index = LevelHotkeys.FindIndex(x => x == keyPressed);
                LevelHotkeys[index] = "Press a Key";
                LevelHotkeys[11] = keyPressed;
                RefreshBoxes();
            }
            else
            {
                LevelHotkeys[11] = keyPressed;
            }

            if (e.Key >= Key.F1 && e.Key <= Key.F12 || e.SystemKey == Key.F10)
            {
                textBox12.Text = keyPressed;
            }
            else if (keyPressed != "")
            {
                textBox12.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                lblFileSelection.Content = openFileDialog.SafeFileName;
                LevelSelector.levelSelectModel.fileName = openFileDialog.SafeFileName;
                LevelSelector.levelSelectModel.filePath = openFileDialog.FileName;
            }
                
        }
    }
}
