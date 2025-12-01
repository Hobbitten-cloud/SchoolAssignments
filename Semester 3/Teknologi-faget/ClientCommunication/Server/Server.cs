using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace Server {
	internal class Server {
		internal IPAddress? ip;
		internal const int PORT = 1234;
		internal readonly DecryptData DD = new DecryptData(4819, 41, 3881);
		internal Socket? listener;
		static bool running = true;

		static void Main() {
			Server p = new Server();
			p.Run();
		}

		private void Run() {
			//Pre : None
			//Post: Set up a listening socket. 
			//      Accepting clients in a loop, 
			//      For each client: Create and start a thread that runs ServeClient(...)

			Socket? client;			
			listener = GetListener();

			do {
				Console.Write("Waiting for client ... ");
				
				
			    //FILL IN CODE TO FULFILL POST-CONDITION HERE
			
			
			} while (running);
			//it is not obvious how running is set to false... Is to be fixed later!
			
			listener.Close();
		}

		private void ServeClient(Object? c) {
			//Pre : c is a connected socket 
			//Post: As "c" has type Object it must first be casted into a Socket 
			//      variable called "client". 
			//      First message from client are read using "GetMessage()", it is 
			//      stored in a "String" variable called "id". 
			//      Then public key ("DD.N" and "DD.E" separated by the char ':') is  
			//      sent to client. 
			//      Finally - in a loop - encrypted messages are read using "GetMessage()", 
			//      written on console, decrypted using "Decrypt()" and written on console in
			//		ecrypted form in upper case, until message equals "STOP".
			//		Connection is closed and metod ends.
			
				
			    //FILL IN CODE TO FULFILL POST-CONDITION HERE
			
			

			String[] encryptedMessage;
			String decryptedMessage;
			do {
				
				
				
			    //FILL IN CODE TO FULFILL POST-CONDITION HERE
			
			
			
			} while (decryptedMessage != "STOP");

			try {
				client.Shutdown(SocketShutdown.Both);
			} finally {
				client.Close();
			}
		}

		private String Decrypt(String[] parts) {
			//Pre : DD holds values for decrypting (private key). 
			//Post: All strings in parts are decrypted using DD and concatenated into one string
			
			BigInteger bi;
			List<Char> chars = new List<Char>();

			foreach (String s in parts) {
				//decrypt
				bi = BigInteger.Pow(Int32.Parse(s), DD.D) % DD.N;
				char c = Convert.ToChar((int)bi);
				chars.Add(c);
			}
			return new String(chars.ToArray());
		}

		static private String[] GetMessage(Socket client) {
			//Pre : client holds an active connection
			//Post: A message is read from client and changed into upper case. 
			//      Message can be several parts separated by ":" so it is split into array
			
			byte[] data = new byte[client.SendBufferSize];
			int receivedBytes = client.Receive(data);
			String receivedMessage = (Encoding.ASCII.GetString(data, 0, receivedBytes).ToUpper());

			return receivedMessage.Split(":");
		}

		private Socket GetListener() {
			//Pre : None
			//Post: A socket listening on a chosen IP-addres and port is returned
			ip = GetIPAddress();
			listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			Console.WriteLine($"Listening on : {ip} using port: {PORT}");
			listener.Bind(new IPEndPoint(ip, PORT));
			listener.Listen();

			return listener;
		}

		static private IPAddress GetIPAddress() {
			//Pre : None
			//Post: From a menu showing all IPv4 addresses one is selected and returned
			int indx = 1;

			List<IPAddress> myIP4s = LoadIPv4();
			foreach (IPAddress ip in myIP4s) {
				ChColor(ConsoleColor.DarkYellow, ConsoleColor.Black);
				Console.Write($" {indx}: ");
				ChColor(ConsoleColor.Black, ConsoleColor.White);
				Console.WriteLine($" {ip} ");
				indx++;
			}
			Console.Write("\n\n Input number : ");

			if (Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out int choice)) {
				Console.Clear();
				return myIP4s[choice - 1];
			} else {
				throw new FormatException();
			}
		}

		static private List<IPAddress> LoadIPv4() {
			//Pre : None
			//Post: All IPv4 (= AddressFamily.InterNetwork) addresses
			//      on host is returned in a List
			string hostName = Dns.GetHostName();
			IPAddress[] myIPs = Dns.GetHostEntry(hostName).AddressList;

			List<IPAddress> myIP4s = new List<IPAddress>();
			foreach (IPAddress ip in myIPs) {
				if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
					myIP4s.Add(ip);
				}
			}
			return myIP4s;
		}

		static private void ChColor(ConsoleColor bg, ConsoleColor fg) {
			//Pre : None
			//Post: Changed colors to bg and fg
			Console.BackgroundColor = bg;
			Console.ForegroundColor = fg;
		}
	}
}

