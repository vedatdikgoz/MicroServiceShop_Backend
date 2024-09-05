namespace MicroServiceShop.Cargo.WebAPI.Dtos
{
    public class UpdateCargoDetailDto
    {
        public int Id { get; set; }
        public string Sender { get; set; } = null!;
        public string Customer { get; set; } = null!;
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
