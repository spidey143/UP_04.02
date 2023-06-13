using InspectionBoard.Models;
using InspectionBoard.ViewModels;
using Microsoft.Win32;
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

namespace InspectionBoard.Views
{
    /// <summary>
    /// Логика взаимодействия для EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public EditStudentWindow()
        {
            InitializeComponent();
            DataContext = new AddStudentVM();
            Gender_Check(AddStudentVM.SelectedStudent);
        }
        private void Download_Photo_Disabled_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                Photo_Disabled.Text = fileName;
            }
        }

        private void Download_Photo_Orphanage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                Photo_Orphanage.Text = fileName;
            }
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
            Photo_Disabled.Visibility = Visibility.Visible;
            Button_Download_Photo_Disabled.Visibility = Visibility.Visible;
        }
        private void radio_button_no1_Checked(object sender, RoutedEventArgs e)
        {
            Photo_Disabled.Visibility = Visibility.Hidden;
            Button_Download_Photo_Disabled.Visibility = Visibility.Hidden;
        }

        private void radio_button_yes2_Checked(object sender, RoutedEventArgs e)
        {
            Photo_Orphanage.Visibility = Visibility.Visible;
            Button_Download_Photo_Orphanage.Visibility = Visibility.Visible;
        }
        private void radio_button_no2_Checked(object sender, RoutedEventArgs e)
        {
            Photo_Orphanage.Visibility = Visibility.Hidden;
            Button_Download_Photo_Orphanage.Visibility = Visibility.Hidden;
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

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        public void Gender_Check(Student student)
        {
            if (student.Gender == "мужской") {
                Man.IsChecked = true;
                student.Gender = "мужской";
            }
            if (student.Gender == "женский") {
                Fem.IsChecked = true;
                student.Gender = "женский";
            }
        }

    }
}
