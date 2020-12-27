using digbank.Classes;

namespace digbank
{
    class ContaPoupanca: Conta {
      public ContaPoupanca(){
        this.NumeroConta = "00" + Conta.NumeroContaSequencial;
      }
    }
}