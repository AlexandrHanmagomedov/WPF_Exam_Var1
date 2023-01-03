using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_EXAM {

    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { set; get; }

        public MainWindow()
        {
            InitializeComponent();

            Students = new ObservableCollection<Student> ( )
            {
                new Student { ImagePublic = @"Res\123.jpg" , Name = "Вася", SurName = "Ин", Patronymic = "Азгенович", GroupNumber = 165, PhoneNumber = 111111, EntryDate = new DateTime(2021, 01, 3),ReleaseDate=new DateTime(2020, 06, 4).AddYears(5), },
                new Student { ImagePublic = @"Res\2.jpg", Name = "Ася", SurName = "Кин", Patronymic = "Вазгенович", GroupNumber = 135, PhoneNumber = 22222, EntryDate = new DateTime(2020, 06, 4),ReleaseDate=new DateTime(2020, 06, 4).AddYears(5), },
                new Student { ImagePublic = @"Res\3.jpg", Name = "Ся", SurName = "Пкин", Patronymic = "Генович", GroupNumber = 145, PhoneNumber = 3333333, EntryDate = new DateTime(2019, 09, 7),ReleaseDate=new DateTime(2019, 09, 7).AddYears(5), },
                new Student
                {
                    ImagePublic = @"Res\4.jpg",
                    Name = "Я",
                    SurName = "Упкин",
                    Patronymic = "Вич",
                    GroupNumber = 99,
                    PhoneNumber = 44444,
                    EntryDate = new DateTime(2018, 09, 9),
                    ReleaseDate=new DateTime(2018, 09, 9).AddYears(5),
                },
            };

            //this.DataContext = Students;
            list.ItemsSource = Students;
            DataContext = this;
        }
        public string SearchText { get; set; } = "";

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ChangeAdd.Visibility = Visibility.Visible;
            list.SelectedIndex = -1;
            LabelContent.Content = btn.Content;
            Clear();
            ok.IsEnabled = true;
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            Clear();

            MessageBoxResult result;
            result = MessageBox.Show ( "Вы уверены что хотите удалить ?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes );

            ChangeAdd.Visibility = Visibility.Hidden;

            if (list.SelectedIndex != -1 && result==MessageBoxResult.Yes)
            {                
                Students.RemoveAt(list.SelectedIndex);
            }
            if (list.Items.Count == 0)
            {
                header.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (list.SelectedItem != null)
            {
                if (!isEmptyFild(TextBoxName, TextBoxSurname, TextBoxPatronymic, TextBoxGroup, TextBoxPhone, DatePickerEntryDate))
                {
                    return;
                }
                Student per = list.SelectedValue as Student;
                per.Name = TextBoxName.Text;
                per.SurName = TextBoxSurname.Text;
                per.Patronymic = TextBoxPatronymic.Text;
                per.GroupNumber = Convert.ToInt32(TextBoxGroup.Text);
                per.PhoneNumber = Convert.ToInt32(TextBoxPhone.Text);
                per.EntryDate = DateTime.Now;
            }
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            if (!isEmptyFild(TextBoxName, TextBoxSurname, TextBoxPatronymic, TextBoxGroup, TextBoxPhone, DatePickerEntryDate))
            {
                return;
            }
            Students.Add(new Student
            {
                Name = TextBoxName.Text,
                SurName = TextBoxSurname.Text,
                Patronymic = TextBoxPatronymic.Text,
                GroupNumber = Convert.ToInt32(TextBoxGroup.Text),
                PhoneNumber = Convert.ToInt32(TextBoxPhone.Text),
                EntryDate = (DateTime)DatePickerEntryDate.SelectedDate
            });
            if (list.Items.Count != 0)
            {
                header.Visibility = Visibility.Visible;
            }
            Clear();
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            TextBoxName.Text = "";
            TextBoxSurname.Text = "";
            TextBoxPatronymic.Text = "";
            TextBoxGroup.Text = "";
            TextBoxPhone.Text = "";
            DatePickerEntryDate.SelectedDate = DateTime.Now;
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Clear();
            ChangeAdd.Visibility = Visibility.Hidden;
            list.SelectedIndex = -1;
        }

        private bool isEmptyFild(TextBox name, TextBox surname, TextBox patronimic, TextBox group, TextBox phone, DatePicker entrydate)
        {
            try
            {
                if (name.Text == String.Empty)
                {
                    MessageBox.Show("Поле Имя не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (surname.Text == String.Empty)
                {
                    MessageBox.Show("Поле Фамилия не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (patronimic.Text == String.Empty)
                {
                    MessageBox.Show("Поле Отчество не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (group.Text == String.Empty)
                {
                    MessageBox.Show("Поле Группа не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                int number;
                bool result = Int32.TryParse(group.Text, out number);
                if (!result)
                {
                    MessageBox.Show("Поле группа заполненно не корректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (phone.Text == String.Empty)
                {
                    MessageBox.Show("Поле Телефон не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (entrydate.Text == String.Empty)
                {
                    MessageBox.Show("Поле Дата приема не заполненно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Мы все умрееееееееееем!!!!!", "Паника", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return true;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student per = list.SelectedItem as Student;
            if (per != null)
            {
                ChangeAdd.Visibility = Visibility.Visible;
                TextBoxName.Text = per.Name;
                TextBoxSurname.Text = per.SurName;
                TextBoxPatronymic.Text = per.Patronymic;
                TextBoxGroup.Text = per.GroupNumber.ToString();
                TextBoxPhone.Text = per.PhoneNumber.ToString();
                DatePickerEntryDate.SelectedDate = per.EntryDate;
                
            }
            ok.IsEnabled = false;
            LabelContent.Content = "Данные";
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
             list.ItemsSource = Students.Where(x=>x.Name.Contains(SearchText)|| 
                                               x.SurName.Contains(SearchText) || 
                                               x.Patronymic.Contains(SearchText) || 
                                               x.GroupNumber.ToString().Contains(SearchText)|| 
                                               x.PhoneNumber.ToString().Contains(SearchText) ||
                                               x.EntryDate.ToString().Contains(SearchText)
             ).ToList();
        }

        private void list_Click(object sender, RoutedEventArgs e)
        {
            list.Items.SortDescriptions.Add(new SortDescription("GroupNumber", ListSortDirection.Ascending));
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {
                ButtonDel_Click(sender, e);
            }
        }
    }
}
