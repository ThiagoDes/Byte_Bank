using ByteBank;
using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;

namespace Byte_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcularBonificacao();
            UsarSistema();
            TransferirSaldo();
            Console.ReadLine();
        }

        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();

            Diretor roberta = new Diretor(5000, "159.753.398-04");
            roberta.Nome = "Roberta";
            roberta.Senha = "123";

            GerenteDeConta camila = new GerenteDeConta(4000, "326.985.628-89");
            camila.Nome = "Camila";
            camila.Senha = "abc";

            ParceiroComercial parceiro = new ParceiroComercial();
            parceiro.Senha = "123456";

            sistemaInterno.Logar(roberta, "123");
            sistemaInterno.Logar(camila, "abc");
            sistemaInterno.Logar(parceiro, "123456");
        }

        public static void CalcularBonificacao()
        {
            GerenciadorBonificacao gerenciadorBonificacao = new GerenciadorBonificacao();

            Funcionario pedro = new Designer(3000, "833.222.048-39");
            pedro.Nome = "Pedro";

            Funcionario roberta = new Diretor(5000, "159.753.398-04");
            roberta.Nome = "Roberta";

            Funcionario igor = new Auxiliar(2000, "981.198.778-53");
            igor.Nome = "Igor";

            Funcionario camila = new GerenteDeConta(4000, "326.985.628-89");
            camila.Nome = "Camila";

            Desenvolvedor guilherme = new Desenvolvedor(3000, "456.175.468-20");
            guilherme.Nome = "Guilherme";

            gerenciadorBonificacao.Registrar(pedro);
            gerenciadorBonificacao.Registrar(roberta);
            gerenciadorBonificacao.Registrar(igor);
            gerenciadorBonificacao.Registrar(camila);
            gerenciadorBonificacao.Registrar(guilherme);

            Console.WriteLine("Total de bonificações do mês " + gerenciadorBonificacao.GetTotalBonificacao());
        }

        public static void TransferirSaldo()
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
        }
    }
}
