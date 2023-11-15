﻿using SegundoParcial2023.Entidades;
using SegundoParcial2023.Datos;

namespace SegundoParcial2023.Consola
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Estacionamiento e = new Estacionamiento("Instituto43", 6);

            // Creación de Vehículos
            Console.WriteLine("MOTOS");
            Vehiculo m1 = new Moto("ASD123", 75, 4);
            Console.WriteLine(m1.ConsultarDatos());
            Moto m2 = new Moto("ASDaa123", 175);
            Console.WriteLine(m2.ConsultarDatos());
            Moto m3 = new Moto("QWE312", 175, 4, 35);
            Console.WriteLine(m3.ConsultarDatos());

            Console.WriteLine("PICKUPS");
            PickUp p1 = new PickUp("TYR753", "78", 51);
            Console.WriteLine(p1.ConsultarDatos());
            PickUp p2 = new PickUp("TYR753", "Model A");
            Console.WriteLine(p2.ConsultarDatos());

            Console.WriteLine("AUTOMOVILES");
            Automovil a1 = new Automovil("POI952", ConsoleColor.Red);
            Console.WriteLine(a1.ConsultarDatos());
            Automovil a2 = new Automovil("MNB651", ConsoleColor.DarkCyan, 23);
            Console.WriteLine(a2.ConsultarDatos());

            Console.WriteLine("--------------------------------");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Estacionamiento Ingreso");
            e += m1;
            e += p1;
            e += a1;
            e += m1;
            e += p1;
            e += a1;
            e += m2;
            e += p2;
            e += a2;
            e += m3;

            Console.WriteLine((string)e);

            Console.WriteLine("--------------------------------");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Estacionamiento Egreso");
            Console.WriteLine(e - m1);
            Console.WriteLine(e - p1);
            //Console.WriteLine(e - a1);
            //Console.WriteLine(e - m2);
            Console.WriteLine(e - p2);
            Console.WriteLine(e - a2);
            Console.WriteLine(e - m3);

            Console.WriteLine("--------------------------------");
            Console.WriteLine((string)e);

            Console.ReadKey();
        }
	}
}