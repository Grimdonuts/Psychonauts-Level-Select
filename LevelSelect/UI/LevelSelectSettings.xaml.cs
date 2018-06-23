using LevelSelect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LevelSelect.UI
{
    /// <summary>
    /// Interaction logic for LevelSelectSettings.xaml
    /// </summary>
    public partial class LevelSelectSettings : Window
    {
        public LevelSelectSettings()
        {
            InitializeComponent();

            comboBox1.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox1.SelectedIndex = 0;
            comboBox2.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox2.SelectedIndex = 0;
            comboBox3.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox3.SelectedIndex = 0;
            comboBox4.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox4.SelectedIndex = 0;
            comboBox5.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox5.SelectedIndex = 0;
            comboBox6.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox6.SelectedIndex = 0;
            comboBox7.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox7.SelectedIndex = 0;
            comboBox8.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox8.SelectedIndex = 0;
            comboBox9.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox9.SelectedIndex = 0;
            comboBox10.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox10.SelectedIndex = 0;
            comboBox11.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox11.SelectedIndex = 0;
            comboBox12.ItemsSource = LevelSelectModel.Levels.Values;
            comboBox12.SelectedIndex = 0;
        }
    }
}
