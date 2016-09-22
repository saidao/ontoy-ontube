using SQLiteNetExtensions.Attributes;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace OnToyOnTube.Models
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int IdPersona { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Indexed, MaxLength(100)]
        public string Nombres { get; set; }
        [Indexed, MaxLength(100)]
        public string ApellidoPaterno { get; set; }
        [Indexed, MaxLength(100)]
        public string ApellidoMaterno { get; set; }
        [Indexed]
        public string NombreCompleto { get { return string.Format("{0} {1} {2}", this.Nombres, this.ApellidoPaterno, this.ApellidoMaterno); } }
        [Indexed, MaxLength(250)]
        public string CorreoElectronico { get; set; }
        [MaxLength(50)]
        public string NumTelefonico { get; set; }
        [MaxLength(1000)]
        public string DomicilioHogar { get; set; }
        [MaxLength(1000)]
        public string DomicilioOficina { get; set; }
        [OneToMany]
        public List<Ubicacion> Ubicaciones { get; set; }
        public override string ToString() { return string.Format("{0} {1} {2} {3} {4} {5} {6}", this.IdPersona, this.FechaRegistro, this.NombreCompleto, this.CorreoElectronico, this.NumTelefonico, this.DomicilioHogar, this.DomicilioOficina); }
        public override int GetHashCode() { return IdPersona; }

    }
}
