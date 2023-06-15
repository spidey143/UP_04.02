using InspectionBoard.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;


namespace InspectionBoard.Reports
{
    internal class SaveExcel
    {
        public SaveExcel(DbSet<Student> students)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Студенты");

                    worksheet.Cells[1, 1].Value = "№";
                    worksheet.Cells[1, 2].Value = "Фамилия";
                    worksheet.Cells[1, 3].Value = "Имя";
                    worksheet.Cells[1, 4].Value = "Отчество";
                    worksheet.Cells[1, 5].Value = "Возраст";
                    worksheet.Cells[1, 6].Value = "Пол";
                    worksheet.Cells[1, 7].Value = "Ср. балл";
                    worksheet.Cells[1, 8].Value = "Зачислен";

                    int count = 2;
                    foreach (Student student in students)
                    {
                        worksheet.Cells[count, 1].Value = student.IdStudent;
                        worksheet.Cells[count, 2].Value = student.LastName;
                        worksheet.Cells[count, 3].Value = student.FirstName;
                        worksheet.Cells[count, 4].Value = student.Patronymic;
                        worksheet.Cells[count, 5].Value = student.Age;
                        worksheet.Cells[count, 6].Value = student.Gender;
                        worksheet.Cells[count, 7].Value = student.Attestat;
                        worksheet.Cells[count, 8].Value = student.Admission;

                        count += 1;
                    }

                    FileInfo fi = new FileInfo("../../../Reports\\Report.xlsx");
                    excelPackage.SaveAs(fi);

                    MessageBox.Show("Файл успешно сохранён", "Успех", MessageBoxButton.OK);
                }

            }
            catch
            {
                MessageBox.Show("Не удалось сохранить файл", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}