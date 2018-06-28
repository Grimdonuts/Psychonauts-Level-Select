using LevelSelect.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
            levelSelectModel = new LevelSelectModel();
            LoadFromFile();

            if (LevelSettingsHotkeys[0] != "Press a Key")
            {
                comboBox.SelectedItem = HotkeyedSettingsLevels[0];
                label1.Content = "Hotkey: " + LevelSettingsHotkeys[0];
            }

            comboBox.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox.SelectedIndex = 0;

            lblFile.Content = lblFile.Content = "Currently Selected File: " + levelSelectModel.fileName;

            if (levelSelectModel.fileName == "Pick a File in Settings")
            {
                btnSave.IsEnabled = false;
            }
            _hookID = SetHook(_proc);

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr SetWindowsHookEx(int idHook,

            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

            IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public static LevelSelectModel levelSelectModel { get; set; }
        public static List<string> LevelSettingsHotkeys { get; set; }
        public static List<string> HotkeyedSettingsLevels { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            levelSelectModel.LevelHotkeys = LevelSettingsHotkeys;
            LevelSelectSettings levelSettings = new LevelSelectSettings(levelSelectModel);
            levelSettings.Closed += LevelSettingsClosed;
            levelSettings.ShowDialog();

        }

        public void LevelSettingsClosed(object sender, System.EventArgs e)
        {
            LoadFromFile();
            if (levelSelectModel.fileName != "Pick a File in Settings")
            {
                btnSave.IsEnabled = true;
            }
            lblFile.Content = "Currently Selected File: " + levelSelectModel.fileName;
            int index = HotkeyedSettingsLevels.IndexOf(comboBox.SelectedItem.ToString());
            if (index != -1)
            {
                label1.Content = "Hotkey: " + LevelSettingsHotkeys[index];
            }
            else
            {
                label1.Content = "Hotkey: None";
            }
            _hookID = SetHook(_proc);

        }

        public void LoadFromFile()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load("Settings.xml");

                XmlNodeList hotkeysList = doc.GetElementsByTagName("Hotkey");

                LevelSettingsHotkeys = new List<string>();
                LevelSettingsHotkeys.Add(hotkeysList[0].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[1].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[2].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[3].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[4].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[5].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[6].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[7].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[8].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[9].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[10].Attributes["key"].InnerText);
                LevelSettingsHotkeys.Add(hotkeysList[11].Attributes["key"].InnerText);

                HotkeyedSettingsLevels = new List<string>();
                HotkeyedSettingsLevels.Add(hotkeysList[0].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[1].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[2].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[3].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[4].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[5].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[6].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[7].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[8].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[9].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[10].Attributes["level"].InnerText);
                HotkeyedSettingsLevels.Add(hotkeysList[11].Attributes["level"].InnerText);

                levelSelectModel.fileName = doc.GetElementsByTagName("File").Item(0).Attributes["filename"].InnerText;
                levelSelectModel.filePath = doc.GetElementsByTagName("File").Item(0).Attributes["filepath"].InnerText;
            }
            catch
            {
                LevelSettingsHotkeys = new List<string>();
                LevelSettingsHotkeys.Add("None");
                HotkeyedSettingsLevels = new List<string>();
                HotkeyedSettingsLevels.Add("Basic Braining 1");
                try
                {
                    levelSelectModel.fileName = doc.GetElementsByTagName("File").Item(0).Attributes["filepath"].InnerText;
                }
                catch
                {
                    levelSelectModel.fileName = "Pick a File in Settings";
                }

            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = HotkeyedSettingsLevels.IndexOf(comboBox.SelectedItem.ToString());
            if (index != -1)
            {
                label1.Content = "Hotkey: " + LevelSettingsHotkeys[index];
            }
            else
            {
                label1.Content = "Hotkey: None";
            }
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;


        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }


        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)

            {
                int vkCode = Marshal.ReadInt32(lParam);
                LevelSelectModel.KeyDefinitions keysDef;
                Debug.WriteLine(vkCode);
                for (int i = 0; i < LevelSettingsHotkeys.Count(); i++)
                {
                    if (Enum.TryParse(LevelSettingsHotkeys[i], out keysDef))
                    {
                        if (vkCode == (int)keysDef)
                        {
                            KeyBindSave(i);
                        }
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public static void KeyBindSave(int index)
        {
            var fileContents = File.ReadAllLines(levelSelectModel.filePath);
            fileContents[0] = "\0\0\0\0\0\0\0\0" + LevelSelectModel.Levels.FirstOrDefault(x => x.Value == HotkeyedSettingsLevels[index]).Value;
            fileContents[1] = LevelSelectModel.Levels.FirstOrDefault(x => x.Value == HotkeyedSettingsLevels[index]).Key;
            File.WriteAllLines(levelSelectModel.filePath, fileContents);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            var fileContents = File.ReadAllLines(levelSelectModel.filePath);
            fileContents[0] = "\0\0\0\0\0\0\0\0" + LevelSelectModel.Levels.FirstOrDefault(x => x.Value == comboBox.SelectedValue.ToString()).Value;
            fileContents[1] = LevelSelectModel.Levels.FirstOrDefault(x => x.Value == comboBox.SelectedValue.ToString()).Key;
            File.WriteAllLines(levelSelectModel.filePath, fileContents);
            lblSaved.Content = "Saved!";
            TimedAction.ExecuteWithDelay(new Action(delegate { lblSaved.Content = ""; }), TimeSpan.FromSeconds(2));

        }
    }

}

