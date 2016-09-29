using SQLiteNetExtensions.Attributes;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
namespace OnToyOnTube.Models
{
    public class Ubicacion
    {
        [PrimaryKey, AutoIncrement]
        public int IdUbicacion { get; set; }        // Identificador de la ubicación
        public DateTime FechaRegistro { get; set; } // Fecha y hora del regisro
        public DateTime FechaModificacion { get; set; } // Fecha y hora de la modificación
        [ForeignKey(typeof(Persona))]                   // Clave de la persona relación
        public int IdPersona { get; set; }          // Clave de la persona
        [Indexed, MaxLength(20)]
        public string Tipo { get; set; }            // Tipo de registro: Chek In, Chech Out, Automatic
        [Indexed, MaxLength(20)]
        public string Dispositivo { get; set; }     // Dispositivo de registro
        [Indexed, MaxLength(20)]
        public string Descripcion { get; set; }     // Dispositivo de registro

        [Indexed, MaxLength(20)]
        public Double Latitud { get; set; }
        [Indexed, MaxLength(20)]
        public Double Longitud { get; set; }
        [Indexed, MaxLength(20)]
        public Double Altitud { get; set; }
        [Indexed, MaxLength(20)]
        public Double PrecisionAltitud { get; set; }
        [Indexed, MaxLength(20)]
        public Double Exactitud { get; set; }
        [Indexed, MaxLength(20)]
        public Double Titulo { get; set; }
        [Indexed, MaxLength(20)]
        public Double Velocidad { get; set; }

        [ManyToOne]
        public List<Persona> Persona { get; set; }

        public override string ToString() { return string.Format("{0}.-{1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13}", IdUbicacion,FechaRegistro,FechaModificacion,IdPersona,Tipo, Dispositivo,Descripcion,Latitud,Longitud,Altitud,PrecisionAltitud,Exactitud,Titulo,Velocidad); }

    }
}
