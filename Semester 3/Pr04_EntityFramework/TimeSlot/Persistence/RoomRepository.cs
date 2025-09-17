using Microsoft.EntityFrameworkCore;
using TimeSlot.Data;
using TimeSlot.Models;

namespace TimeSlot.Persistence
{
    public class RoomRepository : IRoomRepository
    {
        private List<Room> rooms { get; set; }
        private readonly TimeSlotContext _timeSlot;

        public RoomRepository(TimeSlotContext timeSlot)
        {
            _timeSlot = timeSlot;
        }

        public void Add(Room room)
        {
            if (room == null) return;

            room.RoomId = rooms.Any() ? rooms.Max(x => x.RoomId) + 1 : 1;

            rooms.Add(room);
        }

        public void Delete(int id)
        {
            rooms.RemoveAll(x => x.RoomId == id);
        }

        public List<Room> GetAll()
        {
            return _timeSlot.Rooms.ToList();
        }

        public Room? GetById(int id)
        {
            return rooms.FirstOrDefault(x => x.RoomId == id);
        }

        public void Update(Room room)
        {
            var roomToUpdate = GetById(room.RoomId);
            if (roomToUpdate != null)
            {
                roomToUpdate.Name = room.Name;
                roomToUpdate.Capacity = room.Capacity;
            }
        }
    }
}
