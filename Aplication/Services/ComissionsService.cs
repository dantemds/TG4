using Aplications.DataTransferObjects;
using Aplications.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplications.Services
{
    public class ComissionsService : IComissionsService
    {
        private readonly IComissionsRepository _comissionRepository;

        public ComissionsService(IComissionsRepository comissionRepository)
        {
            this._comissionRepository = comissionRepository;
        }

        public  ComissionResponseDTO[] CalculateCommissions(List<SaleRequestDTO> dataTransferObject)
        {

            List<Target> targets = new List<Target>()
            {
                new Target { Mes = 1, Quantidade=5},
                new Target { Mes = 2, Quantidade=3},
                new Target { Mes = 3, Quantidade=2},
                new Target { Mes = 4, Quantidade=2},
                new Target { Mes = 5, Quantidade=5},
                new Target { Mes = 6, Quantidade=60},
                new Target { Mes = 7, Quantidade=3},
                new Target { Mes = 8, Quantidade=2},
                new Target { Mes = 9, Quantidade=4},
                new Target { Mes = 10, Quantidade=4},
                new Target { Mes = 11, Quantidade=7},
                new Target { Mes = 12, Quantidade=2},
            };



            //Validações
            ComissionResponseDTO[] comissionDto = new ComissionResponseDTO[dataTransferObject.Count];
            int TotalCounter = 0;
            for (int i = 0; dataTransferObject.Count() > i; i++)
            {

                bool encontrado = false;

                double comissionValue;

                if (dataTransferObject[i].Valor <= 300)
                    comissionValue = dataTransferObject[i].Valor * 0.01;

                else if (dataTransferObject[i].Valor > 300 && dataTransferObject[i].Valor <= 1000)
                    comissionValue = dataTransferObject[i].Valor * 0.03;

                else comissionValue = dataTransferObject[i].Valor * 0.05;


                for (int j = 0; j < TotalCounter; j++)
                {

                    if (dataTransferObject[i].Vendedor == comissionDto[j].Vendedor && dataTransferObject[i].Data.Month == comissionDto[j].Data.Month && dataTransferObject[i].Data.Year == comissionDto[j].Data.Year)
                    {
                        encontrado = true;
                        comissionDto[j].Contador++;
                        comissionDto[j].Valor += comissionValue;
                        break;
                    }

                }
                if (!encontrado)
                {
                    comissionDto[TotalCounter++] = new ComissionResponseDTO
                    {
                        Vendedor = dataTransferObject[i].Vendedor,
                        Contador = 1,
                        Data = dataTransferObject[i].Data,
                        Valor = comissionValue

                    };


                };
            }
            ComissionResponseDTO[] orderComission = comissionDto.Where(n => n != null).OrderBy(x => x.Vendedor).ToArray();
            foreach (var saler in orderComission)
            {
                foreach(var target in targets)
                {

                    if(saler.Contador >= target.Quantidade && target.Mes== saler.Data.Month)
                    {
                        saler.Valor += saler.Valor * 0.03;
                    }
                }
            }
            
            return orderComission;
        }
    }
}
