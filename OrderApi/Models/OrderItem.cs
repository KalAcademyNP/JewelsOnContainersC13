using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }

        public int Units { get; set; }
        public int ProductId { get; private set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }

        public OrderItem(int productId, string productName, decimal unitPrice, string pictureUrl, int units = 1)
        {
            ProductId = productId;

            ProductName = productName;
            UnitPrice = unitPrice;

            Units = units;
            PictureUrl = pictureUrl;
        }

        public void SetPictureUri(string pictureUri)
        {
            if (!String.IsNullOrWhiteSpace(pictureUri))
            {
                PictureUrl = pictureUri;
            }
        }

        public void AddUnits(int units)
        {
            Units += units;
        }
    }
}
