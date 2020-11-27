using System;

namespace Sistema_de_Produtos
{
    class Program
    {
        static void Main(string[] args)
        {
            int escolha;
            int contador = 0;
            int tentativas = 0;
            string resposta;
            string repetir = "N";
            bool senhaCorreta;
            string senha;
            string[] nomes = new string[3];
            float[] preco = new float[3];
            bool[] promocao = new bool[3];





            Console.WriteLine("-------------------------------------");
            Console.WriteLine("---------Sistema de Produtos---------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            do{
                Console.WriteLine("Digite a senha de acesso");
                senha = Console.ReadLine();
                senhaCorreta = EfetuarLogin(senha);
            }while(!senhaCorreta);

            do{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Menu Principal");  
                Console.ResetColor();
                Console.WriteLine("Selecione uma opção abaixo");
                Console.WriteLine("[1] - Cadastrar um Produto");
                Console.WriteLine("[2] - Lista de Produtos");
                Console.WriteLine("[3] - Produtos em Promoção");
                Console.WriteLine("[0] - Sair");
                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Cadastre até três Produto");
                        Console.ResetColor();


                        do{
                            Console.Write($"Nome do {contador+1}° Produto: ");
                            nomes[contador] = Console.ReadLine();
                            Console.Write($"Preço do {contador+1}° Produto: ");
                            preco[contador] = float.Parse(Console.ReadLine());
                            Console.WriteLine($"{contador+1}° produto está em promoção? [S/N]");
                            resposta = Console.ReadLine().ToUpper();
                            switch (resposta){
                                case "S":
                                    promocao[contador] = true;
                                    break;
                                case "N":
                                    promocao[contador] = false;
                                    break;
                                default:
                                    Console.WriteLine("Resposta inválida");
                                    break;
                            }
                            contador++;
                            
                            if(contador < 3){
                            Console.WriteLine("Deseja cadastar outro produto? [S/N]");
                            repetir = Console.ReadLine().ToUpper();
                            }

                            Console.Clear();
                            
                        }while(contador < 3 && repetir == "S");

                        if(contador == 3){
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("O número de produtos cadastrados alcançou o limite");
                            Console.ResetColor();
                            Console.WriteLine("--------------------------------------------------");
                        }
                        
                        break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("-------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("                     Lista de Produtos                       ");
                            Console.ResetColor();
                            Console.WriteLine("-------------------------------------------------------------");

                            for (var i = 0; i < contador; i++){
                                Console.Write("Nome: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(nomes[i]);
                                Console.ResetColor();
                                Console.Write(" -- Preço: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(preco[i].ToString("C"));
                                Console.ResetColor();
                                Console.Write(" -- Está em promoção? ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                if (promocao[i] == true){
                                    Console.WriteLine("Sim");
                                }else{
                                    Console.WriteLine("Não");
                                }
                                Console.ResetColor();

                                
                            }
                            if (contador == 0){
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Nenhum produto cadastrado");
                                Console.ResetColor();
                            }
                            Console.WriteLine("-------------------------------------------------------------");

                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("-------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("                    Produtos em Promoção                     ");
                            Console.ResetColor();
                            Console.WriteLine("-------------------------------------------------------------");

                            for (var i = 0; i < contador; i++){
                                if(promocao[i] == true){
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(nomes[i]);
                                    Console.ResetColor();
                                }
                            }

                            Console.WriteLine("-------------------------------------------------------------");
                            break;
                        default:
                            break;
                }
                

            } while (escolha != 0);

            Console.WriteLine("-------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("              Obrigado por usar nossos serviços!             ");
            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------------------");


            bool EfetuarLogin(string senha){
               if (senha == "123"){
                   Console.Clear();
                   Console.WriteLine("----------------------------");
                   Console.ForegroundColor = ConsoleColor.Cyan;
                   Console.WriteLine("       Seja Bem-Vindo!      ");
                   Console.ResetColor();
                   Console.WriteLine("----------------------------");
                   return true;
               }else{
                   tentativas++;
                   if(tentativas == 3){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Senha inválida, número máximo de tentativas excedido!");
                        Console.ResetColor();
                        Console.WriteLine("-----------------------------------------------------");
                        Environment.Exit(-1);
                   } else{
                        Console.ForegroundColor = ConsoleColor.Red;
                       Console.WriteLine("Senha inválida, digite de novo!");
                        Console.ResetColor();
                       Console.WriteLine("-------------------------------");
                   }
                   return false;
               }

            }

        }
    }
}
