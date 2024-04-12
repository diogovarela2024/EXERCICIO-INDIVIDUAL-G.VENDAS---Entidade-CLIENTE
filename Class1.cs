using System;

namespace MeuProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EXERCICIO INDIVIDUAL");
            Console.WriteLine("Entidade CLIENTES");

            // Exemplo de chamada de uma função
            MostrarMensagem();
        }

        static void MostrarMensagem()
        {
            Console.WriteLine("INICIAR");
        }
    }
}
using System;
using System.Collections.Generic;

namespace GestaoVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar uma lista de produtos
            List<Produto> produtos = new List<Produto>();
            produtos.Add(new Produto(1, "Portatil", 1500));
            produtos.Add(new Produto(2, "Telemovel", 800));
            produtos.Add(new Produto(3, "Impressora", 200));

            // Criar um cliente
            Cliente cliente = new Cliente("Miguel", "miguel2022@email.com", "Rua Agostinho, 203");

            // Criar um carrinho de compras
            Carrinho carrinho = new Carrinho(cliente);

            // Adicionar produtos ao carrinho
            carrinho.AdicionarItem(produtos[0], 2);
            carrinho.AdicionarItem(produtos[1], 1);
            carrinho.AdicionarItem(produtos[2], 1);

            // Calcular o total da compra
            double totalCompra = carrinho.CalcularTotal();

            // Exibir detalhes da compra
            Console.WriteLine("Detalhes da Compra:");
            Console.WriteLine("Cliente: " + carrinho.Cliente.Nome);
            Console.WriteLine("Endereço de Entrega: " + carrinho.Cliente.Endereco);
            Console.WriteLine("Itens do Carrinho:");
            foreach (var item in carrinho.Itens)
            {
                Console.WriteLine("- " + item.Produto.Nome + " (Quantidade: " + item.Quantidade + ")");
            }
            Console.WriteLine("Total da Compra: $" + totalCompra);
        }
    }

    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto(int id, string nome, double preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
    }

    class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public ItemCarrinho(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }
    }

    class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        public Cliente(string nome, string email, string endereco)
        {
            Nome = nome;
            Email = email;
            Endereco = endereco;
        }
    }

    class Carrinho
    {
        public Cliente Cliente { get; }
        public List<ItemCarrinho> Itens { get; }

        public Carrinho(Cliente cliente)
        {
            Cliente = cliente;
            Itens = new List<ItemCarrinho>();
        }

        public void AdicionarItem(Produto produto, int quantidade)
        {
            Itens.Add(new ItemCarrinho(produto, quantidade));
        }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (var item in Itens)
            {
                total += item.Produto.Preco * item.Quantidade;
            }
            return total;
        }
    }
}


