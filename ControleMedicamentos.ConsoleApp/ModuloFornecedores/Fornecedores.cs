using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedores
{
    internal class Fornecedores
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

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (Nome.Length < 3)
                erros[contadorErros++] = "O Nome do Fornecedor precisa conter ao menos 3 caracteres";

            if (string.IsNullOrEmpty(Telefone))
                erros[contadorErros++] = "O Telefone precisa ser preenchido";

            if (string.IsNullOrEmpty(CNPJ))
                erros[contadorErros++] = "O CNPJ precisa ser preenchido";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
