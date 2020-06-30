using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        /// <summary>
        /// Metodo paraler os produtos em lista
        /// </summary>
        /// <returns>Lista de produtos no arquivo csv e no console</returns>
        public List<Produto> Ler()
        {
            //lista criada
            List<Produto> produtos = new List<Produto>();

            //Transformar as linhas em um array de string;
            string[] linhas = File.ReadAllLines(PATH);

            //Varri o array em strings
            foreach( var linha in linhas )
            {
                //Separei os termos entre os ';'
                string[] dados = linha.Split(';');


                //declarando um novo tipo de "produto" e tratando os resultados;
                Produto p = new Produto();
                p.Codigo  = int.Parse(SepararDado(dados[0]));
                p.Nome  = SepararDado(dados[1]);
                p.Preco  = float.Parse(SepararDado(dados[2]));

                //Adicionei o produto na lista;
                produtos.Add(p);
            }
            foreach(var linha in linhas)
            {
                string[] dados = linha.Split(';');
                
                Produto produt = new Produto();
                var y = produt.Nome.OrderBy(c => produt.Nome );

                System.Console.WriteLine(y);
                
            }
            //Retornei o produto;
            return produtos;
        }

        // public void Listar()
        // {
        //     string[] prod = File.ReadAllLines(PATH);

        //     foreach(var p in prod)
        //     {
        //         string[] dados = p.Split(';');
                
        //         Produto produt = new Produto();
        //         var y = produt.Ler().OrderBy(c => c.Nome );

        //         foreach(Produto pro in y)
        //         {
        //         System.Console.WriteLine(y);
        //         }
        //     }
        // }

        /// <summary>
        /// metodo que separa os termos do "="
        /// </summary>
        /// <param name="dados">separa os dados do csv</param>
        /// <returns>somente os valores da coluna</returns>
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