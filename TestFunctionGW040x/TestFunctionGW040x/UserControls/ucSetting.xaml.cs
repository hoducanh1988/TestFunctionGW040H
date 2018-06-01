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
using TestFunctionGW040x.Funtions;

namespace TestFunctionGW040x.UserControls {
    /// <summary>
    /// Interaction logic for ucSetting.xaml
    /// </summary>
    public partial class ucSetting : UserControl {


        private void InitializeItemSource()
        {
            cbbBarcodeType.ItemsSource = initParameters.listBarcodeType;
            cbbBRPort.ItemsSource = initParameters.listUARTPort;
            cbbBRBaudRate.ItemsSource = initParameters.listBaudRate;
        }


        public ucSetting() {
            InitializeComponent();
            InitializeItemSource();
            this.DataContext = GlobalData.initSetting;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            GlobalData.initSetting.Save();
            GlobalData.testingInfo.initialization();
            MessageBox.Show("Thành công!", "Lưu cài đặt", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
