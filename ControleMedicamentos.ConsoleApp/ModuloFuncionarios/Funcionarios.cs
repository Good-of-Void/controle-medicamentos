using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionarios
{
    internal class Funcionarios : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public Funcionarios(string nome, string telefone, string cPF)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cPF;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
            int contadorErros = 0;

            if (Nome.Length < 3)
                erros.Add ("O Nome do Funcionário precisa conter ao menos 3 caracteres");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("O Telefone precisa ser preenchido");

            if (string.IsNullOrEmpty(CPF))
                erros.Add("O CPF precisa ser preenchido");          

            return erros;
        }
    }
}
