using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xunit;

namespace ShoppingStore.Models
{
    public class Customer
    {
        private string Id;

        [Required]
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 2)]
        [RegularExpression("^(?=[a - zA - Z])[-w\\.]{0, 23}([a - zA - Z\\d]|(?<![-.])_)$",
            ErrorMessage = "Name should not contain special characters like '.', '-', '.' or '-'")]
        private string Name;


        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "{0} must be at least {2} characters long.", MinimumLength = 2)]
        [RegularExpression("\\A(?:[a - z0 - 9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z",
            ErrorMessage = "Invalid email address format")]

        private string Email;

        private ICollection<Order> Orders;
        private ICollection<CartLine> Lines;

        public Customer(string Id, string Name, string Email)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("message", nameof(Name));
            if (string.IsNullOrWhiteSpace(Id))
                throw new ArgumentException("message", nameof(Id));
            if (string.IsNullOrWhiteSpace(Id))
                throw new ArgumentException("message", nameof(Id));
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
        }


        public string CustomerId
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get { return Id; }
            [MethodImpl(MethodImplOptions.Synchronized)]

            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CustomerId cannot be empty");
                Id = value; 
            }
        }

        public string CustomerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get { return Name; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CustomerName cannot be empty");
                Name = value; 
            }
        }

        public ICollection<Order> CustomerOrders
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get { return Orders; }
        }

        public ICollection<CartLine> CustomerCart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get { return Lines; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set { Lines = value; }
        }
    }
}
