using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.CustomForm;
using Primavera.ImportacaCSV.Services;

namespace Primavera.ImportacaCSV.UI
{
    public partial class FDU_ImportacaoFuncionariosCSV : CustomForm
    {
        ClsFuncionario motor;
        public FDU_ImportacaoFuncionariosCSV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo di;
                di = new DirectoryInfo(
                        @"C:\Mahota\Source\CSharp\learn\aula4\primaveraerp-employeemanagment\src\Primavera.ImportacaCSV\Resources"
                    );

                var diar1 = di.GetFiles();

                foreach (FileInfo dra in diar1)
                {

                    motor.LerDocumentosCSV(dra);

                }

                PSO.Dialogos.MostraAviso("Processo Terminado");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private void FDU_ImportacaoFuncionariosCSV_Load(object sender, EventArgs e)
        {
            

            try
            {
                motor = new ClsFuncionario(BSO, PSO);

                

            }
            catch(Exception ex)
            {

            }
        }
    }
}
