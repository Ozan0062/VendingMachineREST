using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace VendingMachineREST.Models
{
    public class Accounting
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public double Amount { get; set; }
        public string? Type { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;

        public Accounting()
        {
        }

        public void ValidateAmount()
        {
            if (Amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be positive");
            }
        }

        public void ValidateType()
        {
            if (Type == null)
            {
                throw new ArgumentNullException("Type is required");
            }
            if (Type.Length < 2)
            {
                throw new ArgumentException("Type must be at least 2 characters");
            }
        }

        public void ValidateDate()
        {
            if (Date == null)
            {
                throw new ArgumentNullException("Date is required");
            }
            if (Date > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Date cannot be in the future");
            }
        }

        public void ValidateUserId()
        {
            if (UserId == null)
            {
                throw new ArgumentNullException("User ID is required");
            }
        }   

        public void Validate()
        {
            ValidateAmount();
            ValidateType();
            ValidateDate();
            ValidateUserId();
        }

    }
}
