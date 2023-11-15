using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public class Automovil : Vehiculo
    {
        // Campos
        private ConsoleColor color;
        private int valorHora;

        // Ctor sin parámetros
        public Automovil() : base("")
        {
            // Se inicializan valores por defecto
            color = ConsoleColor.Gray;
            valorHora = 50;
        }

        // Ctor con patente y color
        public Automovil(string patente, ConsoleColor color) : base(patente)
        {
            this.color = color;
            this.valorHora = 50;
        }

        // Ctor con patente, color y valorHora
        public Automovil(string patente, ConsoleColor color, int valorHora) : base(patente)
        {
            this.color = color;
            this.valorHora = valorHora;
        }

        // Método ConsultarDatos
        public override string ConsultarDatos()
        {
            return $"{base.ToString()}, Color: {color}, Valor Hora: {valorHora}";
        }

        // Método Equals
        public override bool Equals(object obj)
        {
            if (obj is Automovil otroAutomovil)
            {
                return base.Equals(obj) && color == otroAutomovil.color && valorHora == otroAutomovil.valorHora;
            }
            return false;
        }

        // Método ImprimirTicket
        public override string ImprimirTicket()
        {
            DateTime horaSalida = DateTime.Now;
            if (horaSalida <= base.ingreso)
            {
                throw new ArgumentException("La fecha de salida debe ser posterior a la fecha de ingreso");
            }
            TimeSpan estadia = horaSalida.Subtract(ingreso);
            // Para obtener la duración en horas, minutos y segundos
            int horas = estadia.Hours;
            int minutos = estadia.Minutes;
            int segundos = estadia.Seconds;
            int costoTotal = (horas * valorHora) + ((minutos + segundos / 60) * valorHora);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ImprimirTicket());
            sb.AppendLine($"Salida: {horaSalida.ToString()}");
            sb.AppendLine($"Color: {color}");
            sb.AppendLine($"Valor Hora: {valorHora}");
            sb.AppendLine($"Costo Total: {costoTotal}");
            return sb.ToString();
        }
    }
}
