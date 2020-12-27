using digbank.Contratos;

namespace digbank.Classes
{
    public class Pessoa {
      public string Nome { get; private set; }
      public string CPF { get; private set; }
      public string Senha { get; private set; }
      public IConta Conta { get; set; }

      public void setNome(string nome){
        this.Nome = nome;
      }
      public void setCPF(string cpf){
        this.CPF = cpf;
      } 
      public void setSenha(string senha){
        this.Senha = senha;
      }
    }
}