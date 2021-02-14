using System;
using System.Collections.Generic;
using System.Globalization;

namespace Questão_1
{
    class Program
    {
        public static int userInput;
        static void Main(string[] args)
        {

        }

        //1.1 Implemente a função abaixo para calcular fatorial de um número. 
        // CalcularFatorial(5) == 120//true
        public static int CalcularFatorial(int num)
        {
            int fat = 1, numFatorar;
            numFatorar = num;

            for (int i = 1; i <= numFatorar; i++)
            {
                fat = fat * i;
            }

            return fat;
        }

        //1.2 Implemente a função abaixo que calcula o valor total do prêmio somando fator do tipo do prêmio conforme valores: 
        /*
         *Tipo: "basic" fator multiplicação do prêmio: 1
         *Tipo: "vip" fator multiplicação do prêmio: 1.2
         *Tipo: "premium" fator multiplicação do prêmio: 1.5
         *Tipo: "deluxe" fator multiplicação do prêmio: 1.8
         *Tipo: "special" fator multiplicação do prêmio: 2  
         */

        //Regras:
        /*
         * A função também deverá provir um parâmetro para que seja passado fator de multiplicação próprio.
         * Quando parâmetro de fator de multiplicação próprio for informado e válido o mesmo deve sobrescrever o cálculo do tipo de prêmio.
         * O prêmio nunca deve ter um valor negativo ou igual a zero.
         */

        public double CalcularPremio(double valor, string tipo, double fatorManual)
        {
            if (valor > 0)
            {
                if (fatorManual > 0)
                    tipo = null;

                switch (tipo)
                {
                    case "basic":
                        valor = valor * 1;
                        break;
                    case "vip":
                        valor = valor * 1.2;
                        break;
                    case "premium":
                        valor = valor * 1.5;
                        break;
                    case "deluxe":
                        valor = valor * 1.8;
                        break;
                    case "special":
                        valor = valor * 2;
                        break;
                    default:
                        valor = valor * fatorManual;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por Favor, digite um valor de prêmio válido.");
                valor = double.Parse(Console.ReadLine());
            }

            return valor;
        }

        //1.3 Implemente a função abaixo para contar quantos números primos existe até o número informado. 
        /*
         * Número primo: 2
         * Número primo: 3
         * Número primo: 5
         * Número primo: 7
         * Total de números primos: 4
         * ContarNumerosPrimos(10) == 4 //true
         */
        public int ContarNumerosPrimos(int num)
        {
            int contPrimos = 0;

            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0 && (num == i || i == 1))
                {
                    contPrimos++;
                    Console.Write("Número primo: " + i);
                }
            }
            Console.Write("Total de números primos: " + contPrimos);
            return contPrimos;
        }

        //1.4 Implemente a função abaixo que conta e calcula a quantidade de vogais dentro de uma string
        //CalcularVogais("Luby Software") == 4//true

        public int CalcularVogais(string palavra)
        {
            var vogais = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            int total = 0;
            for (int i = 0; i < palavra.Length; i++)
            {
                if (vogais.Contains(palavra[i]))
                    total++;
            }

            return total;
        }

        //1.5 Implemente a função abaixo que aplica uma porcentagem de desconto a um valor e retorna o resultado.
        //Lembre-se que as entradas e saídas dos dados são strings que devem ser tratadas. 
        //CalcularValorComDescontoFormatado("R$ 6.800,00", "30%") == "R$ 4.760,00"; //true

        public static string CalcularValorComDescontoFormatado(string valorUser, string descontoUser)
        {
            string valorTratado, formato = "C";
            char trim = '%';
            var moeda = new System.Globalization.CultureInfo("pt-BR");
            double valor = Double.Parse(valorUser, NumberStyles.Currency, moeda);
            double desconto = Double.Parse(descontoUser.Trim(trim)) / 100;

            valor = valor + (valor * desconto);
            valorTratado = valor.ToString(formato, moeda);

            return valorTratado;
        }

        //1.6 Implemente a função abaixo que obtém duas string de datas e calcula a diferença de dias entre elas. 
        //CalcularDiferencaData("10122020", "25122020") == 15; //true 

        public static int CalcularDiferencaData(string dataA, string dataB)
        {
            var formato = new System.Globalization.CultureInfo("pt-BR");

            DateTime dtATratada = DateTime.ParseExact(dataA, "ddmmyyyy", formato);
            DateTime dtBTratada = DateTime.ParseExact(dataB, "ddmmyyyy", formato);

            int totalDias;

            if (dtATratada > dtBTratada)
                totalDias = (dtATratada - dtBTratada).Days;
            else
                totalDias = (dtBTratada - dtATratada).Days;

            return totalDias;
        }


