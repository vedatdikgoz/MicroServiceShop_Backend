namespace MicroServiceShop.Cargo.WebAPI.Entities
{
    public class CargoDetail
    {
        public int Id { get; set; }
        public string Sender { get; set; } = null!;
        public string Customer { get; set; } = null!;
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
        public CargoCompany CargoCompany { get; set; } = null!;
    }
}
