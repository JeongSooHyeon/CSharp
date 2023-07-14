using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Transactions;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        using(TransactionScope tx = new TransactionScope())
        {
            sqlCon.Open();
            //using (SqlTransaction transaction = sqlCon.BeginTransaction())
            //{
                // SqlCommand를 이용해 쿼리 수행
                string txt = "INSERT INTO MemberInfo1(Name, Birth, Email, Family) VALUES('{0}', '{1}', '{2}', '{3}')";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                //cmd.Transaction = transaction;
                cmd.CommandText = string.Format(txt, "Fox", "1970-01-25", "fox@gmail.com", "5");
                cmd.ExecuteNonQuery();

                cmd.CommandText = string.Format(txt, "Dana", "1972-01-25", "fox@gmail.com", "1");
                cmd.ExecuteNonQuery();  // PK 중복으로 예외 발생

                //transaction.Commit();
                tx.Complete();
            //}
        }
    }
}

