using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronometroApp.Services
{
    public interface ICronometroService : IDisposable
    {
        event EventHandler? DoUpdate;
        TimeSpan Value { get; }
        void Start();
        void Pause();
        void Stop();
    }
}
