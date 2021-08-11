using ByteBank;
using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Byte_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            // CalcularBonificacao();
            // UsarSistema();
            // TransferirSaldo();
            // CarregarContas();
            // ListarContas();
            // OrdernaContas();
            //CarregarArquivoDeContas();
            CriarArquivo();


            Console.ReadLine();
        }

        static void UsarSistema()
        {
            var sistemaInterno = new SistemaInterno();

            var roberta = new Diretor(5000, "159.753.398-04");
            roberta.Nome = "Roberta";
            roberta.Senha = "123";

            var camila = new GerenteDeConta(4000, "326.985.628-89");
            camila.Nome = "Camila";
            camila.Senha = "abc";

            var parceiro = new ParceiroComercial();
            parceiro.Senha = "123456";

            sistemaInterno.Logar(roberta, "123");
            sistemaInterno.Logar(camila, "abc");
            sistemaInterno.Logar(parceiro, "123456");
        }

        static void CalcularBonificacao()
        {
            var gerenciadorBonificacao = new GerenciadorBonificacao();

            var pedro = new Designer(3000, "833.222.048-39");
            pedro.Nome = "Pedro";

            var roberta = new Diretor(5000, "159.753.398-04");
            roberta.Nome = "Roberta";

            var igor = new Auxiliar(2000, "981.198.778-53");
            igor.Nome = "Igor";

            var camila = new GerenteDeConta(4000, "326.985.628-89");
            camila.Nome = "Camila";

            var guilherme = new Desenvolvedor(3000, "456.175.468-20");
            guilherme.Nome = "Guilherme";

            gerenciadorBonificacao.Registrar(pedro);
            gerenciadorBonificacao.Registrar(roberta);
            gerenciadorBonificacao.Registrar(igor);
            gerenciadorBonificacao.Registrar(camila);
            gerenciadorBonificacao.Registrar(guilherme);

            Console.WriteLine("Total de bonificações do mês " + gerenciadorBonificacao.GetTotalBonificacao());
        }

        static void TransferirSaldo()
        {
            try
            {
                var contaBruno = new ContaCorrente(876, 86712540);
                Cliente cliente = new Cliente();

                cliente.Nome = "Guilherme";
                cliente.CPF = "434.564.879-20";
                cliente.Profissao = "Desenvolvedor";

                contaBruno.Titular = cliente;

                double valorDeposito = 500;
                double valorSaque = 5;
                double valorTransferido = 10;

                contaBruno.Depositar(valorDeposito);
                contaBruno.Sacar(valorSaque);

                Console.WriteLine(contaBruno.Titular.Nome + " Realizou um saque de " + valorSaque);
                Console.WriteLine("Seu novo saldo é " + contaBruno.Saldo);

                Console.WriteLine("--------------------------------------------------");

                var contaGabriela = new ContaCorrente(875, 86755540);
                var clienteGabriela = new Cliente();

                clienteGabriela.Nome = "Gabriela";
                clienteGabriela.CPF = "434.564.820-20";
                clienteGabriela.Profissao = "Teste";

                contaGabriela.Titular = clienteGabriela;
                contaBruno.Transferir(valorTransferido, contaGabriela);

                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine("Valor de " + valorTransferido + " transferido da conta do " + contaBruno.Titular.Nome + " para a conta da " + contaGabriela.Titular.Nome);
                Console.WriteLine("Transferência recebida, seu novo saldo é " + contaGabriela.Saldo);

                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine("Valor da taxa de opreção  " + ContaCorrente.TaxaOperacao);

                Console.WriteLine("Números de contas no Byte Bank " + ContaCorrente.TotalDeContasCriadas);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argumento com problema: " + ex.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException.");
                Console.WriteLine(ex.Message);
            }
            catch (OperacaoFinanceiraException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Execução finalizada. Tecle enter para sair.");
                Console.ReadLine();
            }
        }

        static void CarregarContas()
        {
            using (var leitor = new LeitorDeArquivo("contas.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
        }

        static void ListarContas()
        {
            var lista = new ListaDeContaCorrente();

            var contaLuiz = new ContaCorrente(1111, 111111);

            var contas = new ContaCorrente[]
            {
                new ContaCorrente(874, 7840087),
                new ContaCorrente(875, 7845787),
                new ContaCorrente(876, 7845387),
                new ContaCorrente(877, 78457877)
            };

            lista.AdicionarVarios(contas);


            lista.AdicionarVarios(
                new ContaCorrente(874, 7840087),
                new ContaCorrente(875, 7845787),
                new ContaCorrente(876, 7845387),
                new ContaCorrente(877, 78457877)
            );

            lista.Adicionar(contaLuiz);

            for (int i = 0; i < lista.Tamanho; i++)
            {
                var itemAtual = lista.GetItemNoIndice(i);
                Console.WriteLine($"Item na Posição {i} = Conta {itemAtual.Numero} / {itemAtual.Agencia}");
            }
        }

        static void OrdernaContas()
        {

            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 48950),
                null,
                new ContaCorrente(290, 18950),
                null
            };

            //contas.Sort();
            // contas.Sort(new ComparadorContaCorrentePorAgencia());
            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
        }

        static void CarregarArquivoDeContas()
        {
            var enderecoDoArquivo = "C:/Users/Thiago/source/repos/Byte_Bank/Byte_Bank/Dados/contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDoArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);
                    var msg = $"{contaCorrente.Titular.Nome} : Conta Número {contaCorrente.Numero}, ag. {contaCorrente.Agencia}. Saldo: {contaCorrente.Saldo}";
                    Console.WriteLine(msg);
                }
            } 
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(' ');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace('.', ','));
            var nomeTitular = campos[3];

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agencia, numero);
            resultado.Depositar(saldo);
            resultado.Titular = titular;

            return resultado;
        }

        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "C:/Users/Thiago/source/repos/Byte_Bank/Byte_Bank/Dados/contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))
            {
                escritor.Write("456, 78945,4785.50,Gustavo Santos");
                Console.WriteLine("Arquivo criado com sucesso");
            }
        }
    }
}
