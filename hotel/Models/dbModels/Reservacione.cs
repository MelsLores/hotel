using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hotel.Models.dbModels
{
    [Table("reservaciones")]
    public partial class Reservacione
    {
        public Reservacione()
        {
            ReservacionHabitacions = new HashSet<ReservacionHabitacion>();
        }

        [Key]
        [Column("idReservacion")]
        public int IdReservacion { get; set; }
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Column("fechaLlegada", TypeName = "datetime")]
        public DateTime FechaLlegada { get; set; }
        [Column("fechaSalida", TypeName = "datetime")]
        public DateTime FechaSalida { get; set; }
        [Column("detalles")]
        [StringLength(256)]
        public string Detalles { get; set; }
        [Column("metodoPago")]
        public int MetodoPago { get; set; }
        [Column("cantidadPersonas")]
        public int CantidadPersonas { get; set; }
        [Column("costoTotal")]
        public double CostoTotal { get; set; }

        [ForeignKey(nameof(MetodoPago))]
        [InverseProperty("Reservaciones")]
        public virtual MetodoPago MetodoPagoNavigation { get; set; }
        [InverseProperty(nameof(ReservacionHabitacion.IdReservacionNavigation))]
        public virtual ICollection<ReservacionHabitacion> ReservacionHabitacions { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(ApplicationUser.Reservaciones))]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; }
    }
}
