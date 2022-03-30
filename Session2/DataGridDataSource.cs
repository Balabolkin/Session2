using CommunityToolkit.WinUI.UI.Controls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Session2
{
    internal class DataGridDataSource
    {
        string strConn = Classes.connection.strConn;
        private DataSet getData()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sqlExpression = "SELECT * FROM materials_s_import$ LEFT JOIN [Лист1$] ON materials_s_import$.[Наименование материала]=[Лист1$].[Наименование материала] INNER JOIN supplier_s_import$ ON supplier_s_import$.[Наименование поставщика]=[Лист1$].[Возможный поставщик];";
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                DataSet ds = new DataSet();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                {
                    sqlDataAdapter.Fill(ds);
                }
                return ds;
            }
        }
    }
}