using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Sistemas
{
    public class SistemaInterno
    {
        public bool Logar(IAutenticavel funcionario, string senha)
        {
            bool usuarioAutenticado = funcionario.Autenticar(senha);

            if (!usuarioAutenticado)
            {
                Console.WriteLine("Senha incorreta!");
                return false;
            }

            Console.WriteLine("Bem-vindo ao sistema!");
            return true;

        }
    }
}
