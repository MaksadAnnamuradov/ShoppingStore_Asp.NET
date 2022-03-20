using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShoppingStore.Models
{
    public class Cart
    {
        private List<CartLine> Line;

        public List<CartLine> getCartLine()
        {
            return new List<CartLine>(Line);
        }

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = Line
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();

            if (line == null)
            {
                Line.Add(new CartLine
                {
                    Product = product,
                    ProductQuantity = new Quantity(quantity)
                });
            }
            else
            {
                line.ProductQuantity.setValue(quantity);
            }
        }
        public decimal ComputeTotalValue() =>
        Line.Sum(e => e.Product.Price * e.ProductQuantity.getValue());
        public virtual void RemoveLine(Product product) =>
        Line.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public virtual void Clear() => Line.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public Quantity ProductQuantity { get; set; }
    }

    public class Quantity
    {
        [Range(1, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        private int value = 0;
        public Quantity(int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return value;
        }

        public void setValue(int newQty)
        {
            if (string.IsNullOrEmpty(newQty.ToString()))
                throw new ArgumentException("Quantity cannot be empty");
            this.value =+ newQty;
        }
    }
}