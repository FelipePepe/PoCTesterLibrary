using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.dto
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public CustomerDTO Customer { get; set; }
        public List<ProductDTO> Products { get; set; }
        public AddressDTO ShippingAddress { get; set; }

        public OrderDTO()
        {
            Products = new List<ProductDTO>();
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
            foreach (var product in Products)
            {
                sb.AppendLine($"  - {product.ToString()}");
            }

            return sb.ToString();
        }
    }

    // DTO para el cliente
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public AddressDTO BillingAddress { get; set; }

        // ToString para CustomerDTO
        public override string ToString()
        {
            return $"CustomerId: {CustomerId}, FullName: {FullName}, Email: {Email}, BillingAddress: {BillingAddress?.ToString()}";
        }
    }

    // DTO para el producto
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // ToString para ProductDTO
        public override string ToString()
        {
            return $"ProductId: {ProductId}, Name: {Name}, Price: {Price}";
        }
    }

    // DTO para la dirección
    public class AddressDTO
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        // ToString para AddressDTO
        public override string ToString()
        {
            return $"{Street}, {City}, {State}, {PostalCode}";
        }
    }
}
