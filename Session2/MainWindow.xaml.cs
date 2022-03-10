using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Session2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        string strConn = Classes.connection.strConn;
        private void createStackPanels()
        {
            FlipView flipView = new FlipView()
            {

            };
            Grid grid = new Grid()
            {

            };
            flipView.Items.Add(grid);
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sqlExpression = "SELECT [Логотип Агента] FROM agents_b_import$";
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                SqlDataReader sqlDataReader = command.ExecuteReader();
                for (int i = 0; sqlDataReader.Read(); i++)
                {
                    ImageSource imgSrc = sqlDataReader.GetValue(i).GetType;
                    Image img = new Image()
                    {
                        Source = @"D:\YandexDisk\VKI\DB_C#\09_1.5_8\КОД 1.5._ВАРИАНТ_8\Сессия 1\agents_import\agents"
                    };
                }
            }

        }
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
        }
    }
}
