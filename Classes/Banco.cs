using System;

namespace digbank.Classes
{
  public abstract class Banco {
    public string NomeDoBanco { get; private set; }
    public string CodigoDoBanco { get; private set; }
    public Banco() {
      this.NomeDoBanco = "DigiBank";
      this.CodigoDoBanco = "027";
    }
  }
}