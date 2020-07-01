using System;
using System.Collections.Generic;

namespace Aula27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
           Produto p1 = new Produto();
           p1.Codigo = 1;
           p1.Nome = "esojo";
           p1.Preco = 19.99f;

           p1.Inserir(p1);

           List<Produto> lista = p1.Ler();
           
        //    List<Produto> list = p1.Filtrar("estojo");

        p1.Remover("estojo");
           

           foreach(Produto p in lista)
           {
               System.Console.WriteLine($"R${p.Preco} - {p.Nome} - {p.Codigo}");
           }
           

        }


    }
}
