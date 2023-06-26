using InspectionBoard.Infrastructure;
using InspectionBoard.Models;
using InspectionBoard.ViewModels;
using InspectionBoard.Reports;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InspectionBoard.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DataGrid AllStudentsView;
       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AddStudentVM();
            AllStudentsView = ViewAllStudents;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.ShowDialog();
            Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EditStudentWindow editStudentWindow = new EditStudentWindow();
            editStudentWindow.ShowDialog();
            Show();
        }

        private void Button_Save_Excel(object sender, RoutedEventArgs e)
        {
            using (InspectionBoardContext context = new InspectionBoardContext())
            {
                DbSet<Student> Students = context.Students;

                SaveExcel saveExcel = new SaveExcel(Students);
            }
        }

      
    }
}
