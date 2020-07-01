using System;
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

            // Solução do desafio e criar os arquivos se n existir
                if(!File.Exists(PATH))
                {
                Directory.CreateDirectory("Database");
                File.Create(PATH).Close();
                }
        }

        public void Inserir(Produto prod)
        {
            var linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Metodo paraler os produtos em lista
        /// </summary>
        /// <returns>Lista de produtos no arquivo csv e no console</returns>
        public List<Produto> Ler()
        {
            //lista criada
            List<Produto> prod = new List<Produto>();

            //Transformar as linhas em um array de string;
            string[] linhas = File.ReadAllLines(PATH);

            //Varri o array em strings
            foreach( var linha in linhas )
            {
                //Separei os termos entre os ';'
                string[] dado = linha.Split(';');

                // dado[0] = codigo=1
                // dado[1] = nome=Gibson
                // dado[2] = preco=5500

                //declarando um novo tipo de "produto" e tratando os resultados;
                Produto p   = new Produto(); 
                p.Codigo    = Int32.Parse( Separar(dado[0]) );
                p.Nome      = Separar(dado[1]);
                p.Preco     = float.Parse( Separar(dado[2]) );

                //Adicionei o produto na lista;
                prod.Add(p);
            }

            prod = prod.OrderBy( z => z.Nome ).ToList();
            //Retornei o produto;
            return prod;
        }


        //filtro de produstos (desafio da aula)
        public List<Produto> Filtrar(string _nome)
        {
            return Ler().FindAll(x => x.Nome == _nome);
        }

        public void Remover(string _termo)
        {
            //Criamos uma lista de linhas para fazer um "backup"
            //na memoria do sistema
            List<string> linhas = new List<string>();


            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
                linhas.RemoveAll(z => z.Contains(_termo));
            }

            //criamos uma forma de reescrever o arquivo sem as linhas rmovidas
            using(StreamWriter output = new StreamWriter(PATH))
            {
                output.Write(String.Join(Environment.NewLine, linhas.ToArray())); 
            }
        }

        /// <summary>
        /// metodo que separa os termos do "="
        /// </summary>
        /// <param name="dados">separa os dados do csv</param>
        /// <returns>somente os valores da coluna</returns>
        public string Separar(string dados){
            //Separei os dados em dois
            //Antes: código = {p.Codigo};
            //Agora: código[0] | {p.Codigo}[1];
            return dados.Split('=')[1];

        }


        private string PrepararLinha(Produto p)
        {
            return $"\ncodigo={Codigo};nome={Nome};preco={Preco}";
        }
    }
}