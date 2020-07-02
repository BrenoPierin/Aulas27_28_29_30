using System.Collections.Generic;

namespace Aula27_28_29_30
{
    public interface IProduto
    {
        
         void Cadastrar(Produto prod);
         List<Produto> Ler();
         void Remover(string _termo);
         void Alterar(Produto _produtoAlterado);
        
    }
}