using System;
using System.Collections.Generic;
using System.IO;

namespace POO27_DATABASE
{
    public class Produto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";

        public Produto(){
            //--------------------------
            //solução do desafio
            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta)){
                Directory.CreateDirectory(pasta);
            }
            //---------------------------------
            if(!File.Exists(PATH)){
                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Cadastra um produto
        /// </summary>
        /// <param name="prod">Objeto produto</param>
        public void Cadastrar(Produto prod){
            var linha = new string[] { PrepararLinha(prod) };
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// Lê o csv
        /// </summary>
        /// <returns>Lista de produtos</returns>
        public List<Produto> Ler()
        {
            // Foi feita uma lista que servirá como nosso retorno
            List<Produto> produtos = new List<Produto>();

            //Lemos o arquivo e transformamos em um array de linhas
            //[0] = codigo=1;nome=Gibson;preco=7500
            //[1] = codigo=1;nome=Fender;preco=7500
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string linha in linhas){
                
            //Separamos os dados de cada linha com split
            //[0] = codigo=1
            //[1] = nome=gibson
            //[2] = preco=7500
            string[] dado = linha.Split(";");

            //Foram criadas instâncias de produtos para serem colocados na lista
            Produto p = new Produto();
            p.Codigo  = Int32.Parse(Separar(dado[0]) );
            p.Nome    = Separar(dado[1] );
            p.Preco   = float.Parse( Separar(dado[2]) );

            produtos.Add(p);
            }

            return produtos;
        }
        private string Separar (string _coluna)
        {
            // 0
            // nome = Gibson
            return _coluna.Split("=")[1];
        }

        private string PrepararLinha(Produto p){
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }
    }
}