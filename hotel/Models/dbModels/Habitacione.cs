using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hotel.Models.dbModels
{
    [Table("habitaciones")]
    public partial class Habitacione
    {
        public Habitacione()
        {
            ReservacionHabitacions = new HashSet<ReservacionHabitacion>();
        }

        [Key]
        [Column("idHabitacion")]
        public int IdHabitacion { get; set; }
        [Column("tipoHabitacion")]
        public int TipoHabitacion { get; set; }
        [Column("disponibilidad")]
        public bool Disponibilidad { get; set; }

        [ForeignKey(nameof(TipoHabitacion))]
        [InverseProperty("Habitaciones")]
        public virtual TipoHabitacion TipoHabitacionNavigation { get; set; }
        [InverseProperty(nameof(ReservacionHabitacion.IdHabitacionNavigation))]
        public virtual ICollection<ReservacionHabitacion> ReservacionHabitacions { get; set; }
    }
}
