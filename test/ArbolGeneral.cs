using System;
using System.Collections.Generic;

namespace DeepSpace
{
	public class ArbolGeneral<T>
	{

		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato) {
			this.dato = dato;
		}

		public T getDatoRaiz() {
			return this.dato;
		}

		public List<ArbolGeneral<T>> getHijos() {
			return hijos;
		}

		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Add(hijo);
		}

		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Remove(hijo);
		}

		public bool esHoja() {
			return this.getHijos().Count == 0;
		}

		public int altura() {
			int height = 0;
			if (this.esHoja())
			{
				return height;
			}
			foreach (var h in this.getHijos())
				if (h.altura() > height)
				{
					height = h.altura();

				}
			return 1 + height;
		}


		public int nivel(T dato) {
			Cola<ArbolGeneral<T>> C = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> auxi;
			int nivel = 0;
			C.encolar(this);
			C.encolar(null);
			while (!C.esVacia())
			{
				auxi = C.desencolar();

				if (dato.Equals(auxi) == true)
				{
					return nivel;
				}
				if (auxi == null)
				{
					nivel++;
					if (!C.esVacia())
					{
						C.encolar(null);
					}
				}
				else
				{
					foreach (var hijo in auxi.getHijos())
					{
						C.encolar(hijo);
					}
				}

			}
			return nivel;


		}

		public void Porniveles()
		{

			Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> arbolaux;

			c.encolar(this);

			while (!c.esVacia())
			{
				arbolaux = c.desencolar();

				Console.Write(arbolaux.getDatoRaiz() + "  ");


				foreach (var hijo in arbolaux.getHijos())
					c.encolar(hijo);




			}




		}
		public void PostOrden()
		{
			foreach (var hijo in this.getHijos())
				hijo.PostOrden();

			Console.WriteLine(this.getDatoRaiz() + "  ");



		}


	

		



	}
}