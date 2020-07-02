using System.Collections.Generic;

namespace POO27_DATABASE
{
    public interface IProduto
    {
     void Cadastrar(Produto prod);

     void Remover(string _termo);

     void Alterar(Produto _produtoAlterado);
     
    List<Produto> Ler();

    }
}