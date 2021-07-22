using System.Collections.Generic;
using System.IO;

namespace POOREC.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        private const string CAMINHO = "DataBase/Usuario.csv";

        private string Preparar(Usuario u)
        {

            return $"{u.IdUsuario};{u.Nome};{u.Email};{u.Senha}";

        }

        public void Criar(Usuario u)
        {

            string[] linha = { Preparar(u) };
            File.AppendAllLines(CAMINHO, linha);

        }
        // public List<Usuario> LerTodos()
        // {

        //     List<Usuario> usuarios = new List<Usuario>();
        //     string[] linhas = File.ReadAllLines(CAMINHO);

        //     foreach (var item in linhas)
        //     {

        //         string[] linha = item.Split(";");

        //         Usuario usuario = new Usuario();
        //         usuario.IdUsuario = int.Parse(linha[0]);
        //         usuario.Nome = linha[1];
        //         usuario.Email = linha[2];
        //         usuario.Senha = linha[3];

        //         usuarios.Add(usuario);

        //     }

        //     return usuarios;

        }
    }
}