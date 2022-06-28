namespace FurnitureShop.Core.Domain
{
    public class FurnitureReservationRequest
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNu { get; set; }
        public DateTime Date { get; set; }
    }
}