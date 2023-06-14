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
            string gender, string attestat, string admission)
        {
            DbConnect.InspectionBoardContext.Add(
                new Student 
                {   LastName = lastName, 
                    FirstName = firstName, 
                    DateOfBirth = date_of_birth, 
                    Age = age, Patronymic = patronymic, 
                    Gender = gender,
                    Attestat = attestat,
                    Admission = admission
                }) ;
            DbConnect.InspectionBoardContext.SaveChanges();
        }

        public static void DeleteStudent(Student student)
        {
            DbConnect.InspectionBoardContext.Remove(student);
            DbConnect.InspectionBoardContext.SaveChanges();
        }


        public static void UpdateStudent(Student student, string newGender)
        {
            student.Gender = newGender;
            DbConnect.InspectionBoardContext.SaveChanges();
        }

        public static List<Student> GetAllStudents()
        {
            return DbConnect.InspectionBoardContext.Students.ToList();
        }

    }
}
