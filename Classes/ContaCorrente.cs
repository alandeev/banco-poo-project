using digbank.Classes;

namespace digbank
{
    class ContaCorrente: Conta {
      public ContaCorrente(){
        this.NumeroConta = "00" + Conta.NumeroContaSequencial;
      }
    }
}