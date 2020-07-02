using System;
using System.Collections.Generic;
using System.Threading;

namespace POO27_DATABASE
{
    class Program
    {
        static void Main(string[] args)
        {
        Produto p1 = new Produto();
        p1.Codigo = 1;
        p1.Nome = "Gianini5";
        p1.Preco = 7500f;

            ((IProduto)p1).Cadastrar(p1);
        
        Produto alterado = new Produto();
        alterado.Codigo = 3;
        alterado.Nome = "Ibanez";
        alterado.Preco = 6800f;

            ((IProduto)p1).Alterar(alterado);

            ((IProduto)p1).Remover("Gianini5");

        List<Produto> lista = ((IProduto)p1).Ler();

        foreach(Produto item in lista){
            Console.WriteLine($"R$ {item.Preco} - {item.Nome}");
        }
        }
    }
}
