using System.Collections.Generic;
using System.IO;
namespace Aula27_28_29_30
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH = "Database/Produto.csv";

        public Produto()
        {
            string pasta = PATH.Split('/')[0];

             if (!Directory.Exists(pasta))
            {
               Directory.CreateDirectory(pasta);
              
            }
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public void Inserir(Produto p)
        {
            var linha = new string[] {p.PrepararLinhaCSV(p)};
            File.AppendAllLines(PATH, linha);
        }

        public List<Produto> Ler()
        {
            //lista criada
            List<Produto> produtos = new List<Produto>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach( var linha in linhas )
            {
                string[] dados = linha.Split(';');

                Produto p = new Produto();
                p.Codigo  = int.Parse(SepararDado(dados[0]));
                p.Nome  = SepararDado(dados[1]);
                p.Preco  = float.Parse(SepararDado(dados[2]));

                produtos.Add(p);
            }

            return produtos;

        }

        public string SepararDado(string dados)
        {
            return dados.Split('=')[1];
        }

        private string PrepararLinhaCSV(Produto prod)
        {
            return $"codigo={Codigo};Nome={Nome};Preço={Preco}";
        }
    }
}