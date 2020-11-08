
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;

namespace DeepSpace
{

	class Estrategia
	{


		public String Consulta1(ArbolGeneral<Planeta> arbol)
		{
			int d = 0;

			Cola<ArbolGeneral<Planeta>> c = new Cola<ArbolGeneral<Planeta>>();
			int Conta = 0;

			c.encolar(arbol);

			while (!c.esVacia())
			{
				arbol = c.desencolar();

				if (arbol.getDatoRaiz().team == 2)
				{
					d = arbol.nivel(arbol.getDatoRaiz());
					break;



				}
				Conta++;

				Console.Write(arbol.getDatoRaiz() + "  ");


				foreach (var hijo in arbol.getHijos())
					c.encolar(hijo);





			}






			// calcular y retornar un texto con distancia entre raiz y nodo del bot
			return "la distancia entre la raiz y del bot es de : " + d;
		}


		public String Consulta2(ArbolGeneral<Planeta> arbol)
		{
			Cola<ArbolGeneral<Planeta>> c = new Cola<ArbolGeneral<Planeta>>();
			int Conta = 0;

			c.encolar(arbol);

			while (!c.esVacia())
			{
				arbol = c.desencolar();

				if (arbol.getDatoRaiz().population > 10)
				{
					Conta++;
				}

				Console.Write(arbol.getDatoRaiz() + "  ");


				foreach (var hijo in arbol.getHijos())
					c.encolar(hijo);




			}



			//calcular cantidad de planetas con población > 10 en cada nivel del arbol (recorrido por niveles,con limitante de población)

			return "La cantidad de planetas con población mayor a 10 son : " + Conta + "  ";
		}


		public String Consulta3(ArbolGeneral<Planeta> arbol)
		{
			// calcular  promedio poblacion por nivel de arbol (recorrido por niveles, sumar en total y cantidad y dividir por cantidad para sacar promedio)

			Cola<ArbolGeneral<Planeta>> c = new Cola<ArbolGeneral<Planeta>>();
			long Conta = 0;
			long canti = 0;

			c.encolar(arbol);

			while (!c.esVacia())
			{
				arbol = c.desencolar();




				foreach (var hijo in arbol.getHijos())
					c.encolar(hijo);
				Conta += arbol.getDatoRaiz().population;
				canti++;




			}
			Double Promedio = Conta / canti;
			return "el promedio de poblacion por nivel del arbol es de : " + Promedio;
		}

		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{



			return null;
		}

	


	}
}
			

		
		


	