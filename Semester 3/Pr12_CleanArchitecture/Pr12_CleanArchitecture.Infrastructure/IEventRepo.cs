using Pr12_CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr12_CleanArchitecture.Infrastructure
{
    public interface IEventRepo
    {
        Task CreateEvent(Event addEvent);
        Task UpdateEvent(Event updateEvent);
        Task<Event> GetEventById(int id);
        Task DeleteEventById(int id);
        Task<List<Event>> GetAllEvents();
    }
}
