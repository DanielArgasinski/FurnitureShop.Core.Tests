using FurnitureShop.Core.DataInterface;
using FurnitureShop.Core.Domain;
using FurnitureShop.Core.Processor;
using Moq;
using Xunit;

namespace FurnitureShop.Core.Tests.Processor
{
    public class FurnitureShopTests
    {
        private readonly FurnitureReservationRequest _request;
        private readonly List<FurnitureReservation> _availableFurniture;
        private readonly Mock<IFurnitureReservationRepository> _furnitureReservationRepositoryMock;
        private readonly Mock<IReservationRepository> _reservationRepositoryMock;
        private FurnitureReservationRequestProcessor _processor;

        public FurnitureShopTests()
        {
            _request = new FurnitureReservationRequest
            {
                FirstName = "Daniel",
                Surname = "Argasiński",
                PhoneNu = "123456789",
                Date = new DateTime(2022, 2, 2)

            };

            _availableFurniture = new List<FurnitureReservation> { new FurnitureReservation() };

            _furnitureReservationRepositoryMock = new Mock<IFurnitureReservationRepository>();
            _reservationRepositoryMock = new Mock<IReservationRepository>();
            _reservationRepositoryMock.Setup(a => a.AvailaleFurniture(_request.Date))
                .Returns(_availableFurniture);

            _processor = new FurnitureReservationRequestProcessor(
                _furnitureReservationRepositoryMock.Object, _reservationRepositoryMock.Object);
        }

        [Fact]
        public void ReturnReservation()
        {
            FurnitureReservationResult result = _processor.FurnitureReservation(_request);

            Assert.NotNull(result);
            Assert.Equal(_request.FirstName, result.FirstName);
            Assert.Equal(_request.Surname, result.Surname);
            Assert.Equal(_request.PhoneNu, result.PhoneNu);
            Assert.Equal(_request.Date, result.Date);
        }

        [Fact]
        public void SaveReservation()
        {
            FurnitureReservation savedReservation = null;
            _furnitureReservationRepositoryMock.Setup(a => a.Save(It.IsAny<FurnitureReservation>()))
                .Callback<FurnitureReservation>(furnitureReservation =>
                {
                    savedReservation = furnitureReservation;
                });

            _processor.FurnitureReservation(_request);

            _furnitureReservationRepositoryMock.Verify(a => a.Save(It.IsAny<FurnitureReservation>()), Times.Once());

            Assert.NotNull(savedReservation);
            Assert.Equal(_request.FirstName, savedReservation.FirstName);
            Assert.Equal(_request.Surname, savedReservation.Surname);
            Assert.Equal(_request.PhoneNu, savedReservation.PhoneNu);
            Assert.Equal(_request.Date, savedReservation.Date);
        }

        [Fact]
        public void Availability()
        {
            _availableFurniture.Clear();

            _processor.FurnitureReservation(_request);

            _furnitureReservationRepositoryMock.Verify(a => a.Save(It.IsAny<FurnitureReservation>()), Times.Never());

        }
    }
}
