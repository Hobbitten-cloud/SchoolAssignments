using TimeSlot.Models;

namespace TimeSlot.Persistence
{
    public static class InMemoryRoomRepository
    {
        private static List<Room> rooms = new List<Room>
        {
            new Room { RoomId = 1, Name = "A1.01", Capacity = 10 },
            new Room { RoomId = 2, Name = "A1.02", Capacity = 5 },
            new Room { RoomId = 3, Name = "A1.03", Capacity = 4 },
            new Room { RoomId = 4, Name = "A1.04", Capacity = 6 }
        };
        public static Room? GetById(int id)
        {
            return rooms.FirstOrDefault(x => x.RoomId == id);
        }

        public static List<Room> GetAll()
        {
            return rooms;
        }

        public static void Add(Room room)
        {
            if (room == null) return;

            room.RoomId = rooms.Any() ? rooms.Max(x => x.RoomId) + 1 : 1;

            rooms.Add(room);
        }

        public static void Update(Room room)
        {
            var roomToUpdate = GetById(room.RoomId);
            if (roomToUpdate != null)
            {
                roomToUpdate.Name = room.Name;
                roomToUpdate.Capacity = room.Capacity;
            }
        }
        public static void Delete(int id)
        {
            rooms.RemoveAll(x => x.RoomId == id);
        }
    }
}
