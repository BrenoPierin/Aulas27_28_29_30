using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula27_28_29_30
{
    public class Produto : IProduto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";

        public Produto()
        {
            
            // Solução do desafio
            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }
            

            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Metodo para inserir os produtos na lista
        /// </summary>
        /// <param name="prod">Nome do variavel produto</param>
        public void Cadastrar(Produto prod)
        {
            var linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Metodo para ler os produtos em lista
        /// </summary>
        /// <returns>Lista de produtos no arquivo csv e no console</returns>
        public List<Produto> Ler()
        {
            //lista criada
            List<Produto> produtos = new List<Produto>();

            //Transformar as linhas em um array de string;
            
            string[] linhas = File.ReadAllLines(PATH);

            //Varri o array em strings
            foreach(string linha in linhas){
                
                //Separei os termos entre os ';'
                string[] dado = linha.Split(";");

                // [0] = codigo=2
                // [1] = nome=Xbox one
                // [2] = preco=1900

                
                Produto p   = new Produto();
                p.Codigo    = Int32.Parse( Separar(dado[0]) );
                p.Nome      = Separar(dado[1]);
                p.Preco     = float.Parse( Separar(dado[2]) );

                produtos.Add(p);
            }

            produtos = produtos.OrderBy(y => y.Nome).ToList();
            return produtos; 
        }

        /// <summary>
        /// Exclui algum dado da aplicação
        /// </summary>
        /// <param name="_termo">Qualquer termo para apagar a linha</param>
        ///        
        public void Remover(string _termo){

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
            }

            // Removi as linhas que tiverem o termo passado como argumento
            linhas.RemoveAll(l => l.Contains(_termo));

            // Reescreve o csv
            ReescreverCSV(linhas);
        }
        
         /// <summary>
        /// Metodo que altera partes ou por completo de uma(s) linha(s)
        /// </summary>
        /// <param name="_ProdutoAlterado">Argumento para modificar</param>
        /// ----------------------------------------------------------------------------------------------
        
        public void Alterar(Produto _produtoAlterado){

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
            }
            // codigo=2;nome=Xbox one;preco=1900
            // linhas.RemoveAll(y => y.Split(";")[0].Contains(_produtoAlterado.Codigo.ToString()));
            
            // codigo= 2; nome=Ibanez;preco=7500
            linhas.RemoveAll(y => y.Split(";")[0].Split("=")[1] == _produtoAlterado.Codigo.ToString());

            //adicionamos a linha alterada na lista de "backup"
            linhas.Add( PrepararLinha(_produtoAlterado) );

            //criamos uma forma de reescrever o arquivo sem as linhas rmovidas
            ReescreverCSV(linhas);         
        }

        /// <summary>
        /// Metodo Para reescrever o cvs
        /// </summary>
        /// <param name="lines"></param>
        private void ReescreverCSV(List<string> lines){
            // Reescrevi o csv do zero
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln + "\n");
                }
            }   
        }

        /// <summary>
        /// Metodo para "filtar" os produtos
        /// </summary>
        /// <param name="_nome">nome do produto</param>
        /// <returns>produtos em ordem alfabetica</returns>
        public List<Produto> Filtrar(string _nome)
        {
            return Ler().FindAll(x => x.Nome == _nome);
        }

        /// <summary>
        /// metodo para separar
        /// </summary>
        /// <param name="_coluna"></param>
        /// <returns>Produto separado em 3 dados</returns>
        private string Separar(string _coluna)
        {
            return _coluna.Split("=")[1];
        }

        private string PrepararLinha(Produto p)
        {
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }

    }
}