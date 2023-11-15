using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial2023.Entidades
{
    public class Moto : Vehiculo
    {
        // Campos
        private int cilindrada;
        private short ruedas;
        private int valorHora;

        // Ctor sin parametros
        public Moto() : base("")
        {
            //Valores por defecto.
            cilindrada = 0;
            ruedas = 2;
            valorHora = 30;
        }

        // Ctor con patente y cilindrada
        public Moto(string patente, int cilindrada) : base(patente)
        {
            this.cilindrada = cilindrada;
            this.ruedas = 2;
            this.valorHora = 30;
        }

        // CTor patente cilindrada  ruedas
        public Moto(string patente, int cilindrada, short ruedas) : base(patente)
        {
            this.cilindrada = cilindrada;
            this.ruedas = ruedas;
            this.valorHora = 30;
        }

        // Ctor patente cilindrada ruedas valorHora
        public Moto(string patente, int cilindrada, short ruedas, int valorHora) : base(patente)
        {
            this.cilindrada = cilindrada;
            this.ruedas = ruedas;
            this.valorHora = valorHora;
        }

        // ConsultarDatos
        public override string ConsultarDatos()
        {
            return $"{base.ToString()}, Cilindrada: {cilindrada}, Ruedas: {ruedas}, Valor Hora: {valorHora}";
        }

        // Equals
        public override bool Equals(object obj)
        {
            if (obj is Moto otraMoto)
            {
                return base.Equals(obj) && cilindrada == otraMoto.cilindrada && ruedas == otraMoto.ruedas && valorHora == otraMoto.valorHora;
            }
            return false;
        }

        // Método ImprimirTicket
        public override string ImprimirTicket()
        {
            //DateTime _salida = DateTime.Now;
            // Calcular la duracion
            //double horasEstadia = (_salida - base.ingreso).TotalHours;
            // Calcula costo total por hora
            
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
            sb.AppendLine($"Cilindrada: {cilindrada}");
            sb.AppendLine($"Ruedas: {ruedas}");
            sb.AppendLine($"Valor Hora: {valorHora}");
            sb.AppendLine($"Costo Total: {costoTotal}");
            return sb.ToString();
        }
    }
}
