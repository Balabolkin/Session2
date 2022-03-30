using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
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
using Windows.UI;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Session2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainWindow : Window
    {
        
        string strConn = Classes.connection.strConn;
        List<Table> tables = new List<Table>();
        //private void createStackPanels()
        //{

        //    //using (SqlConnection conn = new SqlConnection(strConn))
        //    //{
        //    //    conn.Open();
        //    //    string sqlExpression = "SELECT [Логотип Агента] FROM agents_b_import$";
        //    //    SqlCommand command = new SqlCommand(sqlExpression, conn);
        //    //    SqlDataReader sqlDataReader = command.ExecuteReader();
        //    //    sqlDataReader.Read();
        //    //    for (int i = 0; sqlDataReader.Read(); i++)
        //    //    {
        //    //        Image image = new Image();
        //    //        BitmapImage bitmap = new BitmapImage();
        //    //        try
        //    //        {
        //    //            bitmap.UriSource = new Uri(@"D:\YandexDisk\VKI\DB_C#\09_1.5_8\КОД 1.5._ВАРИАНТ_8\Сессия 1\agents_import\agents"+sqlDataReader.GetString(i));
        //    //        }
        //    //        catch { }
        //    //        image.Source = bitmap;
        //    //        grid.Children.Add(image);
        //    //    }
        //    //}

        //}


        private void getData()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sqlExpression = "SELECT * FROM materials_s_import$ LEFT JOIN [Лист1$] ON materials_s_import$.[Наименование материала]=[Лист1$].[Наименование материала] INNER JOIN supplier_s_import$ ON supplier_s_import$.[Наименование поставщика]=[Лист1$].[Возможный поставщик];";
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                DataTable dt = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                {
                    sqlDataAdapter.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Image img = new Image();
                        DataRow row = dt.Rows[i];
                        BitmapImage bitmapImage = new BitmapImage();
                        if (!string.IsNullOrEmpty(row[2].ToString()))
                            bitmapImage.UriSource = new Uri(@"D:\YandexDisk\КОД 1.5._ВАРИАНТ_4\Сессия 1\materials_s_import"+row[2], UriKind.Relative);
                        else
                            bitmapImage.UriSource = new Uri(@"D:\YandexDisk\КОД 1.5._ВАРИАНТ_4\Сессия 2\picture.png", UriKind.Relative);
                        img.Source = bitmapImage;
                        tables.Add(new Table(row[0].ToString(), row[1].ToString(), img.Source, row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[9].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString()));
                        DataListView.Items.Add(tables[i]);
                    }
                    
                    
                }
            }
        }

        public MainWindow()
        {
            this.InitializeComponent();
            getData();
        }

        //private void sortButton_Click(object sender, RoutedEventArgs e)
        //{
        //    List<Table> sortTables = tables.OrderBy(o => o.TinStock).ToList();
        //    DataListView.Items.Clear();
        //    for (int i = 0; i < sortTables.Count; i++)
        //    {
        //        Image img = new Image();
        //        BitmapImage bitmapImage = new BitmapImage();
        //        if (!string.IsNullOrEmpty(sortTables[i].Timg.ToString()))
        //            bitmapImage.UriSource = new Uri(@"D:\YandexDisk\КОД 1.5._ВАРИАНТ_4\Сессия 1\materials_s_import"+sortTables[i].Timg.ToString(), UriKind.Relative);
        //        else
        //            bitmapImage.UriSource = new Uri(@"D:\YandexDisk\КОД 1.5._ВАРИАНТ_4\Сессия 2\picture.png", UriKind.Relative);
        //        img.Source = bitmapImage;
        //        DataListView.Items.Add(sortTables[i]);
        //    }
        //}
    }
    public class Table
    {
        public string TnameM { get; set; }
        public string TtypeM { get; set; }
        public ImageSource Timg { get; set; }
        public string Tprice { get; set; }
        public string TinStock { get; set; }
        public string TminNum { get; set; }
        public string TnumPack { get; set; }
        public string Tunit { get; set; }
        public string TnameS { get; set; }
        public string TtypeS { get; set; }
        public string Tinn { get; set; }
        public string TqualRate { get; set; }
        public string TdateS { get; set; }
        public Table(string nameM, string typeM, ImageSource img, string price, string inStock, string minNum, string numPack, string unit, string nameS, string typeS, string inn, string qualRate, string dateS)
        {
            TnameM=nameM;
            TtypeM=typeM;
            Timg=img;
            Tprice=price;
            TinStock=inStock;
            TminNum=minNum;
            TnumPack=numPack;
            Tunit=unit;
            TnameS=nameS;
            TtypeS=typeS;
            Tinn=inn;
            TqualRate=qualRate;
            TdateS=dateS;
        }
    }
}
