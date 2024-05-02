using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedores
{
    internal class Fornecedores : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CNPJ { get; set; }

        public Fornecedores(string nome, string telefone, string cNPJ)
        {
            Nome = nome;
            Telefone = telefone;
            CNPJ = cNPJ;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
            int contadorErros = 0;

            if (Nome.Length < 3)
                erros.Add ("O Nome do Fornecedor precisa conter ao menos 3 caracteres");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add ("O Telefone precisa ser preenchido");

            if (string.IsNullOrEmpty(CNPJ))
                erros.Add("O CNPJ precisa ser preenchido");
            
            return erros;
        }
    }
}
