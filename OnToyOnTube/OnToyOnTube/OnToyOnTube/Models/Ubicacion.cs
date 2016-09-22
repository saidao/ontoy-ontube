using SQLiteNetExtensions.Attributes;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
namespace OnToyOnTube.Models
{
    public class Ubicacion
    {
        [PrimaryKey, AutoIncrement]
        public int IdUbicacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        [ForeignKey(typeof(Persona))]     // Specify the foreign key
        public int IdPersona { get; set; }
        [Indexed, MaxLength(20)]
        public string latitud { get; set; }
        [Indexed, MaxLength(20)]
        public string longitud { get; set; }
        [Indexed, MaxLength(20)]
        public string altitud { get; set; }
        [Indexed, MaxLength(20)]
        public string Tipo { get; set; }

        [ManyToOne]
        public List<Persona> Persona { get; set; }

        public override string ToString() { return string.Format("{0} {1} {2} {3} {4} {5}", this.Persona, this.FechaRegistro, this.latitud, this.longitud, this.altitud); }

    }
}
