using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hotel.Models.dbModels
{
    [Table("reseñas")]
    public partial class Reseña
    {
        [Key]
        public int IdReseña { get; set; }
        public int IdUsuario { get; set; }
        [Column("reseña")]
        [StringLength(256)]
        public string Reseña1 { get; set; }
        [Column("fecha", TypeName = "datetime")]
        public DateTime Fecha { get; set; }
        [Column("tipoHabitacion")]
        public int TipoHabitacion { get; set; }
        [Column("puntuacion")]
        public int Puntuacion { get; set; }

        [ForeignKey(nameof(TipoHabitacion))]
        [InverseProperty("Reseñas")]
        public virtual TipoHabitacion TipoHabitacionNavigation { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(ApplicationUser.Reseñas))]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; }
    }
}
