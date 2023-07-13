using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.Json.Serialization.Metadata;

class Program
{
    static void Main(string[] args)
    {
        //SqlConnection sqlCon = new SqlConnection();

        //sqlCon.ConnectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=TestDB;User ID=sa;Password=0000";

        // App.config에서 가져옴
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        //sqlCon.ConnectionString = connectionString;

        using(SqlConnection sqlCon = new SqlConnection())
        {
            sqlCon.ConnectionString = connectionString;
            // DB에 연결하고
            sqlCon.Open();

            // DB에 연결된 동안 DB 쿼리 실행
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            //cmd.CommandText = "INSERT INTO MemberInfo1(Name, Birth, Email, Family) VALUES('Fox', '1970-01-25', 'fox@gamil.com', 5)";
            //cmd.CommandText = "DELETE FROM MemberInfo1 WHERE Email = 'fox@gamil.com'";
            //cmd.CommandText = "UPDATE MemberInfo1 SET Family=3 WHERE Email = 'fox@gamil.com'";
            //int affectedCount = cmd.ExecuteNonQuery();
            //Console.WriteLine(affectedCount);

            // ExecuteScalar
            cmd.CommandText = "SELECT COUNT(*) FROM MemberInfo1 WHERE Family >= 2";
            object objValue = cmd.ExecuteScalar();
            int countOfMember = (int)objValue;
            Console.WriteLine(countOfMember);

            // ExecuteReader
            cmd.CommandText = "SELECT * FROM MemberInfo1";
            SqlDataReader reader = cmd.ExecuteReader();
            
            // 읽어야 할 데이터가 남아 있다면 true, 없다면 false를 반환
            while(reader.Read())
            {
                string name = reader.GetString(0);
                DateTime birth = reader.GetDateTime(1);
                string email = reader.GetString(2);
                byte family = reader.GetByte(3);

                Console.WriteLine("{0}, {1}, {2}, {3}", name, birth, email, family);
            }
            reader.Close();
        
        }
        
        // 연결 닫기
        // sqlCon.Close();
    }

}