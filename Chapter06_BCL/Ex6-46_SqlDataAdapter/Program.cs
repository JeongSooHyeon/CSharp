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
            sda.Fill(ds, "MemberInfo1");    // DataSet에 SELECT 결과를 담는다.
        }

        // DataSet에 포함된 테이블 중에서 "MemberInfo"를 찾고
        DataTable dt = ds.Tables["MemberInfo1"];

        // SELECT로 반환된 데이터 레코드 열람
        foreach(DataRow row in dt.Rows)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", row["Name"], row["Birth"], row["Email"], row["Family"]);
        }
        // ds.WriteXml(Console.Out);   // DataSet이 가진 내용을 콘솔 화면에 출력
    }
}