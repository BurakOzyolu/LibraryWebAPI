﻿using System;

namespace LibraryWebAPI.ViewModels
{
    public class ProcessViewModel
    {
        public int processId { get; set; }
        public string BookName { get; set; }
        public string StudentName { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
