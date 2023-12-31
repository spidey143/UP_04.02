﻿using InspectionBoard.Models;
using InspectionBoard.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public EditStudentWindow()
        {
            InitializeComponent();
            DataContext = new AddStudentVM();
            Gender_Check(AddStudentVM.SelectedStudent);
            Invalid_Check(AddStudentVM.SelectedStudent);
            Sirota_Check(AddStudentVM.SelectedStudent);
            Admission_Check(AddStudentVM.SelectedStudent);

            Specials.ItemsSource = (new string[]
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
            Special_Checked(AddStudentVM.SelectedStudent);

            EducationMethod.ItemsSource = (new string[] { "Бюджет", "По договору об оказании платных услуг" });
            EducationMethod_Checked(AddStudentVM.SelectedStudent);

            Countries.ItemsSource = (new string[]{
                "РФ", "Украина", "Беларусь", "Казахстан",
                "Армения", "Азербайджан", "Грузия", "Молдова",
                "Таджикистан", "Туркменистан", "Узбекистан", "Киргизия", "Другое..."});
            Countries_Checked(AddStudentVM.SelectedStudent);
            Check_Education(AddStudentVM.SelectedStudent);
        }

        #region работа с фотками
        private void Download_Invalid_Img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                string fileBytes = File.ReadAllText(filePath);
                Invalid_Img.Text = filePath;
                Invalid_Img_Bytes.Text = fileBytes;
                AddStudentVM.newInvalidImg = Encoding.UTF8.GetBytes(Invalid_Img_Bytes.Text);
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
                Sirota_Img.Text = filePath;
                Sirota_Img_Bytes.Text = fileBytes;
                AddStudentVM.newSirotaImg = Encoding.UTF8.GetBytes(Sirota_Img_Bytes.Text);
            }
        }

        private void Download_Attestat_Img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.PNG;*.JPG)|*.PNG;*.JPG";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                string fileBytes = File.ReadAllText(filePath);
                Attestat_Img.Text = filePath;
                Attestat_Img_Bytes.Text = fileBytes;
                AddStudentVM.newAttestatImg = Encoding.UTF8.GetBytes(Attestat_Img_Bytes.Text);
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
            AddStudentVM.newInvalid = "да";
        }
        private void radio_button_no1_Checked(object sender, RoutedEventArgs e)
        {
            Invalid_Img.Visibility = Visibility.Hidden;
            Button_Download_Invalid_Img.Visibility = Visibility.Hidden;
            AddStudentVM.newInvalid = "нет";
        }

        private void radio_button_yes2_Checked(object sender, RoutedEventArgs e)
        {
            Sirota_Img.Visibility = Visibility.Visible;
            Button_Download_Sirota_Img.Visibility = Visibility.Visible;
            AddStudentVM.newSirota = "да";
        }
        private void radio_button_no2_Checked(object sender, RoutedEventArgs e)
        {
            Sirota_Img.Visibility = Visibility.Hidden;
            Button_Download_Sirota_Img.Visibility = Visibility.Hidden;
            AddStudentVM.newSirota = "нет";
        }

        private void radio_button_yes3_Checked(object sender, RoutedEventArgs e)
        {
            AddStudentVM.newAdmission = "да";
            Year_of_admission.Content = DateTime.Now.Year + " год";
        }

        private void radio_button_no3_Checked(object sender, RoutedEventArgs e)
        {
            AddStudentVM.newAdmission = "нет";
            Year_of_admission.Content = "";
        }

        #endregion

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        public void Gender_Check(Student student)
        {
            if (student.Gender == "мужской")
            {
                Man.IsChecked = true;
            }

            if (student.Gender == "женский")
            {
                Fem.IsChecked = true;
            }
        }

        public void Admission_Check(Student student)
        {
            if (student.Admission == "да") radio_button_yes3.IsChecked = true;
            else radio_button_no3.IsChecked = true;
        }

        public void Invalid_Check(Student student)
        {
            if (student.Invalid == "да") radio_button_yes1.IsChecked = true;
            else radio_button_no1.IsChecked = true;
        }

        public void Sirota_Check(Student student)
        {
            if (student.Sirota == "да") radio_button_yes2.IsChecked = true;
            else radio_button_no2.IsChecked = true;
        }

        public void Education_Check(Student student)
        {
            if (student.Education == "9 классов") radiobutton_checked_3.IsChecked = true;
            else radiobutton_checked_5.IsChecked = true;
        }


        private void Man_Checked(object sender, RoutedEventArgs e)
        {
            AddStudentVM.newGender = "мужской";
        }

        private void Fem_Checked(object sender, RoutedEventArgs e)
        {
            AddStudentVM.newGender = "женский";
        }

        public void Special_Checked(Student student)
        {
            switch (student.Speciality)
            {
                case "07.02.01 «Архитектура»":
                    Specials.SelectedItem = "07.02.01 «Архитектура»";
                    break;
                case "08.02.01 «Строительство и эксплуатация зданий и сооружений»":
                    Specials.SelectedItem = "08.02.01 «Строительство и эксплуатация зданий и сооружений»";
                    break;
                case "09.02.03 «Программирование в компьютерных системах»":
                    Specials.SelectedItem = "09.02.03 «Программирование в компьютерных системах»";
                    break;
                case "09.02.07 «Информационные системы и программирование»":
                    Specials.SelectedItem = "09.02.07 «Информационные системы и программирование»";
                    break;
                case "11.02.14 «Электронные приборы и устройства»":
                    Specials.SelectedItem = "11.02.14 «Электронные приборы и устройства»";
                    break;
                case "38.02.01 «Экономика и бухгалтерский отчет (по отраслям)»":
                    Specials.SelectedItem = "38.02.01 «Экономика и бухгалтерский отчет (по отраслям)»";
                    break;
                case "11.02.02 «Техническое обслуживание и ремонт радиоэлектронной техники (по отраслям)»":
                    Specials.SelectedItem = "11.02.02 «Техническое обслуживание и ремонт радиоэлектронной техники (по отраслям)»";
                    break;
                default:
                    student.Speciality = null;
                    break;
            }

        }

        public void EducationMethod_Checked(Student student)
        {
            switch (student.EducationalMethod)
            {
                case "Бюджет":
                    EducationMethod.SelectedItem = "Бюджет";
                    break;
                case "По договору об оказании платных услуг":
                    EducationMethod.SelectedItem = "По договору об оказании платных услуг";
                    break;
                default:
                    student.EducationalMethod = null;
                    break;
            }

        }

        private void Specials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddStudentVM.newSpecial = Convert.ToString(Specials.SelectedItem.ToString());
        }

        private void EducationMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddStudentVM.newEdumethod = Convert.ToString(EducationMethod.SelectedItem.ToString());
        }


        public void Countries_Checked(Student student)
        {
            switch (student.Nationality)
            {
                case "РФ":
                    Countries.SelectedItem = "РФ";
                    break;
                case "Украина":
                    Countries.SelectedItem = "Украина";
                    break;
                case "Беларусь":
                    Countries.SelectedItem = "Беларусь";
                    break;
                case "Казахстан":
                    Countries.SelectedItem = "Казахстан";
                    break;
                case "Армения":
                    Countries.SelectedItem = "Армения";
                    break;
                case "Азербайджан":
                    Countries.SelectedItem = "Азербайджан";
                    break;
                case "Грузия":
                    Countries.SelectedItem = "Грузия";
                    break;
                case "Молдова":
                    Countries.SelectedItem = "Молдова";
                    break;
                case "Таджикистан":
                    Countries.SelectedItem = "Таджикистан";
                    break;
                case "Туркменистан":
                    Countries.SelectedItem = "Туркменистан";
                    break;
                case "Узбекистан":
                    Countries.SelectedItem = "Узбекистан";
                    break;
                case "Киргизия":
                    Countries.SelectedItem = "Киргизия";
                    break;
                default:
                    student.Nationality = null;
                    break;
            }

        }

        private void Countries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToString(Countries.SelectedItem.ToString()).Contains("Другое"))
            {
                OtherNation.Visibility = Visibility.Visible;
                AddStudentVM.newNation = OtherNation.Text;
            }
            else
            {
                OtherNation.Visibility = Visibility.Hidden;
                AddStudentVM.newNation = Convert.ToString(Countries.SelectedItem.ToString());
            }
        }

        private void Update_Snils(Student student)
        {
            AddStudentVM.newSnils = Snils.Text;
        }

        private void Snils_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update_Snils(AddStudentVM.SelectedStudent);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            PlaceOfRes newplaceOfRes = new PlaceOfRes();
            newplaceOfRes.ShowDialog();
            Show();
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            AddStudentVM.newEducation = "9 классов";
            Education.Visibility = Visibility.Hidden;
        }
        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            AddStudentVM.newEducation = "11 классов";
            Education.Visibility = Visibility.Hidden;
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            Education.Text = null;
            Education.Visibility = Visibility.Visible;
        }

        private void Check_Education(Student student)
        {
            if (student.Education == "9 классов") radiobutton_checked_3.IsChecked = true;
            else if (student.Education == "11 классов") radiobutton_checked_5.IsChecked = true;
            else radiobutton_checked_4.IsChecked = true;
        }
    }
}
          
           
