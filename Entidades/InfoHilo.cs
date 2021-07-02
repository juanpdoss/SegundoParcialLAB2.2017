using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace EntidadesModeloSegundoParcial
{
    public class InfoHilo
    {
        private IRespuesta<int> callback;
        private Thread hilo;
        private int id;
        private static Random randomizer;

        static InfoHilo()
        {
            InfoHilo.randomizer = new Random();
        }

        public InfoHilo(int id,IRespuesta<int> callback)
        {
            this.hilo = new Thread(Ejecutar);

            this.id = id;
            this.callback = callback;

            hilo.Start(); //ojota aca
        }


        private void Ejecutar()
        {
                                                                   
            int tiempoEspera = InfoHilo.randomizer.Next(1, 6); //segundos
            Thread.Sleep(tiempoEspera * 1000);
            this.callback.RespuestaHilo(id);

        }







    }




}
