using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        DataSet ds = new DataSet();

        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM MemberInfo1", sqlCon);
            sda.Fill(ds, "MemberInfo1");
        }
        ds.WriteXml(Console.Out);   // DataSet이 가진 내용을 콘솔 화면에 출력
    }
}