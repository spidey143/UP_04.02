using InspectionBoard.Commands;
using InspectionBoard.Infrastructure;
using InspectionBoard.Models;
using InspectionBoard.Models.Data;
using InspectionBoard.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.ViewModels
{
    public class AddStudentVM : NotifyPropertyChangedObject
    {
        public List<Student> students = DataStudent.GetAllStudents();
        public List<Student> AllStudents
        {
            get { return students; }
            set { students = value; OnPropertyChanged("AllStudents"); }
        }

        public string Name { get; set; }
        public string SurName { get; set; }
        public string Date { get; set; }
        public string TotalAge { get; set; }
        public string Patronymic { get; set; }
        public string Snils { get; set; }
        public static Student SelectedStudent { get; set; }
        public static string Gender { get; set; }
        public static string SAttestat { get; set; }
        public static string Admission { get; set; }
        public static string Speciality { get; set; }
        public static string Invalid { get; set; }
        public static string Sirota { get; set; }
        public static string EducationMethod { get; set; }
        public static string Nationality { get; set; }
        public static string OtherNationality { get; set; }
        public static string PlaceOfRes { get; set; }
        public static string Education { get; set; }
        public static byte[] SirotaImg { get; set; }
        public static byte[] InvalidImg { get; set; }
        public static byte[] AttestatImg { get; set; }


        public static string newSnils { get; set; }
        public static string newInvalid { get; set; }
        public static string newSirota { get; set; }
        public static string newAdmission { get; set; }
        public static string newGender { get; set; }
        public static string newEdumethod { get; set; }
        public static string newSpecial { get; set; }
        public static string newNation { get; set; }
        public static byte[] newSirotaImg { get; set; }
        public static byte[] newInvalidImg { get; set; }
        public static byte[] newAttestatImg { get; set; }
        public static string newPlaceOfRes { get; set; }
        public static string newEducation{ get; set; }


        private RelayCommand addStudent;
        public RelayCommand AddStudent
        {
            get
            {
                return addStudent ?? new RelayCommand(obj =>
                {
                    DataStudent.CreateStudent(SurName, Name, Date, TotalAge, Patronymic, 
                        Gender, SAttestat, Admission, Invalid, Sirota,
                        Snils, Speciality, EducationMethod, Nationality, SirotaImg, InvalidImg, AttestatImg, PlaceOfRes, Education);
                    UpdateAllStudentsView();
                }
                );
            }
        }

        private RelayCommand deleteStudent;
        public RelayCommand DeleteStudent
        {
            get
            {
                return deleteStudent ?? new RelayCommand(obj =>
                {
                    DataStudent.DeleteStudent(SelectedStudent);
                    UpdateAllStudentsView();
                    SetNullValuesToProperties();
                }
                );
            }
        }

        private RelayCommand updateStudent;
        public RelayCommand UpdateStudent
        {
            get
            {
                return updateStudent ?? new RelayCommand(obj =>
                {
                    DataStudent.UpdateStudent(SelectedStudent, newGender, newInvalid, newSirota, newAdmission, newEdumethod, 
                        newSpecial, newNation, newSnils, newSirotaImg, newInvalidImg, newAttestatImg, newPlaceOfRes, newEducation);
                    UpdateAllStudentsView();
                }
                );
            }
        }

        public static void UpdateAllStudentsView()
        {
            MainWindow.AllStudentsView.ItemsSource = null;
            MainWindow.AllStudentsView.Items.Clear();
            MainWindow.AllStudentsView.ItemsSource = DataStudent.GetAllStudents();
            MainWindow.AllStudentsView.Items.Refresh();
        }
        private void SetNullValuesToProperties()
        {
            Name = null;
            SurName = null;
            Date = null;
            TotalAge = null;
            Admission = null;
            SAttestat = null;
            Gender = null;
            Patronymic = null;
        }

        private string nationality;

        

    }
}
