using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMapper.Modle;
using MySql.Data.MySqlClient;


namespace DataMapper.Data_Mapper
{
    public class StudentDataMapper : IDataMapper<Student>
    {
        String connString;
        MySqlConnection conn;
        public StudentDataMapper()
        {
            connString = "server=localhost;port=3306;database=datamapper;uid=root;password=k190294";
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
        }
        public bool Save(Student Entity)
        {
            var name = Entity.Name;
            var id = Entity.Id;
            var dob = Entity.DateOfBirth;
            var address=Entity.Address;
            var grade=Entity.Grade;
            
            conn.Open();
            string sql = "insert into datamapper.student (idStudent,Name,DOB,Address,Grade) values(@id,@name,@DOB,@Address,@Grade);";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@DOB", dob);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Grade", grade);
            int rowsAffected = command.ExecuteNonQuery();
            conn.Close();
                // Check the number of affected rows
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public bool Delete(int id)
        {
            int id1 = id;
            conn.Open();
            string sql_check = "select * from datamapper.student where idStudent=@id;";
            MySqlCommand command = new MySqlCommand(sql_check, conn);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            var hasrows = reader.HasRows;
            conn.Close();

            if (hasrows)
            {
                conn.Open();
                string sql_del = "delete from datamapper.student where idStudent=@id1;";
                MySqlCommand command1 = new MySqlCommand(sql_del, conn);
                command1.Parameters.AddWithValue("@id1", id1);
                int rowsAffected = command1.ExecuteNonQuery();
                conn.Close();
                if (rowsAffected > 0)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (false);
            }
        }

        public List<Student> GetAll()
        {
            conn.Open();
            string sql_get = "Select * from datamapper.Student;";
            MySqlCommand command = new MySqlCommand(sql_get, conn);
            MySqlDataReader reader = command.ExecuteReader();
            List<Student> list = new List<Student>();
            while (reader.Read())
            {
                Student s1 = new Student();
                s1.Id = (int)reader["idStudent"];
                s1.Name = (string)reader["Name"];
                s1.DateOfBirth = (DateTime)reader["DOB"];
                s1.Address = (string)reader["Address"];
                s1.Grade = (String)reader["Grade"];
                list.Add(s1);
            }
            return list;
        }

        public Student GetById(int id)
        {
            conn.Open();
            string sql_check = "select * from datamapper.Student where idStudent=@id;";
            MySqlCommand command = new MySqlCommand(sql_check, conn);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Student s1 = new Student();
                s1.Id = (int)reader["idStudent"];
                s1.Name = (string)reader["Name"];
                s1.DateOfBirth = (DateTime)reader["DOB"];
                s1.Address = (string)reader["Address"];
                s1.Grade = (String)reader["Grade"];
                conn.Close();
                return s1;
            }
            else
            {
                return null;
            }
        }

        public bool Update(int id, Student Entity)
        {
            conn.Open();
            string sql_get = "Select * from datamapper.Student where idStudent=@id;";
            MySqlCommand command = new MySqlCommand(sql_get, conn);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            var hasrows = reader.HasRows;
            conn.Close();
            if (hasrows)
            {
                conn.Open();
                string sql_upd = "update datamapper.Student set Name=@name,DOB=@dob,Address=@address,Grade=@grade where idStudent=@id";
                MySqlCommand command1 = new MySqlCommand(sql_upd, conn);
                command1.Parameters.AddWithValue("@id", id);
                command1.Parameters.AddWithValue("@name", Entity.Name);
                command1.Parameters.AddWithValue("@dob", Entity.DateOfBirth);
                command1.Parameters.AddWithValue("@address", Entity.Address);
                command1.Parameters.AddWithValue("@grade", Entity.Grade);
                int rowsAffected = command1.ExecuteNonQuery();
                conn.Close();
                if (rowsAffected > 0)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return false;
            }
        }
    }
}
