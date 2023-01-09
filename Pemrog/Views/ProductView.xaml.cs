using System.Windows;
using System.Windows.Controls;
using Pemrog.ViewModels;


namespace Pemrog.Views
{
    public partial class ProductView : Window
    {
        public ProductView()
        {
            InitializeComponent();
            vm = new ProductViewModel();
            vm.OnCallBack += Close;
            DataContext = vm;

        }

        private readonly ProductViewModel vm;

        private void TblData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            
           
        
            TxtUid.IsEnabled = true;
            TxtName.IsEnabled = true;
            IsChecked.IsEnabled = true;
            
            TxtName.Focus();
        }

        private void TblData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            TxtUid.IsEnabled = true;
            TxtName.IsEnabled = true;
          
            vm.Model = new Models.Product();
            vm.IsChecked = true;
            TxtName.Focus();
            
        }
    }
    }

