using InspectionBoard.Infrastructure;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InspectionBoard.Models.Data
{
    public class DataStudent
    {

        public static void CreateStudent(
            string firstName, string lastName, 
            string date_of_birth, string age, string patronymic, 
            string gender, string attestat, string admission,
            string invalid, string sirota, string snils, string special, string educationMethod, 
            string nation, byte[] sirotaimg, byte[] invalidimg, byte[] attestatimg, string place, string education)
        {
            DbConnect.InspectionBoardContext.Add(
                new Student 
                {   LastName = lastName, 
                    FirstName = firstName, 
                    DateOfBirth = date_of_birth, 
                    Age = age, 
                    Patronymic = patronymic, 
                    Gender = gender,
                    Attestat = attestat,
                    Admission = admission,
                    Invalid = invalid,
                    Sirota = sirota,
                    Snils = snils,
                    Speciality = special,
                    EducationalMethod = educationMethod,
                    Nationality = nation,
                    SirotaImg = sirotaimg,
                    InvalidImg = invalidimg,
                    AttestatImg = attestatimg,
                    PlaceOfResidence = place,
                    Education = education
                }) ;
            DbConnect.InspectionBoardContext.SaveChanges();
        }

        public static void DeleteStudent(Student student)
        {
            DbConnect.InspectionBoardContext.Remove(student);
            DbConnect.InspectionBoardContext.SaveChanges();
        }


        public static void UpdateStudent(
            Student student, string newGender, string newInvalid, string newSirota,
            string newAdmission, string eduMethod, string special, string nation, string snils, byte[] newSirotaImg, byte[] newInvalidImg, byte[] newAttestatImg, string newPlaceOfRes, string newEducation)
        {
            student.Gender = newGender;
            student.Invalid = newInvalid;
            student.Sirota = newSirota;
            student.Snils = snils;
            student.EducationalMethod = eduMethod;
            student.Speciality = special;
            student.Admission = newAdmission;
            student.Nationality = nation;
            student.SirotaImg = newSirotaImg;
            student.InvalidImg = newInvalidImg;
            student.AttestatImg = newAttestatImg;
            student.PlaceOfResidence = newPlaceOfRes;
            student.Education = newEducation;


            DbConnect.InspectionBoardContext.SaveChanges();
        }

        public static List<Student> GetAllStudents()
        {
            return DbConnect.InspectionBoardContext.Students.ToList();
        }

        public static string SetPlaceOfRes(string stranger)
        {
            return stranger;
        }

        public static string SetPlaceOfRes(string subject, string city, string region)
        {
            return subject + ", " + "г. " + city + ", " + region + " район";
        }

        public static string UpdatePlaceOfRes(Student student, string subject, string city, string region)
        {
            return subject + ", " + "г. " + city + ", " + region + " район";
        }
    }
}
