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
           p1.Nome = "Pc Gamer";
           p1.Preco = 1500.99f;

           p1.Inserir(p1);
           p1.Remover("Pc Gamer");
           p1.Filtrar("Mouse Gamer");

           List<Produto> lista = p1.Ler();

       
           foreach(Produto item in lista)
           {
               System.Console.WriteLine($"R${item.Preco} - {item.Nome}");
           }
           

        }


    }
}
