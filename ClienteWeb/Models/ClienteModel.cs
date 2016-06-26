using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ClienteWeb.Models
{


    
    public class ClienteModel : Model
    {


        // CADASTRAR CLIENTE
        public void Create(Cliente e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"INSERT INTO Cliente 
                                (Nome, Email, Endereco, Genero, Nascimento, Senha, Deleted, DataCadastro)
            	                VALUES 
                                (@nome, @email, @endereco, @genero, @nascimento, @senha, @deleted, @datacadastro)";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@email", e.Email);
            cmd.Parameters.AddWithValue("@endereco", e.Endereco);
            cmd.Parameters.AddWithValue("@genero", e.Genero);
            cmd.Parameters.AddWithValue("@nascimento", e.Nascimento);
            cmd.Parameters.AddWithValue("@senha", e.Senha);
            cmd.Parameters.AddWithValue("@deleted", e.Deleted);
            cmd.Parameters.AddWithValue("@datacadastro", e.DataCadastro);

            cmd.ExecuteNonQuery();
        }





        // LISTANDO CLIENTES (SELECT)


        public List<Cliente> Read()
        {
            List<Cliente> lista = new List<Cliente>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Cliente";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Cliente cliente = new Cliente();
                //cliente.ClienteId = reader.GetInt32(0);
                cliente.ClienteId = (int)reader["ClienteId"];
                cliente.Nome = (string)reader["Nome"];
                cliente.Email = (string)reader["Email"];
                cliente.Endereco = (string)reader["Endereco"];
                cliente.Genero = (Genero)reader["Genero"];
                cliente.Nascimento = (DateTime)reader["Nascimento"];
                // cliente.DataCadastro = (DateTime)reader["DataCadastro"];
                // cliente.Senha = (string)reader["Senha"];              


                lista.Add(cliente);
            }

            /*

            object teste = lista;
            if(teste is List<Cliente>)
            {
                List<Cliente> x = (List<Cliente>)teste;
            }

            */
            

            return lista;
        }

        // BUSCA DE CLIENTE POR NOME

        internal List<Cliente> Read(string nome)
        {
            List<Cliente> lista = new List<Cliente>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select * from Cliente where Nome like @nome";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                //cliente.ClienteId = reader.GetInt32(0);
                cliente.ClienteId = (int)reader["ClienteId"];
                cliente.Nome = (string)reader["Nome"];
                cliente.Email = (string)reader["Email"];
                cliente.Nascimento = (DateTime)reader["Nascimento"];
                cliente.Genero = (Genero)reader["Genero"];
                cliente.DataCadastro = (DateTime)reader["DataCadastro"];

                lista.Add(cliente);
            }

            return lista;

        }
    }


}