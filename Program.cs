using System;
using System.Collections.Generic;
using System.Globalization;

namespace DesafioOO
{
    //Desenvolver programa que rode uma Vending Machine (Máquina de venda de bebidas em lata) utilizando orientação objetos conforme as regras abaixo.
    /*
     * A máquina deverá possuir um estoque de produtos com valor e quantidade de cada produto.
     * A máquina não necessita de lógica de contagem de notas, será apenas necessário informar os valores.
     * Uma venda só poderá ser concluída ao inserir o valor total do produto.
     * A máquina deverá contabilizar e solicitar o valor faltante para finalizar a venda, caso haja valor de troco para deverá informar o valor.
     * A máquina deverá contabilizar as vendas e mostrar o valor total das vendas realizadas.
     * A máquina só pode vender produtos com quantidade em estoque disponível.
     * A máquina deverá ter opção para visualizar estoque e quantidade disponível.
     * A quantidade de produto no estoque da máquina deve ser alterado conforme realização de vendas dos produtos.
     * Caso necessário crie um documento simples com informações de como executar o programa.
     * Crie uma interface de usuário simples para execução da máquina.
     */
    class Program
    {
        public static int vendas = 0;

        public static Produto[] estoque = new Produto[4];
        static void Main(string[] args)
        {
            InicializarMaquina();
            MenuInicial();
        }

        public static void MenuInicial()
        {
            Console.Clear();
            string bebidas = "    ", precos = " ", nomes = "";

            for (int i = 0; i < estoque.Length; i++)
            {
                bebidas += estoque[i].icone + "       ";
                nomes += estoque[i].nome + " | ";
                precos += TratarValor(estoque[i].preco)+ " - ";
            }

            Console.WriteLine(bebidas);
            Console.WriteLine(nomes);
            Console.WriteLine(precos);
            Console.WriteLine("");
            Console.WriteLine("Aperte uma tecla para escolher a bebida:");
            Console.WriteLine("");
            Console.WriteLine("Q - " + estoque[0].nome + " - " + estoque[0].icone);
            Console.WriteLine("W - " + estoque[1].nome + " - " + estoque[1].icone);
            Console.WriteLine("E - " + estoque[2].nome + " - " + estoque[2].icone);
            Console.WriteLine("R - " + estoque[3].nome + " - " + estoque[3].icone);
            Console.WriteLine("");
            Console.WriteLine("Ou aperte 'I' para ver o Inventário, Z para sair.");
            SelecionarBebida(Console.ReadKey().KeyChar);

        }

        public static void SelecionarBebida(char selecaoUser)
        {
            Console.Clear();
            switch (selecaoUser)
            {
                case 'q':
                    ComprarBebida(0);
                    break;
                case 'w':
                    ComprarBebida(1);
                    break;
                case 'e':
                    ComprarBebida(2);
                    break;
                case 'r':
                    ComprarBebida(3);
                    break;
                case 'i':
                    ChecarEstoque();
                    break;
                case 'z':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Tecla Inválida! Por favor, tente novamente");
                    Console.ReadKey();
                    MenuInicial();
                    break;
            }
        }

        public static void ComprarBebida(int selecaoUser)
        {

            Console.WriteLine(estoque[selecaoUser].icone + " Custa: " + TratarValor(estoque[selecaoUser].preco));
            Console.WriteLine("Por favor, insira a quantidade de dinheiro que desejar.");

            string valorInserido = Console.ReadLine();

            if (Decimal.TryParse(valorInserido, out decimal valor))
            {
                Calcular(valor, estoque[selecaoUser].preco);
            }
            else
            {
                Console.WriteLine("Valor inválido, tente novamente.");
                ComprarBebida(selecaoUser);
            }
        }
        public static void Calcular(decimal valorUser, decimal precoBebida)
        {
            decimal resultado = valorUser - precoBebida;
            if (resultado < 0M)
            {
                Console.WriteLine("Opa, o valor não é suficiente, por favor tente novamente, o restante é:" + TratarValor(resultado * -1));
                Calcular(decimal.Parse(Console.ReadLine()), resultado * -1);
            }
            else if (resultado > 0M)
            {
                vendas += 1;
                Console.WriteLine("Ótimo! Aqui está seu troco: " + TratarValor(resultado));
                Console.WriteLine("Voltando para o Menu.");
                Console.ReadKey();
                MenuInicial();
            }
            else
            {
                vendas += 1;
                Console.WriteLine("Aqui está sua bebida! Voltando para o Menu...");
                Console.ReadKey();
                MenuInicial();
            }
        }

        public static void ChecarEstoque()
        {
            Console.WriteLine("Temos os seguintes produtos: ");
            for (int i = 0; i < estoque.Length; i++)
            {
                Console.WriteLine(estoque[i].icone + " " + estoque[i].nome + " - Preço: " + TratarValor(estoque[i].preco) + ", Em Estoque: " + estoque[i].qtd);
            }
            Console.WriteLine();
            Console.WriteLine("E fizemos " + vendas + " vendas.");
            Console.ReadKey();
            MenuInicial();
        }


        public static void InicializarMaquina()
        {
            estoque[0] = new Produto("Nuka-Cola", 5.50m, 5, "|©|");
            estoque[1] = new Produto("Moloko", 7.50m, 6, "|¤|");
            estoque[2] = new Produto("Buzz Cola", 6.50m, 4, "|~|");
            estoque[3] = new Produto("Butterbeer", 5.00m, 7, "|ß|");
        }
        public static string TratarValor(decimal valorUser)
        {
            /*
            decimal value;
                if(Decimal.TryParse(strOrderId, out value))
                // It's a decimal
                else
                // No it's not.
            */

            string formato = "C", valorTratado;
            var moeda = new System.Globalization.CultureInfo("pt-BR");

            valorTratado = valorUser.ToString(formato, moeda);

            return valorTratado;
        }


        public class Produto
        {
            public string nome;
            public decimal preco;
            public int qtd;
            public string icone;
            
            public Produto(string marca, decimal valor, int estoque, string icon)
            {
                nome = marca;
                preco = valor;
                qtd = estoque;
                icone = icon;
            }
        }
    }
}
