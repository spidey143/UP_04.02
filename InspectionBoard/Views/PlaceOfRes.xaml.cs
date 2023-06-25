using InspectionBoard.Models.Data;
using InspectionBoard.ViewModels;
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
    /// Логика взаимодействия для PlaceOfRes.xaml
    /// </summary>
    public partial class PlaceOfRes : Window
    {
        public PlaceOfRes()
        {
            InitializeComponent();
            string[] regions = {"Республика Адыгея",
                    "Республика Алтай",
                    "Республика Башкортостан",
                    "Республика Бурятия",
                    "Республика Дагестан",
                    "Республика Ингушетия",
                    "Кабардино-Балкарская Республика",
                    "Республика Калмыкия",
                    "Карачаево-Черкесская Республика",
                    "Республика Карелия",
                    "Республика Коми",
                    "Республика Крым",
                    "Республика Марий Эл",
                    "Республика Мордовия",
                    "Республика Саха (Якутия)",
                    "Республика Северная Осетия — Алания",
                    "Республика Татарстан",
                    "Республика Тыва",
                    "Удмуртская Республика",
                    "Республика Хакасия",
                    "Чеченская Республика",
                    "Чувашская Республика",
                    "Алтайский край",
                    "Краснодарский край",
                    "Красноярский край",
                    "Приморский край",
                    "Ставропольский край",
                    "Хабаровский край",
                    "Амурская область",
                    "Архангельская область",
                    "Астраханская область",
                    "Белгородская область",
                    "Брянская область",
                    "Владимирская область",
                    "Волгоградская область",
                    "Вологодская область",
                    "Воронежская область",
                    "Ивановская область",
                    "Иркутская область",
                    "Калининградская область",
                    "Калужская область",
                    "Камчатский край",
                    "Кемеровская область",
                    "Кировская область",
                    "Костромская область",
                    "Курганская область",
                    "Курская область",
                    "Ленинградская область",
                    "Липецкая область",
                    "Магаданская область",
                    "Московская область",
                    "Мурманская область",
                    "Нижегородская область",
                    "Новгородская область",
                    "Новосибирская область",
                    "Омская область",
                    "Оренбургская область",
                    "Орловская область",
                    "Пензенская область",
                    "Пермский край",
                    "Псковская область",
                    "Ростовская область",
                    "Рязанская область",
                    "Самарская область",
                    "Саратовская область",
                    "Сахалинская область",
                    "Свердловская область",
                    "Смоленская область",
                    "Тамбовская область", };

            string[] municipalDistricts = {
                    "Буйский",
                    "Волгореченский",
                    "Галичский",
                    "Георгиевский",
                    "Кадыйский",
                    "Кологривский",
                    "Костромской",
                    "Макарьевский",
                    "Мантуровский",
                    "Нерехтский",
                    "Неяский",
                    "Островский",
                    "Павинский",
                    "Парфентьевский",
                    "Поназыревский",
                    "Солигаличский",
                    "Чухломский",
            };

            string[] cities = new string[]
            {
                "Кострома",
                "Буй",
                "Галич",
                "Макарьев",
                "Шарья",
                "Солигалич",
                "Нея",
                "Чухлома",
                "Вохма",
                "Павино",
                "Волгореченск",
                "Нерехта",
                "Мантурово"
            };

            CityComboBox.ItemsSource = (cities);
            RaionComboBox.ItemsSource = (municipalDistricts);
            Subject.ItemsSource = (regions);
            DataContext = new AddStudentVM();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Stranger.IsChecked == true)
            {
                Subject.IsEnabled = false;
                AddStudentVM.PlaceOfRes = "Иностранный гражданин";
                AddStudentVM.newPlaceOfRes = "Иностранный гражданин";

            }
            if (Stranger.IsChecked == true && Subject.SelectedItem != null)
            {
                Subject.IsEnabled = false;
                Subject.SelectedItem = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Subject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Subject.SelectedItem != null)
            {
                if (Convert.ToString(Subject.SelectedItem.ToString()) == "Костромская область")
                {
                    City.Visibility = Visibility.Visible;
                    Raion.Visibility = Visibility.Visible;

                    CityComboBox.Visibility = Visibility.Visible;
                    RaionComboBox.Visibility = Visibility.Visible;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Subject.SelectedItem != null && CityComboBox.SelectedItem == null & RaionComboBox.SelectedItem == null)
            {
                AddStudentVM.PlaceOfRes = DataStudent.SetPlaceOfRes(
                Convert.ToString(Subject.SelectedItem.ToString()));

                AddStudentVM.newPlaceOfRes = DataStudent.SetPlaceOfRes(
                Convert.ToString(Subject.SelectedItem.ToString()));
            }

            else if (Subject.SelectedItem != null || CityComboBox.SelectedItem != null || RaionComboBox.SelectedItem != null)
            {
                AddStudentVM.PlaceOfRes = DataStudent.SetPlaceOfRes(
                Convert.ToString(Subject.SelectedItem.ToString()),
                Convert.ToString(CityComboBox.SelectedItem.ToString()),
                Convert.ToString(RaionComboBox.SelectedItem.ToString()));

                AddStudentVM.newPlaceOfRes = DataStudent.SetPlaceOfRes(
                Convert.ToString(Subject.SelectedItem.ToString()),
                Convert.ToString(CityComboBox.SelectedItem.ToString()),
                Convert.ToString(RaionComboBox.SelectedItem.ToString()));
            }

            else if (Subject.SelectedItem == null)
            {
                AddStudentVM.PlaceOfRes = "Иностранный гражданин";
                AddStudentVM.newPlaceOfRes = "Иностранный гражданин";

            }

            Hide();
        }
    }


}
