using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.Models.dbModels
{
    public class ApplicationUser : IdentityUser <int>
    {
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Telefono { get; set; }

        [InverseProperty(nameof(Reseña.IdUsuarioNavigation))]
        public ICollection<Reseña> Reseñas { get; set; }

        [InverseProperty(nameof(Reservacione.IdUsuarioNavigation))]
        public ICollection<Reservacione> Reservaciones { get; set; }
    }

}
