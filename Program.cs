using System;
using System.Collections.Generic;

namespace Aula27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Produto prod = new Produto();
            prod.Codigo = 2;
            prod.Nome = "Xbox one";
            prod.Preco = 1900f;

            prod.Cadastrar(prod);

            prod.Remover("2");

            Produto alterado = new Produto();
            alterado.Codigo = 2;
            alterado.Nome = "Xbox 360";
            alterado.Preco = 600f;

            prod.Alterar(alterado);


            List<Produto> lista = prod.Ler();

            foreach (Produto item in lista)
            {
                Console.WriteLine($"R${item.Preco} - {item.Nome}");
            }




        }
    }
}
