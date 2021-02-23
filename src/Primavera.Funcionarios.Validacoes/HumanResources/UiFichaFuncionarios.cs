using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.BusinessEntities.ExtensibilityService.EventArgs;
using Primavera.Extensibility.HumanResources.Editors;

namespace Primavera.Funcionarios.Validacoes.HumanResources
{
    public class UiFichaFuncionarios : FichaFuncionarios
    {
        public override void AntesDeEditar(string Funcionario, ref bool Cancel, ExtensibilityEventArgs e)
        {
            base.AntesDeEditar(Funcionario, ref Cancel, e);

            PSO.Dialogos.MostraAviso("Atenção ao mecher na ficha do funcionario");
        }

        public override void AntesDeGravar(ref bool Cancel, ExtensibilityEventArgs e)
        {
            base.AntesDeGravar(ref Cancel, e);

            try
            {
                string str_avisos = "";
                string numbeneficiario = this.Funcionario.NumBeneficiario;
                bool cdu_reembolsoImpostos = Convert.ToBoolean(this.Funcionario.CamposUtil["CDU_RembolsoImpostos"].Valor);

                if(cdu_reembolsoImpostos == true)
                {
                    str_avisos = str_avisos + "Atenção o funcionario com reembolso de impostos" + Environment.NewLine;

                }
                if (numbeneficiario.Length != 9)
                {
                    str_avisos = str_avisos + "Atenção o funcionario deve ter 9 digitos no num beneficiorio" +Environment.NewLine;
                    Cancel = true;
                }

                if(str_avisos.Length > 0)
                {
                    PSO.Dialogos.MostraAviso(str_avisos);
                }
            }
            catch (Exception ex)
            {
                PSO.Dialogos.MostraAviso(ex.Message);
            }
        }
    }
}
