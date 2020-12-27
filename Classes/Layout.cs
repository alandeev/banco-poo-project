using System;
using System.Collections.Generic;

namespace digbank.Classes
{
  class Layout {
    private static List<Pessoa> pessoas = new List<Pessoa>();
    private static int opcao = 0;
    private static bool isConnected = false;
    public static void MainScreen(){
      // Console.BackgroundColor = ConsoleColor.Blue;
      // Console.ForegroundColor = ConsoleColor.White;

      Console.Clear();
      
      Console.WriteLine("                                                 ");
      Console.WriteLine("             DIGITE A OPÇÃO DESEJADA:            ");
      Console.WriteLine("             1 - Criar Conta                     ");
      Console.WriteLine("             =====================               ");
      Console.WriteLine("             2 - Entrar com CPF e Senha          ");
      Console.WriteLine("             =====================               ");
      opcao = int.Parse(Console.ReadLine());

      do {
        if(opcao == 1){
          Layout.RegisterScreen();
        }else if(opcao == 2){
          Layout.LoginScreen();
        }
      }while(opcao != 1 && opcao != 2);
      return;
    }

    public static void RegisterScreen(){
      Console.Clear();
    
      Pessoa pessoa = new Pessoa();

      Console.WriteLine("");
      Console.WriteLine("Digite seu nome: ");
      string nome = Console.ReadLine();
      pessoa.setNome(nome);
      
      Console.WriteLine("");
      Console.WriteLine("Digite seu cpf: ");
      string cpf = Console.ReadLine();
      pessoa.setCPF(cpf);

      Console.WriteLine("");
      Console.WriteLine("Digite sua senha: ");
      string senha = Console.ReadLine();
      pessoa.setSenha(senha);

      int typeAccount;
      while(true){
        Console.WriteLine("");
        Console.WriteLine("Tipo da Conta: ");
        Console.WriteLine("1 - [Corrente]");
        Console.WriteLine("2 - [Poupança]");
        typeAccount = int.Parse(Console.ReadLine());
        if(typeAccount == 1){
          pessoa.Conta = new ContaCorrente();
          break;
        }else if(typeAccount == 2){
          pessoa.Conta = new ContaPoupanca();
        }
        Console.WriteLine("Você escolhe uma opção invalida!");
      }

      pessoas.Add(pessoa);
      Layout.MainScreen();
    }

    public static void LoginScreen(){
      Console.WriteLine("");
      Console.WriteLine("Digite seu cpf: ");
      string cpf = Console.ReadLine();

      Console.WriteLine("");
      Console.WriteLine("Digite sua senha: ");
      string senha = Console.ReadLine();
      
      Console.WriteLine("");
      Pessoa pessoa = pessoas.Find((pessoa) => pessoa.CPF == cpf && pessoa.Senha == senha);
      if(pessoa == null){
        Console.WriteLine("");
        Console.WriteLine("Conta não encontrada!");
        return;
      }
      
      isConnected = true;
      Layout.ScreenConnected(pessoa);
    }

    public static void welcomeScreen(Pessoa pessoa){
      Console.WriteLine($" Seja bem vindo {pessoa.Nome} | Banco {pessoa.Conta.GetCodigoDoBanco()} | Saldo {pessoa.Conta.ConsultaSaldo()} | Conta: {pessoa.Conta.GetNumeroConta()}");
      return;
    }
    public static void ScreenConnected(Pessoa pessoa){
      Console.WriteLine("                                                 ");
      welcomeScreen(pessoa);
      Console.WriteLine("                                                 ");
      Console.WriteLine("             DIGITE A OPÇÃO DESEJADA:            ");
      Console.WriteLine("             1 - Depositar                       ");
      Console.WriteLine("             =====================               ");
      Console.WriteLine("             2 - Sacar                           ");
      Console.WriteLine("             =====================               ");
      Console.WriteLine("             3 - Detalhes                        ");
      Console.WriteLine("             =====================               ");
      Console.WriteLine("             4 - Sair da Conta                   ");
      Console.WriteLine("             =====================               "); 
      Console.Write("Opcao: ");
      int opcao = int.Parse(Console.ReadLine());

      switch(opcao){
        case 1:
          Layout.depositScreen(pessoa);
          break;

        case 2:
          Layout.withdrawScreen(pessoa);
          break;

        case 3:
          detailsScreen(pessoa);
          break;

        case 4:
          MainScreen();
          break;

        default:
          return;
      }
    }

    public static void depositScreen(Pessoa pessoa){
      Console.Clear();
      Console.WriteLine("                                                 ");
      welcomeScreen(pessoa);
      Console.WriteLine("                                                 ");
      Console.WriteLine("                OPÇAO DE DEPOSITO                ");
      Console.Write("VALOR: ");
      double valor = double.Parse(Console.ReadLine());
      pessoa.Conta.Deposita(valor);
      ScreenConnected(pessoa);
    }

    public static void withdrawScreen(Pessoa pessoa){
      Console.Clear();
      Console.WriteLine("                                                 ");
      welcomeScreen(pessoa);
      Console.WriteLine("                                                 ");
      Console.WriteLine("                  OPÇAO DE SAQUE                 ");
      Console.Write("VALOR: ");
      double valor = double.Parse(Console.ReadLine());
      bool sacou = pessoa.Conta.Saca(valor);
      if(!sacou){
        Console.WriteLine("Você não têm saldo suficiente!");
      }
      Console.WriteLine("                                                 "); 
      ScreenConnected(pessoa);
    }

    public static void detailsScreen(Pessoa pessoa){
      Console.Clear();
      Console.WriteLine("                                                 ");
      Console.WriteLine($"    Olá {pessoa.Nome}, suas informações!        ");
      Console.WriteLine("                                                 ");
      Console.WriteLine($"    CPF: {pessoa.CPF}                           ");
      Console.WriteLine($"    SENHA: {pessoa.Senha}                       ");
      Console.WriteLine("                                                 ");
      Console.WriteLine($"    SALDO: {pessoa.Conta.ConsultaSaldo()}       ");
      Console.WriteLine("                                                 ");
      ScreenConnected(pessoa);
    }
  }
}