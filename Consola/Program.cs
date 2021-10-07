using System;
using Dominio;
using Persistencia;
using System.Collections.Generic;

namespace Consola
{
    class Program
    {
        //INSTANCIAR UN OBJETO DE TIPO IREPOSITORIOmUNICIPIO
        private static IRepositorioMunicipio _repomunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            /*bool funciono = crearMunicipio();
            if (funciono)
            {
                Console.WriteLine("Municipio adicionado con exito");
            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso...");
            }*/
            
           /* bool f= eliminarMunicipio();

             if (f)
            {
                Console.WriteLine("Municipio eliminado con exito");
            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso...");
            }*/


           /* bool f= actualizarMunicipio();
            if (f)
            {
                Console.WriteLine("Municipio se actualizo con exito");
            }
            else
            {
                Console.WriteLine("Se ha presentado una falla en el proceso...");
            }

            Console.WriteLine("Lista Actualizada");

            listarMunicipios();*/
            buscarMunicipio();

        }
        //METODO PARA HACER PRUEBAS CON LA BASE DE DATOS DE MANERA MANUAL
        private static bool crearMunicipio()
        {
            var municipio= new Municipio
            {
                Nombre="Cartagena"
            };
            bool funciono= _repomunicipio.CrearMunicipio(municipio);
            return funciono;
        }
        private static void listarMunicipios()
        {
            IEnumerable<Municipio> municipios=_repomunicipio.ListarMunicipios();
            foreach (var mun in municipios)
            {
                Console.WriteLine(mun.Id + " " + mun.Nombre);
            }
        }

        private static bool eliminarMunicipio()
        {
            bool funciono = _repomunicipio.EliminarMunicipio(2);
            return funciono;
        }

        private static bool actualizarMunicipio()

        {
            var municipio= new Municipio
            {
                Id=1,
                Nombre ="medellin"
            };
            bool funciono = _repomunicipio.ActualizarMunicipio(municipio);
            return funciono;
        }


        private static void buscarMunicipio()
        {
            var mun= _repomunicipio.BuscarMunicipio(2);

            if(mun!=null)

            {
                Console.WriteLine(mun.Id);
                Console.WriteLine(mun.Nombre);
            }
            else
            {
                Console.WriteLine("municipio no encontrado");
            }

        }

    }
}


