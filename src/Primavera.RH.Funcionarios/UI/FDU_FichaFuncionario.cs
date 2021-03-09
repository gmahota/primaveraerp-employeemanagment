using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.CustomForm;
using RhpBE100;

namespace Primavera.RH.Funcionarios.UI
{
    public partial class FDU_FichaFuncionario : CustomForm
    {
        public FDU_FichaFuncionario()
        {
            InitializeComponent();
        }

        private void btProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                string str_codigo = txtCodigo.Text;
                string str_nome = txtNome.Text;
                decimal dbl_salario = txtSalario.Value;

                var funcionario = new RhpBEFuncionario();

                if (BSO.RecursosHumanos.Funcionarios.Existe(str_codigo))
                {
                    //PSO.Dialogos.MostraAviso("Atenção o Funcionario Já existe !!!");
                }
                else
                {
                    funcionario.Funcionario = str_codigo;
                    funcionario.Nome = str_nome;
                    funcionario.VencimentoMensal = (double)dbl_salario;
                    funcionario.Vencimento = (double)dbl_salario;
                    funcionario.TipoRendimento = "A";
                    funcionario.TabIRPS = "TAB2014";
                    funcionario.DataAdmissao = DateTime.Now;
                    funcionario.Situacao = "001";
                    funcionario.Instrumento = "001";
                    funcionario.Estabelecimento = "001";

                    BSO.RecursosHumanos.Funcionarios.Actualiza(funcionario);
                    PSO.Dialogos.MostraAviso("Gravado Com Sucesso");
                }

                
            }
            catch(Exception ex)
            {
                PSO.Dialogos.MostraAviso("Aconteceu um erro na gravação",
                    StdPlatBS100.StdBSTipos.IconId.PRI_Exclama,
                    ex.Message);
            }
        }
    }
}
