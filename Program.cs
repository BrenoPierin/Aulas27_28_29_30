using System;

namespace Aula27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
           Produto p1 = new Produto(1 , "estojo", 19.99f);
           p1.Inserir(p1);

        }
    }
}
