using System;
using System.Text;

namespace SegundoParcial2023.Entidades
{
    public class PickUp : Vehiculo
    {
        // Campos
        private string modelo;
        private int valorHora;

        // Ctor sin parámetros
        public PickUp() : base("")
        {
            //Valores por defecto patente random.
            modelo = "Sin Modelo";
            valorHora = 70;
        }

        // Ctor con modelo, patente
        public PickUp(string patente, string modelo) : base(patente)
        {
            this.modelo = modelo;
            this.valorHora = 70;
        }

        // Ctor patente, modelo y valorHora.
        public PickUp(string patente, string modelo, int valorHora) : base(patente)
        {
            this.modelo = modelo;
            this.valorHora = valorHora;
        }

        // Método ConsultarDatos
        public override string ConsultarDatos()
        {
            return $"{base.ToString()}, Modelo: {modelo}, Valor Hora: {valorHora}";
        }

        // Equals
        public override bool Equals(object obj)
        {
            if (obj is PickUp otraPickUp)
            {
                return base.Equals(obj) && modelo == otraPickUp.modelo && valorHora == otraPickUp.valorHora;
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
            sb.AppendLine($"Modelo: {modelo}");
            sb.AppendLine($"Valor Hora: {valorHora}");
            sb.AppendLine($"Costo Total: {costoTotal}");
            return sb.ToString();
        }
    }
}
