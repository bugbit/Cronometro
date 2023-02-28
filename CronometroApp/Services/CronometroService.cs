using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CronometroApp.Services
{
    public class CronometroService : ICronometroService
    {
        private DispatcherTimer timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        private bool isPaused = false;
        private bool disposedValue;

        private CronometroService()
        {
            timer.Tick += CronometroService_DoUpdate;
        }

        public event EventHandler? DoUpdate;
        public TimeSpan Value { get; private set; }

        public static ICronometroService Create() => new CronometroService();

        public void Pause()
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                isPaused = true;
            }
        }

        public void Start()
        {
            if (!isPaused)
            {
                Value = new TimeSpan();
                DoUpdate?.Invoke(this, EventArgs.Empty);
            }
            else
                isPaused = false;

            timer.Start();
        }

        public void Stop()
        {
            if (timer.IsEnabled)
                timer.Stop();
        }

        private void CronometroService_DoUpdate(object? sender, EventArgs e)
        {
            Value += timer.Interval;
            DoUpdate?.Invoke(this, e);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                    timer.Stop();
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~CronometroService()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
