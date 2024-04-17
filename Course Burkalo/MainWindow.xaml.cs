using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace LibraryAutomation
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged("Books");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

           
            Books = new ObservableCollection<Book>();

            
            txtTitle.PreviewMouseLeftButtonDown += TxtTitle_PreviewMouseLeftButtonDown;
            txtAuthor.PreviewMouseLeftButtonDown += TxtAuthor_PreviewMouseLeftButtonDown;
            txtStudentName.PreviewMouseLeftButtonDown += TxtStudentName_PreviewMouseLeftButtonDown;
        }

        private void TxtTitle_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            if (txtTitle.Text == "Добавьте название книги")
            {
                txtTitle.Text = "";
            }
        }

        private void TxtAuthor_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
            if (txtAuthor.Text == "Добавьте автора")
            {
                txtAuthor.Text = "";
            }
        }

        private void TxtStudentName_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
            if (txtStudentName.Text == "Добавьте ФИО ученика")
            {
                txtStudentName.Text = "";
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            
            Book newBook = new Book { Title = txtTitle.Text, Author = txtAuthor.Text, StudentName = txtStudentName.Text };
            Books.Add(newBook);

           
           
                txtTitle.Text = "Добавьте название книги";
            

           
           
                txtAuthor.Text = "Добавьте автора";
            

            
            txtStudentName.Text = "Добавьте ФИО ученика";
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void lvBooks_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string StudentName { get; set; }
    }
}
