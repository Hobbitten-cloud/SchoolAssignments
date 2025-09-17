using TimeSlot.Models;

namespace TimeSlot.Persistence
{
    public interface IRoomRepository
    {
        void Add(Room room);
        void Delete(int id);
        List<Room> GetAll();
        Room? GetById(int id);
        void Update(Room room);
    }
}
