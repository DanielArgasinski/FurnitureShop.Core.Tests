using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FurnitureShop.Core.Tests.Processor
{
    public class FurnitureShopTests
    {

        [Fact]
        public void ReturnReservation()
        {
            var request = new FurnitureReservationRequest
            {
                FirstName = "Daniel",
                Surname = "Argasiński",
                PhoneNu = "123456789",
                Date = new DateTime(2022, 2, 2)

            };
            var processor = new FurnitureReservationRequestProcessor();

            FurnitureReservationResult result = processor.FurnitureReservation(request);


            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.Surname, result.Surname);
            Assert.Equal(request.PhoneNu, result.PhoneNu);
            Assert.Equal(request.Date, result.Date);
        }
    }
}
