using LevelSelect.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace LevelSelect.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LevelSelector : Window
    {


        public LevelSelector()
        {
            InitializeComponent();

            LoadFromFile();

            if (LevelHotkeys[0] != "Press a Key")
            {
                comboBox.SelectedItem = HotkeyedLevels[0];
                label1.Content = "Hotkey: " + LevelHotkeys[0];
            }

            comboBox.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox.SelectedIndex = 0;
        }

        public List<string> LevelHotkeys { get; set; }
        public List<string> HotkeyedLevels { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            LevelSelectSettings levelSettings = new LevelSelectSettings(LevelHotkeys);
            levelSettings.Closed += LevelSettingsClosed;
            levelSettings.ShowDialog();

            //var fileContents = File.ReadAllLines("C:/Program Files (x86)/Steam/steamapps/common/Psychonauts/Profiles/Profile 2/SavedGame0");
            //fileContents[1] = LevelSelectModel.Levels.FirstOrDefault(x=> x.Value == comboBox.SelectedValue.ToString()).Key;
            //File.WriteAllLines("C:/Program Files (x86)/Steam/steamapps/common/Psychonauts/Profiles/Profile 2/SavedGame0", fileContents);
        }

        public void LevelSettingsClosed(object sender, System.EventArgs e)
        {
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load("Settings.xml");
                XmlNodeList hotkeysList = doc.GetElementsByTagName("Hotkey");

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

                HotkeyedLevels = new List<string>();
                HotkeyedLevels.Add(hotkeysList[0].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[1].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[2].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[3].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[4].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[5].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[6].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[7].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[8].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[9].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[10].Attributes["level"].InnerText);
                HotkeyedLevels.Add(hotkeysList[11].Attributes["level"].InnerText);

            }
            // keep blank to prevent crash on empty file or not enough elements found
            catch
            {

            }
        }

        private HwndSource _source;
        private const int HOTKEY_ID = 9000;


        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID:
                            OnHotKeyPressed();
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        private void OnHotKeyPressed()
        {
            // do stuff
        }

        private List<Key> _pressed = new List<Key>();

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (_pressed.Contains(e.Key)) return;
            _pressed.Add(e.Key);

        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _pressed.Remove(e.Key);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = HotkeyedLevels.IndexOf(comboBox.SelectedItem.ToString());
            if (index != -1)
            {
                label1.Content = "Hotkey: " + LevelHotkeys[index];
            }
            else
            {
                label1.Content = "Hotkey: None";
            }
        }
    }
}
