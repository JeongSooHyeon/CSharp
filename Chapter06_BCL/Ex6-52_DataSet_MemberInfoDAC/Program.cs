using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Reflection;

public class MemberInfoDAC
{
    SqlConnection _sqlCon;
    DataTable _table;

    public MemberInfoDAC(SqlConnection sqlCon)
    {
        _sqlCon = sqlCon;

        // 개별 칼럼 정보 구성
        DataColumn nameCol = new DataColumn("Name", typeof(string));
        DataColumn birthCol = new DataColumn("Birth", typeof(DateTime));
        DataColumn emailCol = new DataColumn("Email", typeof(string));
        DataColumn familyCol = new DataColumn("Family", typeof(byte));

        // 칼럼 정보를 포함하는 DataTable 정의
        _table = new DataTable("MemberInfo");
        _table.Columns.Add(nameCol);
        _table.Columns.Add(birthCol);
        _table.Columns.Add(emailCol);
        _table.Columns.Add(familyCol);
    }
    public DataRow NewRow()
    {
        return _table.NewRow();
    }

    void FillParameters(SqlCommand cmd, DataRow item)
    {
        SqlParameter paramName = new SqlParameter("@Name", SqlDbType.NVarChar, 20);
        paramName.Value = item["Name"];

        SqlParameter paramBirth = new SqlParameter("@Birth", SqlDbType.Date);
        paramBirth.Value = item["Birth"];

        SqlParameter paramEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 100);
        paramEmail.Value = item["Email"];

        SqlParameter paramFamily = new SqlParameter("@Family", SqlDbType.TinyInt);
        paramFamily.Value = item["Family"];

        cmd.Parameters.Add(paramName);
        cmd.Parameters.Add(paramBirth);
        cmd.Parameters.Add(paramEmail);
        cmd.Parameters.Add(paramFamily);
    }

    public void Insert(DataRow item)
    {
        string txt = "INSERT INTO MemberInfo1(Name, Birth, Email, Family) VALUES (@Name, @Birth, @Email, @Family)";
        SqlCommand cmd = new SqlCommand(txt, _sqlCon);
        FillParameters(cmd, item);
        cmd.ExecuteNonQuery();
    }

    public void Update(DataRow item)
    {
        string txt = "UPDATE MemberInfo1 SET Name=@Name, Birth=@Birth, Family=@Family WHERE Email=@Email";
        SqlCommand cmd = new SqlCommand(txt, _sqlCon);
        FillParameters(cmd, item);
        cmd.ExecuteNonQuery();
    }

    public void Delete(DataRow item)
    {
        string txt = "DELETE FROM MemberInfo1 WHERE Email=@Email";
        SqlCommand cmd = new SqlCommand(txt, _sqlCon);
        FillParameters(cmd, item);
        cmd.ExecuteNonQuery();
    }

    public DataSet SelectAll()
    {
        DataSet ds = new DataSet();

        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM MemberInfo1", _sqlCon);
        sda.Fill(ds, "MemberInfo1");

        return ds;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();

            MemberInfoDAC dac = new MemberInfoDAC(sqlCon);

            DataRow newItem = dac.NewRow();
            newItem["Name"] = "Jennifer";
            newItem["Birth"] = new DateTime(1985, 5, 6);
            newItem["Email"] = "jennifer@jennifersoft.com";
            newItem["amily"] = 0;

            dac.Insert(newItem);   // 신규 데이터를 추가

            newItem["Name"] = "Jenny";
            dac.Update(newItem);   // 데이터 내용 업데이트

            DataSet ds = dac.SelectAll();    // 데이터 조회
            foreach (DataRow member in ds.Tables["MemberInfo"].Rows)
            {
                Console.WriteLine(member["Email"]);
            }

            dac.Delete(newItem);
        }
    }
}


/*// INSERT : 4개의 레코드 생성
_table.Rows.Add("Anderson", new DateTime(1950, 5, 20), "anderson@gmail.com", 2);
_table.Rows.Add("Jason", new DateTime(1967, 12, 3), "jason@gmail.com", 0);
_table.Rows.Add("Mark", new DateTime(1998, 3, 2), "mark@naver.com", 1);
_table.Rows.Add("Jennifer", new DateTime(1985, 5, 6), "jennifer@jennifersoft.com", 0);

// SELECT : 가족 구성원이 1명 이상인 레코드 선택
DataRow[] members = _table.Select("Family >= 1");
foreach(DataRow row in members)
{
    Console.WriteLine("{0}, {1}, {2}, {3}", row["Name"], row["Birth"], row["Email"], row["Family"]);
}

// UPDATE : 4번째 레코드의 Name 칼럼의 값을 "Jennifer"에서 "Jenny"로 변경
_table.Rows[3]["Name"] = "Jenny";

// DELETE : 4번째 레코드 삭제
_table.Rows.Remove(_table.Rows[3]);


DataSet ds = new DataSet();
ds.Tables.Add(_table);*/