using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Xml.Linq;

namespace DotMarket.Models
{
    public class Profile
    {
        private ILazyLoader LazyLoader;
        private IEnumerable<DataPayment>? _dataPayments = new List<DataPayment>();
        private IEnumerable<Order>? _orders = new List<Order>();
        private IEnumerable<Address>? _addresses = new List<Address>();
        private IEnumerable<Comment>? _comments = new List<Comment>();

        private Image? _image;

        public Profile( ) { }
        private  Profile (ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }


        public long Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FiscalCode { get; set; } = string.Empty;

        public DateTime? Birthday { get; set; } 

        public DateTime AtCreated { get; set; }

        public bool IsSubscribed { get; set; } = false;
        // one to one con User
        public string UserId { get; set; } = string.Empty;

        public User User { get; set; }

        // many to many con address
        public IEnumerable<Address> Addresses { get; set; } 

        //one to many
        public IEnumerable<DataPayment> DataPayments
        {
            get
            {
                return LazyLoader.Load(this, ref _dataPayments);
            }

            set
            {
                _dataPayments = value;
            }
        }


        public IEnumerable<Order> Orders
        {
            get
            {
                return LazyLoader.Load(this, ref _orders);
            }

            set
            {
                _orders = value;
            }
        }

        public IEnumerable<Address> Adresses
        {
            get
            {
                return LazyLoader.Load(this, ref _addresses);
            }

            set
            {
                _addresses = value;
            }
        }

        public IEnumerable<Comment> Comments
        {
            get
            {
                return LazyLoader.Load(this, ref _comments);
            }

            set
            {
                _comments = value;
            }
        }


    }
}
