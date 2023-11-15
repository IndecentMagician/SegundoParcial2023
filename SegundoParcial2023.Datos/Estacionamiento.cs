using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using SegundoParcial2023.Entidades;


namespace SegundoParcial2023.Datos
{
    public class Estacionamiento
    {
        // Campos
        private int espacioDisponible;
        private string nombre;
        private List<Vehiculo> vehiculos;

        // Propiedades
        public int EspacioDisponible => espacioDisponible;
        public string Nombre => nombre;

        // Constructor
        private Estacionamiento()
        {
            vehiculos = new List<Vehiculo>();
        }

        public Estacionamiento(string nombre, int espacioDisponible) : this()
        {
            this.nombre = nombre;
            this.espacioDisponible = espacioDisponible;
        }

        // Operador explicito
        public static explicit operator string(Estacionamiento e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Estacionamiento: {e.Nombre}");
            sb.AppendLine($"Espacio Disponible: {e.EspacioDisponible}");
            sb.AppendLine("Vehiculos:");
            foreach (var vehiculo in e.vehiculos)
            {
                sb.AppendLine(vehiculo.ConsultarDatos());
            }
            return sb.ToString();
        }

        // Op sobrecargados
        public static bool operator ==(Estacionamiento e, Vehiculo v)
        {
            return e.vehiculos.Contains(v);
        }

        public static bool operator !=(Estacionamiento e, Vehiculo v)
        {
            return !(e == v);
        }

        public static Estacionamiento operator +(Estacionamiento e, Vehiculo v)
        {
            if (!e.vehiculos.Contains(v) && v.Patente != "" && e.EspacioDisponible > e.vehiculos.Count)
            {
                e.vehiculos.Add(v);
                Console.WriteLine($"Vehículo {v.Patente} ingresado al estacionamiento.");
            }
            else
            {
                Console.WriteLine($"No se pudo agregar el vehículo {v.Patente} al estacionamiento.");
            }

            return e;
        }

        public static string operator -(Estacionamiento e, Vehiculo v)
        {
            if (e.vehiculos.Contains(v))
            {
                e.vehiculos.Remove(v);
                return v.ImprimirTicket();
            }
            else
            {
                return "El vehículo no es parte del estacionamiento.";
            }
        }

        // Metodo lista vehículos
        public List<Vehiculo> GetVehiculos()
        {
            return vehiculos;
        }

    }
}
