using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DemoASP.Pages
{
    public class User
    {
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    public class UserStore
    {
        private string connStr;

        public UserStore(string connStr) {
            this.connStr = connStr;
        }

        public string user = "";
        public string message = "";
        public string retrieveMessage() {
            string it = message;
            message = "";
            return it;
        }
        public User getUser(string username)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                User user = null;
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "SELECT * FROM users WHERE username = @u"
                };
                cmd.Parameters.AddWithValue("u", username);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User
                        {
                            fullname = reader.GetString(reader.GetOrdinal("fullname")),
                            username = reader.GetString(reader.GetOrdinal("username")),
                            password = reader.GetString(reader.GetOrdinal("password")),
                        };

                    }
                }
                return user;
            }
        }

        public string registerUser(User user)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connStr))
            {
                sqlConnection.Open();
                
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "INSERT INTO users (fullname, username, password) VALUES (" +
                        " @fname, @uname, @pass )"
                };
                cmd.Parameters.AddWithValue("fname", user.fullname);
                cmd.Parameters.AddWithValue("uname", user.username);
                cmd.Parameters.AddWithValue("pass", user.password);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    return "Employee record created successfully";
                }
                else
                {
                    return "Error creating employee record";
                }
            }
        }
    }
}