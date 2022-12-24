using System;

namespace LibraryWebAPI.ViewModels
{
    public class ProcessEndViewModel
    {
        public int processId { get; set; }
        public string BookName { get; set; }
        public string StudentName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
