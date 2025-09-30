using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManSys.Data.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MemberStatus
    {
        Suspended,
        Active
    }
    internal class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly MembershipDate { get; set; }
        public MemberStatus Status { get; set; } = MemberStatus.Active;

    }
}
