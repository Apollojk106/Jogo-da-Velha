namespace jogo
{
    public class Program
    {

        public static void Main() 
        {
            bool FimDeJogo = false;
            string vez = "X";
            int contador = 0;
            string[] posicoes = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            while (!FimDeJogo)
            {
                //imprime a tabela
                

                Console.WriteLine($"{posicoes[0]}_|_{posicoes[1]}_|_{posicoes[2]}");
                Console.WriteLine($"{posicoes[3]}_|_{posicoes[4]}_|_{posicoes[5]}");
                Console.WriteLine($"{posicoes[6]} | {posicoes[7]} | {posicoes[8]}");

                //Entrada de dado
                Console.WriteLine("Insira uma posição valida dentro de 1 a 9:");
                bool conversao = int.TryParse(Console.ReadLine(), out int escolha);

                //verifica a entrada de dado
                recerifi:
                while (!conversao || escolha > 9 || escolha < 1)
                {
                    Console.WriteLine("Possição invalida!");
                    Console.WriteLine("Insira uma posição valida dentro de 1 a 9:");
                    conversao = int.TryParse(Console.ReadLine(), out escolha);
                    
                }
                if (posicoes[escolha - 1] == "X" || posicoes[escolha - 1]== "O") {escolha = 0; goto recerifi; }

                //resultado dos dados
                posicoes[escolha - 1] = vez;
                contador++;
                
                //trocar a vez
                if (vez == "X") 
                {vez = "O";} 
                else 
                {vez = "X"; }              

                Console.Clear();

                //Verificar possiveis Vitorias
                if (contador > 4) {

                    //vertical
                    if (posicoes[0] == posicoes[1] || posicoes[0] == posicoes[2]) { FimDeJogo = true; }
                    if (posicoes[3] == posicoes[4] || posicoes[3] == posicoes[5]) { FimDeJogo = true; }
                    if (posicoes[6] == posicoes[7] || posicoes[6] == posicoes[8]) { FimDeJogo = true; }

                    //horizontal

                    if (posicoes[0] == posicoes[3] || posicoes[0] == posicoes[6]) { FimDeJogo = true; }
                    if (posicoes[1] == posicoes[4] || posicoes[1] == posicoes[7]) { FimDeJogo = true; }
                    if (posicoes[2] == posicoes[5] || posicoes[2] == posicoes[8]) { FimDeJogo = true; }

                    //diagonal
                    if (posicoes[6] == posicoes[4] || posicoes[6] == posicoes[2]) { FimDeJogo = true; }
                    if (posicoes[0] == posicoes[4] || posicoes[0] == posicoes[8]) { FimDeJogo = true; }
                }

                //Terminar o jogo
                if (contador > 9)
                {
                    Console.WriteLine("Empate!");
                    goto end;
                }

            }

            Console.WriteLine($"{posicoes[0]}_|_{posicoes[1]}_|_{posicoes[2]}");
            Console.WriteLine($"{posicoes[3]}_|_{posicoes[4]}_|_{posicoes[5]}");
            Console.WriteLine($"{posicoes[6]} | {posicoes[7]} | {posicoes[8]}");
            Console.WriteLine($"Parabens '{vez}',voce venceu");
        end:
            Console.WriteLine("Fim");
        }
    }
}