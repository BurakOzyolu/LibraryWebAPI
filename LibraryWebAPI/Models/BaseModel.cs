using System;

namespace LibraryWebAPI.Models
{
    public abstract class BaseModel
    {
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UptatedAt { get; set; }
        public int UptatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
