using System;

namespace Byte_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaBruno = new ContaCorrente(876, 86712540);
            Cliente cliente = new Cliente();

            cliente.Nome = "Guilherme";
            cliente.CPF = "434.564.879-20";
            cliente.Profissao = "Desenvolvedor";

            contaBruno.Titular = cliente;
            contaBruno.Saldo += 4500;

            double valorDeposito = 500;
            double valorSaque = 755;
            double valorTransferido = 500;

            contaBruno.Depositar(valorDeposito);
            bool resultadoSaque = contaBruno.Sacar(valorSaque);

            if (!resultadoSaque)
            {
                Console.WriteLine("Saque não aprovado.");
                Console.ReadLine();
            }

            Console.WriteLine(contaBruno.Titular.Nome + " Realizou um saque de " + valorSaque);
            Console.WriteLine("Seu novo saldo é " + contaBruno.Saldo);

            Console.WriteLine("--------------------------------------------------");

            ContaCorrente contaGabriela = new ContaCorrente(875, 86755540);
            Cliente clienteGabriela = new Cliente();

            clienteGabriela.Nome = "Gabriela";
            clienteGabriela.CPF = "434.564.820-20";
            clienteGabriela.Profissao = "Teste";

            contaGabriela.Titular = clienteGabriela;
            contaBruno.Transferir(valorTransferido, contaGabriela);

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Valor de " + valorTransferido + " transferido da conta do " + contaBruno.Titular.Nome + " para a conta da " + contaGabriela.Titular.Nome);
            Console.WriteLine("Transferência recebida, seu novo saldo é " + contaGabriela.Saldo);

            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("Números de contas no Byte Bank " + ContaCorrente.TotalDeContasCriadas);
            Console.ReadLine();
        }
    }
}
