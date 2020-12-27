using System;
using digbank.Contratos;

namespace digbank.Classes
{
  public abstract class Conta : Banco, IConta
  {
    public Conta() {
      this.Saldo = 0;
      this.NumeroConta = "0001";
      Conta.NumeroContaSequencial++;
    }

    public double Saldo { get; protected set; }
    public string NumeroAgencia { get; private set; }
    public string NumeroConta { get; protected set; }
    public static int NumeroContaSequencial { get; private set; }

    public double ConsultaSaldo()
    {
      return this.Saldo;
    }

    public void Deposita(double valor)
    {
      this.Saldo += valor;
    }

    public string GetCodigoDoBanco()
    {
      return this.CodigoDoBanco;
    }

    public string GetNumeroAgencia()
    {
      return this.NumeroAgencia;
    }

    public string GetNumeroConta()
    {
      return this.NumeroConta;
    }

    public bool Saca(double valor)
    {
      if(valor > this.ConsultaSaldo()){
        return false;
      }

      this.Saldo -= valor;
      return true;
    }
  }
}