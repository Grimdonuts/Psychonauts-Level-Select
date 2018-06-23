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

            
            comboBox.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox.SelectedIndex = 0;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
                LevelSelectSettings levelSettings = new LevelSelectSettings();
                levelSettings.Show();

            //var fileContents = File.ReadAllLines("C:/Program Files (x86)/Steam/steamapps/common/Psychonauts/Profiles/Profile 2/SavedGame0");
            //fileContents[1] = LevelSelectModel.Levels.FirstOrDefault(x=> x.Value == comboBox.SelectedValue.ToString()).Key;
            //File.WriteAllLines("C:/Program Files (x86)/Steam/steamapps/common/Psychonauts/Profiles/Profile 2/SavedGame0", fileContents);
        }

        public LevelSelectModel LevelSelect { get; set; }

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
    }
}
