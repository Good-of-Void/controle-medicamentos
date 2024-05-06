using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloFuncionarios;
using ControleMedicamentos.ConsoleApp.ModuloFornecedores;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao.Saida;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada;

namespace ControleMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //paciente
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();

            TelaPaciente telaPaciente = new TelaPaciente();
            telaPaciente.tipoEntidade = "Paciente";
            telaPaciente.repositorio = repositorioPaciente;

            telaPaciente.CadastrarEntidadeTeste();

            //funcionario
            RepositorioFuncionario repositorioFuncionarios = new RepositorioFuncionario();

            TelaFuncionario telaFuncionarios = new TelaFuncionario();
            telaFuncionarios.tipoEntidade = "Funcionário";
            telaFuncionarios.repositorio = repositorioFuncionarios;

            //fornecedor
            RepositorioFornecedor repositorioFornecedores = new RepositorioFornecedor();

            TelaFornecedor telaFornecedores = new TelaFornecedor();
            telaFornecedores.tipoEntidade = "Fornecedor";
            telaFornecedores.repositorio = repositorioFornecedores;

            //medicamento
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.repositorio = repositorioMedicamento;
            telaMedicamento.tipoEntidade = "Medicamento";

            telaMedicamento.telaFornecedor = telaFornecedores;
            telaMedicamento.repositorioFornecedor = repositorioFornecedores;

            //requisicao Saida
            RepositorioRequisicaoSaida repositorioRequisicaoSaida = new RepositorioRequisicaoSaida();

            TelaRequisicaoSaida telaRequisicaoSaida = new TelaRequisicaoSaida();
            telaRequisicaoSaida.repositorio = repositorioRequisicaoSaida;
            telaRequisicaoSaida.tipoEntidade = "Requisição de saida";

            telaRequisicaoSaida.telaPaciente = telaPaciente;
            telaRequisicaoSaida.telaMedicamento = telaMedicamento;

            telaRequisicaoSaida.repositorioPaciente = repositorioPaciente;
            telaRequisicaoSaida.repositorioMedicamento = repositorioMedicamento;

            //requisicao Entrada
            RepositorioRequisiçaoEntrada repositorioRequisiçaoEntrada = new RepositorioRequisiçaoEntrada();

            TelaRequisiçaoEntrada telaRequisiçaoEntrada = new TelaRequisiçaoEntrada();
            telaRequisiçaoEntrada.repositorio = repositorioRequisiçaoEntrada;
            telaRequisiçaoEntrada.tipoEntidade = "Requisição de entrada";

            telaRequisiçaoEntrada.telaPaciente = telaPaciente;
            telaRequisiçaoEntrada.telaFornecedor = telaFornecedores;
            telaRequisiçaoEntrada.telaFuncionario = telaFuncionarios;
            telaRequisiçaoEntrada.telaMedicamento = telaMedicamento;

            telaRequisiçaoEntrada.repositorioPaciente = repositorioPaciente;
            telaRequisiçaoEntrada.repositorioFornecedor = repositorioFornecedores;
            telaRequisiçaoEntrada.repositorioFuncionario = repositorioFuncionarios;
            telaRequisiçaoEntrada.repositorioMedicamento = repositorioMedicamento;

            
            

            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaPaciente;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaMedicamento;

                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaFuncionarios;

                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaFornecedores;

                else if (opcaoPrincipalEscolhida == '5')
                    tela = telaRequisicaoSaida;

                else if (opcaoPrincipalEscolhida == '6')
                    tela = telaRequisiçaoEntrada;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
            }

            Console.ReadLine();
        }
    }
}
