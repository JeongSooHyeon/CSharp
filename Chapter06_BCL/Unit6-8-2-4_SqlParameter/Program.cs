﻿using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.Json.Serialization.Metadata;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        // 아래의 변수 4개는 사용자로부터 값을 입력받은 것으로 가정
        string name = "Cooper";
        DateTime birth = new DateTime(1990, 2, 7);
        string email = "cooper@hotmail.com";
        int family = 5;

        using (SqlConnection sqlCon = new SqlConnection())
        {
            sqlCon.ConnectionString = connectionString;
            sqlCon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;

            string text = string.Format("INSERT INTO MemberInfo1(Name, Birth, Email, Family) VALUES('{0}', '{1}', '{2}', {3})", name, birth.ToShortDateString(), email, family);
            cmd.CommandText = text;
            cmd.ExecuteNonQuery();
        }
    }
}