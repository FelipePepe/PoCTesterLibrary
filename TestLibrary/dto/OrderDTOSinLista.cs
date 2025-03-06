using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.dto
{
    public class OrderDTOSinLista
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public CustomerDTO Customer { get; set; }
        public ProductDTO Products { get; set; }
        public AddressDTO ShippingAddress { get; set; }

        public OrderDTOSinLista()
        {
            Products = new ProductDTO();
        }

        // ToString para OrderDTO
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"OrderId: {OrderId}");
            sb.AppendLine($"OrderNumber: {OrderNumber}");
            sb.AppendLine($"Customer: {Customer?.ToString()}");
            sb.AppendLine($"ShippingAddress: {ShippingAddress?.ToString()}");

            sb.AppendLine("Products:");

            sb.AppendLine($"  - {Products.ToString()}");


            return sb.ToString();
        }
    }
}
