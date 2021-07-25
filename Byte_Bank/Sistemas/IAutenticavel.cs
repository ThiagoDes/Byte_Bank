using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Sistemas
{
    public interface IAutenticavel
    {
        bool Autenticar(string senha);
    }
}
