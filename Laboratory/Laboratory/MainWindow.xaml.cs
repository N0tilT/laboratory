using Laboratoty.Data.Services;
using Laboratoty.Data;
using Laboratoty.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            var context = new DataContext();
            vm = new UserViewModel(
                new UserService(context),
                new PositionService(context),
                new GenderService(context),
                new FamilyService(context));
            DataContext = vm;
        }
    }
}