using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SegundoParcial2023.Entidades
{
    public abstract class Vehiculo
    {
        
        public DateTime ingreso;
        private string patente;

        public string Patente
        {
            get { return patente; }
            set { patente = ValidarPatente(value) ? value : ""; }

        }

        // Métodos
        public abstract string ConsultarDatos();

        public override bool Equals(object obj)
        {
            if (obj is Vehiculo otroVehiculo)
            {
                return Patente == otroVehiculo.Patente && GetType() == otroVehiculo.GetType();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Patente.GetHashCode() ^ GetType().GetHashCode();
        }

        public virtual string ImprimirTicket() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ToString());
            sb.AppendLine($"ingreso: {ingreso.ToString()}");
            return sb.ToString() ;
        }

        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (ReferenceEquals(v1, null))
            {
                return ReferenceEquals(v2, null);
            }
            return v1.Equals(v2);
        }

        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        public override string ToString()
        {
            return $"Patente {Patente}";
        }

        private bool ValidarPatente(string patente)
        {
            // Definir dos expresiones regulares para las dos posibles configuraciones de patentes
            Regex patron6Caracteres = new Regex(@"^[A-Z]{3}\d{3}$");
            Regex patron7Caracteres = new Regex(@"^[A-Z]{2}\d{3}[A-Z]{2}$");

            // Validar patente
            if (patente.Length == 6)
            {
                return patron6Caracteres.IsMatch(patente);
            }
            else if (patente.Length == 7)
            {
                return patron7Caracteres.IsMatch(patente);
            }

            return false;
        }

        // Ctor
        protected Vehiculo(string patente)
        {
            this.ingreso = DateTime.Now.AddHours(-3);
            this.Patente = patente;
        }
    }

}
