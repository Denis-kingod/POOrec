using System.Collections.Generic;
using System.IO;

namespace POOREC.Models
{
    public class Musico
    {
        public int IdMusico {get; set;}
        public string Nome {get; set;}
        public string Email {get; set;}
        public string Senha {get; set;}
         private  const string CAMINHO = "Database/usuario.csv";
         public Musico(){
             
             CriarPastaEArquivo(CAMINHO);

         }

         private string Preparar(Musico m){
            return $"{m.IdMusico};{m.Nome};{m.Email};{m.Senha}";
        }

        public void Criar(Musico m){
            string[] linha = {Preparar(m)};
            File.AppendAllLines(CAMINHO, linha);

        }
        public List<Musico> LerTodos(){

            List<Musico> musicos = new List<Musico>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Musico musico = new Musico();
                musico.IdMusico = int.Parse(linha[0]);
                musico.Nome = linha[1];
                musico.Email = linha[2];
                musico.Senha = linha[3]; 

                musicos.Add(musico);     
            }

            return musicos;
        }
    }
}