using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace EntidadesModeloSegundoParcial
{

    public delegate void AvisoFinCallback(string mensaje);

    public class LosHilos:IRespuesta<int>
    {
        private int id;
        private List<InfoHilo> misHilos;
        public event AvisoFinCallback AvisoFin;


        public LosHilos()
        {
            this.id = 0;
            this.misHilos = new List<InfoHilo>();
        }

        public string Bitacora
        {
            get
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ruta += "\\bitacora.txt";


                if(File.Exists(ruta))
                {
                    using (StreamReader lector = new StreamReader(ruta))
                    {
                        return lector.ReadToEnd();

                    }

                }

                return  "";


            }
            set
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                ruta += "\\bitacora.txt";

                using (StreamWriter escritor = new StreamWriter(ruta, true))
                {
                    escritor.WriteLine(value);

                }

            }
        }


        private static LosHilos AgregarHilo(LosHilos hilos)
        {
            hilos.id++;

            InfoHilo nuevoHilo = new InfoHilo(hilos.id, hilos);
            hilos.misHilos.Add(nuevoHilo);

            return hilos;
        }

        /// <summary>
        /// i.Creará un mensaje con el siguiente formato: "Terminó el hilo {0}.".
        /// ii.Guardará el mensaje en la bitácora.
        /// iii.Ejecutará el evento AvisoFin.
        /// </summary>
        /// <param name="id"></param>
        public void RespuestaHilo(int id)
        {
            string mensaje = $"Termino el hilo {id}";
            this.Bitacora = mensaje;

            if(!(this.AvisoFin.Method is null))
            {
                this.AvisoFin.Invoke(mensaje); //sin METODOs manejadores esto exploTa
            }

             
        }


        public static LosHilos operator +(LosHilos hilos,int cantidad)
        {
            if(!(hilos is null))
            {
                if (cantidad < 1)
                {
                    throw new CantidadInvalidaException();
                }
                else
                {
                    for (int i = 0; i < cantidad; i++)
                    {
                        LosHilos.AgregarHilo(hilos);

                    }
                }

            }


           
            return hilos;
        }



    }
}
