using AutoMapper;
using MassTransit;
using MicroServiceShop.Core.Messages;
using MicroServiceShop.Invoice.WebAPI.Dtos;
using MicroServiceShop.Invoice.WebAPI.Entities;
using MicroServiceShop.Invoice.WebAPI.Services.Interfaces;

namespace MicroServiceShop.Invoice.WebAPI.Consumers
{
    public class CreateInvoiceMessageCommandConsumer : IConsumer<CreateInvoiceMessageCommand>
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public CreateInvoiceMessageCommandConsumer(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<CreateInvoiceMessageCommand> context)
        {

           
            //var addressDto = new AddressDto
            //{
            //    Country = context.Message.Address.Country,
            //    Province = context.Message.Address.Province,
            //    District = context.Message.Address.District,
            //    AddressLine = context.Message.Address.AddressLine,
            //    ZipCode = context.Message.Address.ZipCode
            //};

            
            //var orderItemsDto = context.Message.OrderItems.Select(item => new OrderItemDto
            //{
            //    ProductId = item.ProductId,
            //    ProductName = item.ProductName,
            //    PictureUrl = item.PictureUrl,
            //    Price = item.Price,
            //    Quantity = item.Quantity
            //}).ToList();

            //var address = _mapper.Map<Address>(addressDto);
            //var orderItems = _mapper.Map<List<Entities.OrderItem>>(orderItemsDto);
            
            var createInvoiceDto = new CreateInvoiceDto
            {
                BuyerId = context.Message.BuyerId,
                Address = null, 
                OrderItems = null, 
                InvoiceNumber = context.Message.InvoiceNumber,
                CreateDate = context.Message.CreateDate,
                TotalPrice = 1000

            };

           // TODO: modified invoiceDto
            await _invoiceService.CreateAsync(createInvoiceDto);

        }
    }
}
