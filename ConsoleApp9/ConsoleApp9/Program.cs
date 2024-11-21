using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        protected SqlConnection GetConnection() // DB 연결문
        {
            string dataSource = "PC";  // 사용자 PC명, IP주소
            string dataBase = "myCom"; // DB명
            SqlConnection conn = new SqlConnection(); // SqlConnection 객체 생성

            conn.ConnectionString = $"data source = {dataSource};" +
                                    $"database = {dataBase};" +
                                    $"integrated security = true";
            return conn;
        }
        public DataSet GetData(string query) // DB 데이터 가져오기
        {
            SqlConnection conn = GetConnection();     // conn-연결 객체 생성
            SqlCommand cmd = new SqlCommand();        // cmd-명령 객체 생성
            cmd.Connection = conn;                    // conn명령
            cmd.CommandText = query;                  // cmd.CommandText 지정
            SqlDataAdapter da = new SqlDataAdapter(); // SqlDataAdapter 생성(conn.open)
            DataSet ds = new DataSet();               // DataSet 생성
            da.Fill(ds);
            return ds;
        }
        public void SetData(string query) // DB 데이터 최신화
        {
            SqlConnection con = GetConnection(); // conn-연결 객체 생성
            SqlCommand cmd = new SqlCommand();   // cmd-명령 객체 생성
            cmd.Connection = con;                // conn명령
            cmd.CommandText = query;             // cmd.CommandText 지정
            con.Open();                          // DB 열기
            cmd.ExecuteNonQuery();               // 결과를 반환하지 않는 쿼리문(insert, update, delete)
            con.Close();                         // DB 닫기
        }
    }
}
