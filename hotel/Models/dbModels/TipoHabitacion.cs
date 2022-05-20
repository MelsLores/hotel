using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hotel.Models.dbModels
{
    [Table("tipoHabitacion")]
    public partial class TipoHabitacion
    {
        public TipoHabitacion()
        {
            Habitaciones = new HashSet<Habitacione>();
            Reseñas = new HashSet<Reseña>();
        }

        [Key]
        [Column("idTipoHabitacion")]
        public int IdTipoHabitacion { get; set; }
        [Required]
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column("descripcion")]
        [StringLength(256)]
        public string Descripcion { get; set; }
        [Column("costo")]
        public double Costo { get; set; }
        [Column("costoExPersona")]
        public double CostoExPersona { get; set; }
        [Column("rutaImg")]
        [StringLength(256)]
        public string RutaImg { get; set; }

        [InverseProperty(nameof(Habitacione.TipoHabitacionNavigation))]
        public virtual ICollection<Habitacione> Habitaciones { get; set; }
        [InverseProperty(nameof(Reseña.TipoHabitacionNavigation))]
        public virtual ICollection<Reseña> Reseñas { get; set; }
    }
}
