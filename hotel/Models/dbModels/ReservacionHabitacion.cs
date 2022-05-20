using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hotel.Models.dbModels
{
    [Table("reservacion_habitacion")]
    public partial class ReservacionHabitacion
    {
        [Key]
        [Column("idReservacion")]
        public int IdReservacion { get; set; }
        [Key]
        [Column("idHabitacion")]
        public int IdHabitacion { get; set; }

        [ForeignKey(nameof(IdHabitacion))]
        [InverseProperty(nameof(Habitacione.ReservacionHabitacions))]
        public virtual Habitacione IdHabitacionNavigation { get; set; }
        [ForeignKey(nameof(IdReservacion))]
        [InverseProperty(nameof(Reservacione.ReservacionHabitacions))]
        public virtual Reservacione IdReservacionNavigation { get; set; }
    }
}
