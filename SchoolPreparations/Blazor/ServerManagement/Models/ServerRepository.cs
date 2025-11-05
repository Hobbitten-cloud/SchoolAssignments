namespace ServerManagement.Models
{
    public class ServerRepository
    {
        private List<Server> servers = new List<Server>()
        {
            new Server () { ServerId = 1, Name = "Server 1", City = "New York" },
            new Server () { ServerId = 2, Name = "Server 2", City = "Los Angeles" },
            new Server () { ServerId = 3, Name = "Server 3", City = "Chicago" },
            new Server () { ServerId = 4, Name = "Server 4", City = "Houston" },
            new Server () { ServerId = 5, Name = "Server 5", City = "Phoenix" }
        };
        public List<Server> GetAllServers()
        {
            return servers;
        }


        public void AddServer(Server server)
        {

        }
    }
}
