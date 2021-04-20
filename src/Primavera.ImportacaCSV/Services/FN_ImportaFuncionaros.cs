using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primavera.Extensibility.BusinessEntities;
using Primavera.Extensibility.CustomCode;

namespace Primavera.ImportacaCSV.Services
{
    public class FN_ImportaFuncionaros : CustomCode

    {
        ClsFuncionario motor;
        public void teste()
        {
            try
            {
                motor = new ClsFuncionario(BSO, PSO);

                DirectoryInfo di;
                di = new DirectoryInfo(
                        @"C:\Mahota\Source\CSharp\learn\aula4\primaveraerp-employeemanagment\src\Primavera.ImportacaCSV\Resources"
                    );

                var diar1 = di.GetFiles();

                foreach (FileInfo dra in diar1)
                {

                    motor.LerDocumentosCSV(dra);

                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
