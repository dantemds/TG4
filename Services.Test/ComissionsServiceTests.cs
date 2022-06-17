using Aplications.DataTransferObjects;
using Aplications.Repositories;
using Aplications.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Services.Test
{
    public class ComissionsServiceTests
    {
        private readonly ComissionsService _comissionsService;
        public ComissionsServiceTests()
        {
            this._comissionsService = new ComissionsService(new Mock<IComissionsRepository>().Object);
        }
        [Fact]
        public void CalculateCommissions_SalerShouldReceiveBonus()
        {
            List<SaleRequestDTO> dataTransferObject = new List<SaleRequestDTO>()
            {
                new SaleRequestDTO(){Vendedor = 1, Data=DateTime.Parse("2022-03-01") ,Valor=100},
                new SaleRequestDTO(){Vendedor = 1, Data= DateTime.Parse("2022-03-01"),Valor=100},
                new SaleRequestDTO(){Vendedor = 1, Data= DateTime.Parse("2022-03-01"),Valor=100}
            };
            
            


            var result = _comissionsService.CalculateCommissions(dataTransferObject);
            
            Assert.True(result[0].Contador.Equals(3));
            Assert.True(result[0].Vendedor.Equals(1));
            Assert.True(result[0].Valor.Equals(3.09));

        }
        [Fact]
        public void CalculateCommissions_SalerShouldNotReceiveBonus()
        {
            List<SaleRequestDTO> dataTransferObject = new List<SaleRequestDTO>()
            {
                new SaleRequestDTO(){Vendedor = 1, Data=DateTime.Parse("2022-03-01") ,Valor=100}
               
            };




            var result = _comissionsService.CalculateCommissions(dataTransferObject);

            Assert.True(result[0].Contador.Equals(1));
            Assert.True(result[0].Vendedor.Equals(1));
            Assert.True(result[0].Valor.Equals(1));

        }
        [Fact]
        public void CalculateCommissions_SalerShouldtReceiveComissionForSaleValue()
        {
            List<SaleRequestDTO> dataTransferObject = new List<SaleRequestDTO>()
            {
                new SaleRequestDTO(){Vendedor = 1, Data=DateTime.Parse("2022-03-01") ,Valor=1000}

            };




            var result = _comissionsService.CalculateCommissions(dataTransferObject);
            var ComissionValue = dataTransferObject[0].Valor * 0.03;
            Assert.True(result[0].Contador.Equals(1));
            Assert.True(result[0].Vendedor.Equals(1));
            Assert.True(result[0].Valor.Equals(ComissionValue));

        }
    }
}
