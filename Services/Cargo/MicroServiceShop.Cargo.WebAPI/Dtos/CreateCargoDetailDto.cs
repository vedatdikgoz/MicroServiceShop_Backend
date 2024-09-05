namespace MicroServiceShop.Cargo.WebAPI.Dtos
{
    public class CreateCargoDetailDto
    {
        public string Sender { get; set; } = null!;
        public string Customer { get; set; } = null!;
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
