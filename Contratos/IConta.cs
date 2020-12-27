namespace digbank.Contratos
{
    public interface IConta {
      void Deposita(double valor);
      bool Saca (double valor);
      double ConsultaSaldo();
      string GetCodigoDoBanco();
      string GetNumeroAgencia();
      string GetNumeroConta();
    }
}