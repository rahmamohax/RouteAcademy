using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManSys.Data.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FineStatus
        {Pending, Paid }
    internal class Fine
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateOnly IssuedDate { get; set; }
        public DateOnly PaidDate { get; set; }
        public FineStatus Status { get; set; }

        public int LoanId { get; set; }
        public Loan Loan { get; set; } = null!;

    }
}
