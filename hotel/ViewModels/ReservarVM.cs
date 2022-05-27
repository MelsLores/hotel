using hotel.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.ViewModels
{
    public class ReservarVM
    {
        public List<TipoHabitacion> TipoHabitaciones { get; set; }
        public List<Reservacione> Reservacions { get; set; }

        public List<ReservacionHabitacion> reservacionHabitacions { get; set; }

        public List<Habitacione> habitacions { get; set; }
        public List<MetodoPago> metodo { get; set; }


    }
}
