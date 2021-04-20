using RhpBE100;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primavera.ImportacaCSV.Services
{
    public class ClsFuncionario:Geral
    {
        public ClsFuncionario(object BSO) : base(BSO)
        {

        }
        public ClsFuncionario(object BSO, object Plat) : base(BSO, Plat)
        {

        }

        public void LerDocumentosCSV(FileInfo dra)
        {
            bool sucesso = true;

            try
            {
                string caminhoDoc = dra.FullName;

                RhpBEFuncionario _func = new RhpBEFuncionario();

                string line;

                string codigo;

                using (var reader = new StreamReader(caminhoDoc))
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();

                        var items = line.Split(';');

                        codigo = line.Split(';')[0].ToString();

                        if (codigo != "Codigo")
                        {
                            if (!bso.RecursosHumanos.Funcionarios.Existe(codigo))
                            {
                                _func = new RhpBEFuncionario()
                                {
                                    Funcionario = codigo,
                                    Nome = items[1],
                                    DataAdmissao = DateTime.Now,
                                    NumeroBI = "1111",
                                    VencimentoMensal = Convert.ToDouble(items[19]),
                                    Vencimento = Convert.ToDouble(items[19]),
                                    Instrumento = "001",
                                    Periodo = "P01",
                                    Moeda = bso.Contexto.MoedaBase,
                                    TipoProcessamento = 2,
                                    TipoCalculoVencimento = 1,
                                    TipoRendimento = "A",
                                    TabIRPS = "TAB2014",
                                    Estabelecimento = items[27],
                                    Situacao = items[31]
                                };

                                bso.RecursosHumanos.Funcionarios.Actualiza(_func);
                            }
                            
                        }
                    }


                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
