using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClienteWeb.Models
{

    //using inteiro = System.Int32;

    public class Cliente
    {

        // campo:
        private int clienteId;

        // propriedades:
        public int ClienteId
        {
            get { return clienteId; }
            set { clienteId = value; }
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Endereco { get; set; }

        public Genero Genero { get; set; }

        public DateTime Nascimento { get; set; }

        public string Senha { get; set; }

        public bool Deleted { get; set; }

        public DateTime DataCadastro { get; set; }




    }

    // public enum Genero { Masculino = 1, Feminino = 2 }
    /*
        Cliente cli;
        inf(ClienteWeb.Genero == Genero.Masculino)
    */
}


