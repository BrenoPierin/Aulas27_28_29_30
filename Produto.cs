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

        private string PrepararLinhaCSV(Produto prod)
        {
            return $"codigo={Codigo};Nome={Nome};Preço={Preco}";
        }
    }
}