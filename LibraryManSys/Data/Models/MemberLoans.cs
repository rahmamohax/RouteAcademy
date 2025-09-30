using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManSys.Data.Models
{
    internal class MemberLoans
    {
        public int LoanId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public Loan Loan { get; set; } = null!;
        public Member Member { get; set; } = null!;
        public Book Book { get; set; } = null!;
        public DateTime DueDate { get; set; }      // e.g., LoanDate + 14 days
        public DateTime? ReturnDate { get; set; }
    }
}
