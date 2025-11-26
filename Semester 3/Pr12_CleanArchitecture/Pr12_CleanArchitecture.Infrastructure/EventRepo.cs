using Microsoft.EntityFrameworkCore;
using Pr12_CleanArchitecture.Domain;
using Pr12_CleanArchitecture.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr12_CleanArchitecture.Infrastructure
{
    public class EventRepo : IEventRepo
    {
        private DataContext _context;

        public EventRepo(DataContext context)
        {
            _context = context;
        }

        public async Task CreateEvent(Event addEvent)
        {
            if (addEvent == null)
            {
                return;
            }
            _context.Events.Add(addEvent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEvent(Event updateEvent)
        {
            _context.Events.Update(updateEvent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventById(int id)
        {
            var eventId = GetEventById(id).Result;

            if (eventId != null)
            {
                _context.Events.Remove(eventId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Event>> GetAllEvents()
        {
            // Sort by CreationDate ascending
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events.FindAsync(id);
        }
    }
}
