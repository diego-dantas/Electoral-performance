using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ElectoralPerformance.model.DAO
{
    public class Connection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string connectionString;



           
        //Metodo de inicialização da conexão com o banco
        private void initialize()
        {
            //Passagem dos parametros do servidor de Banco
            server = "localhost";
            database = "db_analise";
            uid = "root";
            password = "";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            //Realiza a conexão com o banco
            connection = new MySqlConnection(connectionString);
        }


        public bool openConnection()
        {
            try
            {
                initialize();
                connection.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Erro ao abrir a cenexão" + ex);
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                connection.Clone();
                return true;
            }catch(MySqlException ex)
            {
                Console.WriteLine("Erro ao fechar a cenexão" + ex);
                return false;
            }
        }

        public void insert(string query)
        {
            //string query = "insert into teste(desci) values('teste 2')";

            if(this.openConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                this.closeConnection();
            }
        }

        
        public MySqlDataReader select(string query)
        {
           MySqlDataReader dataReader;
           this.openConnection();
           MySqlCommand cmd = new MySqlCommand(query, connection);
           dataReader = cmd.ExecuteReader();
           this.closeConnection();
           return dataReader;
        }





    }
}
