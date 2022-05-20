using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hotel.Models.dbModels
{
    [Table("metodoPago")]
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            Reservaciones = new HashSet<Reservacione>();
        }

        [Key]
        [Column("idMetodoPago")]
        public int IdMetodoPago { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty(nameof(Reservacione.MetodoPagoNavigation))]
        public virtual ICollection<Reservacione> Reservaciones { get; set; }
    }
}
