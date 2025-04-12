using System;

namespace YourNamespace.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; } // Unikalny identyfikator
        public bool Deleted { get; set; } // Aktywność
        public DateTime CreatedAt { get; set; } // Data utworzenia
        public Guid CreatedBy { get; set; } // Autor
        public DateTime? UpdatedAt { get; set; } // Data aktualizacji
        public Guid? UpdatedBy { get; set; } // Edytor
    }
}
