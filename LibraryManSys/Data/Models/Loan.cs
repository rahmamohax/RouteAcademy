using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManSys.Data.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LoanStatus
    {
        Borrowed, Returned, Overdue
    }
    internal class Loan
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        public LoanStatus Status { get; set; }
        public Fine? Fine { get; set; }

    }
}
