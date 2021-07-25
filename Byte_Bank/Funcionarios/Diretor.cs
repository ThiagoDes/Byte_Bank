using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel
    {

        public Diretor(double salario, string cpf) :base(salario, cpf)
        {
            Console.WriteLine("Crindo Diretor");
        }

        public bool Autenticar(string senha)
        {
            return true;
        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }

        public override double GetBonificacao()
        {
            return Salario + 0.5;
        }
    }
}
