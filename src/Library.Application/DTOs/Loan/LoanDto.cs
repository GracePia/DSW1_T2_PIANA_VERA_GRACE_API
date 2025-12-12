using System;

namespace Library.Application.DTOs
{
    public class LoanDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public DateTime LoanDate { get; set; }
        public string Status { get; set; } = "Active";
    }
}