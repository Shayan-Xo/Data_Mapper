using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMapper.Modle;
using MySql.Data.MySqlClient;

namespace DataMapper.Data_Mapper
{
    public class MediaDataMapper : IDataMapper<Media>
    {
        String connString;
        MySqlConnection conn;
        public MediaDataMapper()
        {
            connString = "server=localhost;port=3306;database=datamapper;uid=root;password=k190294";
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
        }
        public bool Save(Media Entity)
        {
            var name = Entity.Name;
            var id = Entity.Id;
            var mediatype = Entity.MediaType;
            if (Enum.IsDefined(typeof(Media_type), mediatype))
            {
                conn.Open();
                string sql = "insert into datamapper.media (idMedia,Name,Mediatype) values(@id,@name,@mediatype);";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@mediatype", mediatype);
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
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            int id1 = id;
            conn.Open();
            string sql_check = "select * from datamapper.media";
            MySqlCommand command = new MySqlCommand(sql_check, conn);
            MySqlDataReader reader = command.ExecuteReader();
            var hasrows = reader.HasRows;
            conn.Close();

            if (hasrows)
            {
                conn.Open();
                string sql_del = "delete from datamapper.media where idMedia=@id1;";
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
                return(false);
            }
        }

        public List<Media> GetAll()
        {
            conn.Open();
            string sql_get = "Select * from datamapper.media;";
            MySqlCommand command = new MySqlCommand(sql_get, conn);
            MySqlDataReader reader = command.ExecuteReader();
            List<Media> list = new List<Media>();
            while (reader.Read())
            {
                Media m1=new Media();
                m1.Id = (int)reader["idMedia"];
                m1.Name = (string)reader["Name"];
                int mediatype = int.Parse((string)reader["MediaType"]);
                m1.MediaType = (Media_type)Enum.ToObject(typeof(Media_type), mediatype);
                list.Add(m1);
            }
            return list;
        }

        public Media GetById(int id){
            conn.Open();
            string sql_check = "select * from datamapper.media where idMedia=@id;";
            MySqlCommand command = new MySqlCommand(sql_check, conn);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Media m1 = new Media();
                m1.Id = (int)reader["idMedia"];
                m1.Name = (string)reader["Name"];
                int mediatype = int.Parse((string)reader["MediaType"]);
                m1.MediaType = (Media_type)Enum.ToObject(typeof(Media_type), mediatype);
                conn.Close();
                return m1;
            }
            else{
                return null;
            }
            
        }

        public bool Update(int id, Media Entity)
        {
            conn.Open();
            string sql_get = "Select * from datamapper.media where idMedia=@id;";
            MySqlCommand command = new MySqlCommand(sql_get, conn);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();
            var hasrows = reader.HasRows;
            conn.Close();
            if(hasrows)
            {
                conn.Open();
                string sql_upd = "update datamapper.media set Name=@name,MediaType=@mediatype where idMedia=@id";
                MySqlCommand command1 = new MySqlCommand(sql_upd, conn);
                command1.Parameters.AddWithValue("@id", id);
                command1.Parameters.AddWithValue("@name", Entity.Name);
                command1.Parameters.AddWithValue("@mediatype", Entity.MediaType);
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