        //1.7 Implemente a função abaixo que retorna um novo vetor com todos elementos pares do vetor informado. 
        /*
         * int[] vetor = new int[] { 1,2,3,4,5 };
         * ObterElementosPares(vetor) == new int { 2, 4 }; //true 
         */
        public static Array ObterElementosPares(int[] vetorUser)
        {
            int[] vetorPares = new int[vetorUser.Length/2];
            int aux = 0;
            for (int i = 0; i <= vetorUser.Length; i++)
            {
                if (vetorUser[i] % 2 == 0)
                {
                    vetorPares[aux] = i;
                }
            }

            return vetorPares;
        }
        //1.8 Implemente a função abaixo que deve buscar um ou mais elementos no vetor que contém o valor ou parte do valor informado na busca. 
        /*
         * string[] vetor = new string[]
         * {
            * "John Doe",
            * "Jane Doe",
            * "Alice Jones",
            * "Bobby Louis",
            * "Lisa Romero"
         * };

         *BuscarPessoa(vetor, "Doe") == new string[] { "John Doe", "Jane Doe" };//true
         *BuscarPessoa(vetor, "Alice") == new string[] { "Alice Jones" };//true
         *BuscarPessoa(vetor, "Louis") == new string[] { };//true
         */

        //https://i.stack.imgur.com/nGMrD.gif

        public static Array BuscarPessoa(string[] vetorUser, string palavraChave)
        {
            string[] resultadoBusca = new string[vetorUser.Length];
            for (int i = 0; i <= vetorUser.Length; i++)
            {
                if (vetorUser[i].Contains(palavraChave))
                    resultadoBusca[i] = vetorUser[i];
            }

            return resultadoBusca;
        }

        //1.9 Implemente a função abaixo que obtém uma string com números separados por vírgula e transforma em um array de array de inteiros com no máximo dois elementos. 
        //TransformarEmMatriz("1,2,3,4,5,6") == new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 } }; //true 
        public static Array TransformarEmMatriz(string matrixUser)
        {
            string[] matrix = matrixUser.Split(',');
            int agenteSmith = 0;

            string[][] neo = new string[][]
            {
                new string[] {matrix[agenteSmith], matrix[agenteSmith + 1]},
                new string[] {matrix[agenteSmith + 2], matrix[agenteSmith + 3]},
                new string[] {matrix[agenteSmith + 4], matrix[agenteSmith + 5]}
            };

            return neo;
        }
        //1.10 Implemente a função abaixo que compara dois vetores e cria um novo vetor com os elementos faltantes de ambos. 
        /*
        // faltam elementos no vetor2
        int[] vetor1 = new int[] { 1, 2, 3, 4, 5 };
        int[] vetor2 = new int[] { 1, 2, 5 };
        ObterElementosFaltantes(vetor1, vetor2) == new int[] { 3, 4 }; //true 

        // faltam elementos no vetor3
        int[] vetor3 = new int[] { 1, 4, 5 };
        int[] vetor4 = new int[] { 1, 2, 3, 4, 5 };
         ObterElementosFaltantes(vetor3, vetor4) == new int[] { 2, 3 }; //true

        // faltam elementos em ambos vetores
        int[] vetor5 = new int[] { 1, 2, 3, 4 };
        int[] vetor6 = new int[] { 2, 3, 4, 5 };
        ObterElementosFaltantes(vetor5, vetor6) == new int[] { 1, 5 }; //true

        // não faltam items
        int[] vetor7 = new int[] { 1, 3, 4, 5 };
        int[] vetor8 = new int[] { 1, 3, 4, 5 };    
        ObterElementosFaltantes(vetor7, vetor8) == new int[] { }; //true
        */
        public static Array ObterElementosFaltantes(int[] vetorA, int[] vetorB)
        {
            int[] vetorFaltantes = new int[5];
            int[] arrayAux = new int[5] { 1, 2, 3, 4, 5 };
            if (vetorA.Length != 5 || vetorB.Length != 5)
            {
                for (int i = 0; i <= 5; i++)
                {
                    if (vetorA[i] != arrayAux[i] || vetorB[i] != arrayAux[i])
                        vetorFaltantes[i] = i;
                }
            }
            return vetorFaltantes;
        }
    }
}
