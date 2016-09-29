using SQLiteNetExtensions.Attributes;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace OnToyOnTube.Models
{
    public class Configuracion
    {
        [PrimaryKey, AutoIncrement]
        public int IdConfiguracion { get; set; }        // Identificador de la configuración
        public DateTime FechaRegistro { get; set; }     // Fecha y hora del regisro
        public DateTime FechaModificacion { get; set; }     // Fecha y hora del regisro
        public String CheckInorCheckout { get; set; }      // La aplicación se encuentra en modo Prendido (CheckIn) o apagado (CheckOut)
        public override string ToString() { return string.Format("{0}.-{1} {2} {3}", IdConfiguracion, FechaRegistro, FechaModificacion, CheckInorCheckout); }
    }
}
