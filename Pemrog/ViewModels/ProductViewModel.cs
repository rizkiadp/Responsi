using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using Pemrog.Setup;
using Pemrog.Models;

namespace Pemrog.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public ProductViewModel()
        {
            collection = new ObservableCollection<Product>();
            dbconn = new Db_Connection();
            model = new Product();

            UpdateCommand = new RelayCommand(async () => await UpdateDataAsync());
            SelectCommand = new RelayCommand(async () => await ReadDataAsync());
            SelectCommand.Execute(null);
        }
        
        public RelayCommand SelectCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public ObservableCollection<Product> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public Product Model
        {
            get
            {
                return model;
            }
            set
            {
                if (value != null)
                {
                    IsChecked = (value.Status == "Active") ? true : false;
                }
                model = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public bool IsChecked
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public event Action OnCallBack;

        private readonly Db_Connection dbconn;
        private ObservableCollection<Product> collection;
        private Product model;
        private bool check;

        private async Task ReadDataAsync()
        {
            dbconn.OpenConnection();

            await Task.Delay(0);
            var query = "SELECT * FROM products";
            var sqlcmd = new SqlCommand(query, dbconn.SqlConnection);
            var sqlresult = sqlcmd.ExecuteReader();

            if (sqlresult.HasRows)
            {
                collection.Clear();
                while (sqlresult.Read())
                {
                    collection.Add(new Product
                    {
                        Uid = sqlresult[0] as int? ?? 0,
                        Name = sqlresult[1].ToString(),
                        Status = (sqlresult[2].ToString() == "1") ?
                        "Active" : "Not Active",
                    });
                }

            }
            dbconn.CloseConnection();
            OnCallBack?.Invoke();
        }
        private async Task UpdateDataAsync()
        {
            if (isValidating())
            {
                dbconn.OpenConnection();
                var state = check ? "1" : "0";
                var query = $"UPDATE products SET" +
                            $"Name = '{model.Name}'," +
                            $"Status = '{model.Status}'," +
                            $"WHERE uid = '{model.Uid}'";
                var sqlcmd = new SqlCommand(query, dbconn.SqlConnection);
                sqlcmd.ExecuteNonQuery();
                dbconn.CloseConnection();
                await ReadDataAsync();
            }
        }
        private bool isValidating()
        {
            var flag = true;
            if (model.Name == null)
            {
                MessageBox.Show("Text 1 Cannot Empty", "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                flag = false;
            }
            else if (model.Status == null)
            {
                MessageBox.Show("Text 2 Cannot Empty", "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
        
            return flag;
        }
    }  
}