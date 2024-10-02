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

          
            var createInvoiceDto = new CreateInvoiceDto
            {
               
                BuyerId = context.Message.BuyerId,
                Country = context.Message.Country,
                Province = context.Message.Province,
                District = context.Message.District,
                AddressLine = context.Message.AddressLine,
                ZipCode = context.Message.ZipCode,
                InvoiceNumber = context.Message.InvoiceNumber,
                CreateDate = context.Message.CreateDate,
                TotalPrice = context.Message.OrderItems.Sum(i => i.Price * i.Quantity),
                OrderItems = new List<CreateInvoiceOrderItemDto>()
            };
            foreach (var item in context.Message.OrderItems)
            {
                createInvoiceDto.OrderItems.Add(new CreateInvoiceOrderItemDto
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    PictureUrl = item.PictureUrl,
                    Price = item.Price,
                    Quantity = 1
                });
            }
        
            await _invoiceService.CreateAsync(createInvoiceDto);

        }
    }
}
