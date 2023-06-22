using DocumentFormat.OpenXml.Vml;
using InspectionBoard.Models;
using InspectionBoard.Models.Data;
using InspectionBoard.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
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

namespace InspectionBoard.Views
{
    /// <summary>
    /// Логика взаимодействия для AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            InitializeComponent();
            DataContext = new AddStudentVM();
            Special.ItemsSource = (new string[]
        {
            "07.02.01 «Архитектура»",
            "08.02.01 «Строительство и эксплуатация зданий и сооружений»",
            "09.02.03 «Программирование в компьютерных системах»",
            "09.02.07 «Информационные системы и программирование»",
            "11.02.14 «Электронные приборы и устройства»",
            "21.02.09 «Гидрогеология и инженерная геология»",
            "38.02.01 «Экономика и бухгалтерский отчет (по отраслям)»",
            "11.02.02 «Техническое обслуживание и ремонт радиоэлектронной техники (по отраслям)»"
        });
            EducationMethod.ItemsSource = (new string[] { "Бюджет", "По договору об оказании платных услуг" });
            Countries.ItemsSource = (new string[]{
                "РФ", "Украина", "Беларусь", "Казахстан",
                "Армения", "Азербайджан", "Грузия", "Молдова",
                "Таджикистан", "Туркменистан", "Узбекистан", "Киргизия", "Другое..."});
        }

        #region Команды для загрузки фото
        private void Download_Invalid_Img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                string fileBytes = File.ReadAllText(filePath);
                Invalid_Img.Text = fileName;
                Invalid_Img_Bytes.Text = fileBytes;
            }
        }

        
        private void Download_Sirota_Img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                string fileBytes = File.ReadAllText(filePath);
                Sirota_Img.Text = fileName;
                Sirota_Img_Bytes.Text= fileBytes;
            }
        }

        private void Download_Sirota_Img_Db_Click(object sender, RoutedEventArgs e)
        {
            AddStudentVM.SirotaImg = System.Text.Encoding.UTF8.GetBytes(Sirota_Img_Bytes.Text);
        }

        private void Download_Invalid_Img_Db_Click(object sender, RoutedEventArgs e)
        {
            AddStudentVM.InvalidImg = System.Text.Encoding.UTF8.GetBytes(Invalid_Img_Bytes.Text);
        }



        private void Download_Attestat_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                Photo_Attestat.Text = fileName;
            }
        }
        #endregion

        #region Команда для подсчета лет
        private void DateOfBirth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DateOfBirth.Text.Length == 10)
            {
                string date = DateOfBirth.Text;
                string[] date_arr = date.Split('.');
                int year = int.Parse(date_arr[2]);
                int month = int.Parse(date_arr[1]);
                int day = int.Parse(date_arr[0]);
                DateTime year_of_birth = new DateTime(year, month, day);
                TimeSpan diff = DateTime.Now - year_of_birth;
                int age = diff.Days / 365;
                Console.WriteLine(year_of_birth);
                Console.WriteLine(diff);
                Age.Text = age.ToString() + " лет";
            }
        }
        #endregion

        #region Команды для radiobutton
        private void radio_button_yes1_Checked(object sender, RoutedEventArgs e)
        {
            Invalid_Img.Visibility = Visibility.Visible;
            Button_Download_Invalid_Img.Visibility = Visibility.Visible;
            Button_Download_Invalid_Img_Db.Visibility = Visibility.Visible;
            AddStudentVM.Invalid = "да";
        }
        private void radio_button_no1_Checked(object sender, RoutedEventArgs e)
        {
            Invalid_Img.Visibility = Visibility.Hidden;
            Button_Download_Invalid_Img.Visibility = Visibility.Hidden;
            Button_Download_Invalid_Img_Db.Visibility = Visibility.Hidden;
            AddStudentVM.Invalid = "нет";
        }

        private void radio_button_yes2_Checked(object sender, RoutedEventArgs e)
        {
            Sirota_Img.Visibility = Visibility.Visible;
            Button_Download_Sirota_Img.Visibility = Visibility.Visible;
            Button_Download_Sirota_Img_Db.Visibility = Visibility.Visible;
            AddStudentVM.Sirota = "да";
        }
        private void radio_button_no2_Checked(object sender, RoutedEventArgs e)
        {
            Sirota_Img.Visibility = Visibility.Hidden;
            Button_Download_Sirota_Img.Visibility = Visibility.Hidden;
            Button_Download_Sirota_Img_Db.Visibility = Visibility.Hidden;
            AddStudentVM.Sirota = "нет";
        }

        private void radio_button_yes3_Checked(object sender, RoutedEventArgs e)
        {
            AddStudentVM.Admission = "да";
            Year_of_admission.Content = DateTime.Now.Year + " год";
        }

        private void radio_button_no3_Checked(object sender, RoutedEventArgs e)
        {
            AddStudentVM.Admission = "нет";
            Year_of_admission.Content = "";
        }

        #endregion

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

        }
        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            AddStudentVM.Gender = "мужской";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            AddStudentVM.Gender = "женский";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            AddStudentVM.Speciality = Convert.ToString(Special.SelectedItem.ToString());
        }

        private void EducationMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddStudentVM.EducationMethod = Convert.ToString(EducationMethod.SelectedItem.ToString());
        }

        private void Countries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToString(Countries.SelectedItem.ToString()).Contains("Другое")) Nation.Visibility = Visibility.Visible;
            else
            {
                Nation.Visibility = Visibility.Hidden;
                AddStudentVM.Nationality = Convert.ToString(Countries.SelectedItem.ToString());
            }
        }
    }
}
