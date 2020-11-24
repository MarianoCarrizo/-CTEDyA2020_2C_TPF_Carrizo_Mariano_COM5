
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;

namespace DeepSpace
{

	class Estrategia
	{
		int x = 0; //origen
		int y = 1; //destino
		int mov = 0; // cant de movimientos sin vencer al  destino

		public String Consulta1(ArbolGeneral<Planeta> arbol)
		{
			int d = 0;
			List<Planeta> cami = new List<Planeta>();

			CaminoPreOrden(arbol, cami);
			d = cami.Count - 2;





			// calcular y retornar un texto con distancia entre raiz y nodo del bot
			return "la distancia entre la raiz y del bot es de : " +  d;
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
			List<Planeta> cami = new List<Planeta>();

			CaminoPreOrden(arbol, cami);
			int Cant = cami.Count;

			if (Cant > 1)
			{

				Movimiento T = new Movimiento(cami[Cant - 1], cami[Cant - 2]);
				return T;
			}
			
				
			CaminoJugador(arbol, cami);
			List<Planeta> jugador = CaminoJugador(arbol, cami);
			Movimiento kill = new Movimiento(cami[x], jugador[y]);
			if (x < 3  && cami[x].Poblacion() / 2 > jugador[y].Poblacion() || jugador[y].EsPlanetaDeLaIA())
				// si origen es menor a tres y la mitad de la poblacion de origen es menor que la poblacion del destino (osea no lo va vencer) o que el destino sea planeta de la ia
				
			{
				// sube uno de origen y uno de destino, y se resetea el contador mov
				x++;
				y++;
				mov = 0;
			}
			//se incrementa mov en 1 si lo de arriba  si no se cumple
			else { mov++; }
			// si el contador mov llega a 2 (Se hicieron 2 movimientos sin poder capturar el planeta) se resetea el origen y el destino para llamar más naves desde root para capturar
            if (mov == 2)
            {
				x = 0;
				y = 1;
            }
			
			return kill;
		}



		public List<Planeta> CaminoPreOrden(ArbolGeneral<Planeta> arbol, List<Planeta> camino)
		{
			// Primero raiz

			camino.Add(arbol.getDatoRaiz());
			// si encontramos camino
			if (arbol.getDatoRaiz().EsPlanetaDeLaIA())
			{
				
					return camino;

				
			}
			else
			{
				//hijos recursivo...

				foreach (var hijo in arbol.getHijos())
				{
					List<Planeta> caminoAux = CaminoPreOrden(hijo, camino);
					if (caminoAux != null)
					{
						return caminoAux;
					}
					//saco ultimo planeta del camino
					camino.Remove(hijo.getDatoRaiz());
				}
			}
			return null;

		}

		public List<Planeta> CaminoJugador(ArbolGeneral<Planeta> arbol, List<Planeta> camino)
		{
			// Primero raiz
			camino.Add(arbol.getDatoRaiz());

			// si encontramos camino

			if (arbol.getDatoRaiz().EsPlanetaDelJugador())
			{

				return camino;

			}
			else
			{
				foreach (var hijo in arbol.getHijos())
				{
					
					List<Planeta> CaminoKill = CaminoJugador(hijo, camino);
					if (CaminoKill != null)
					{
						return CaminoKill;
					}
					camino.Remove(hijo.getDatoRaiz());


				}

			}
			
			return null;

		}


	}
}
			

		
		


	