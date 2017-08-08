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
using BLL.Interfaces;
using BLL.Interfaces.Entities;
using Newtonsoft.Json;
using RestSharp;
using WpfPL.ViewModels;

namespace WpfPL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RestClient _restClient;
        private string _baseUrl = @"http://localhost:37447/";

        public MainWindow()
        {
            InitializeComponent();
            _restClient = new RestClient(_baseUrl);
            this.LotsList.ItemsSource = GetLots();
        }

        private IEnumerable<LotViewModel> GetLots()
        {
            var request = new RestRequest(@"api/LotAPI/GetLots", Method.GET);
            IRestResponse response;
            IEnumerable<LotViewModel> lotsList = null;
            try
            {
                response = _restClient.Execute(request);
                lotsList = JsonConvert.DeserializeObject<IEnumerable<LotViewModel>>(response.Content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return lotsList;
        }
    }
}
