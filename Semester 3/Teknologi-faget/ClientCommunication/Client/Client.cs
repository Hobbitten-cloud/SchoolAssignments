using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace Client {
	internal class Client {
		internal int N, E;

		static void Main(string[] args) {
			Client p = new Client();
			p.Run();
		}

		private void Run() {
			//Pre : None
			//Post: Connects to server using socket, id is read from keyboard and sent to server,
			//      a message holding servers public key is read and stored in N and E. Messages 
			//      are read from keyboard, ":" (delimiter char) are replaced, message is converted
			//      to upper case, encrypted and sent. When message is "STOP" connection is closed

			Socket serverConnection = GetConnection();
			String id = ReadText(" Enter ID : ");
			serverConnection.Send(Encoding.ASCII.GetBytes(id));
			GetPublicKey(serverConnection);

			String? messg;
			do {
				messg = ReadText("Enter message to be sent to server : ");

				messg = (messg.Replace(":", "-")).ToUpper();
				String encrypted = Encrypt(messg);
				serverConnection.Send(Encoding.ASCII.GetBytes(encrypted));
			} while (messg != "STOP");

			//close gracefully:
			try {
				serverConnection.Shutdown(SocketShutdown.Both);
			} finally {
				serverConnection.Close();
			}
		}

		static private String ReadText(String lead) {
			//Pre : None
			//Post: Returns a string read from keyboard with guaranteed content 
			String? txt;
			do {
				Console.Write(lead);
				txt = Console.ReadLine();
				if (String.IsNullOrEmpty(txt)) {
					Console.WriteLine("Please enter some text!");
				}
			} while (txt == null); //must have content
			return txt;
		}

		private String Encrypt(String messg) {
			//Pre : N and E holds values for encryption (public key from server), messg must have content
			//Post: messg is encoded as bytes, each byte is encrypted and concatenated separated by ":"
			String encrypted = "";
			
			byte[] asciiBytes = Encoding.ASCII.GetBytes(messg);
			foreach (byte asciiByte in asciiBytes) {
				BigInteger bi = new BigInteger(asciiByte);
				encrypted += ((BigInteger.Pow(bi, E) % N).ToString() + ":");
			}
			encrypted = encrypted.Remove(encrypted.Length - 1); //remove last ":" 

			return encrypted;
		}

		private void GetPublicKey(Socket serverConn) {
			//Pre : serverConn holds an active connection
			//Post: Next message (several parts separated by ":") from serverConn is read.
			//      N and E is set to the first two elements from message
			String[] parts = GetMessage(serverConn);
			N = int.Parse(parts[0]);
			E = int.Parse(parts[1]);
		}

		static private String[] GetMessage(Socket serverConn) {
			//Pre : serverConn holds an active connection
			//Post: A message is read from serverConn and changed into upper case. 
			//      Message can be several parts separated by ":" so it is split into array
			byte[] data = new byte[serverConn.SendBufferSize];

			int receivedBytes = serverConn.Receive(data);
			String receivedMessage = Encoding.ASCII.GetString(data, 0, receivedBytes).ToUpper();
			return receivedMessage.Split(":");
		}

		static private Socket GetConnection() {
			//Pre : None
			//Post: If a server listens on ip:port, a socket connected to it is returned
			String? ip;
			String? port;
			IPAddress address;
			Socket result = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			bool done = false;
			do {
				ip = ReadText(" Enter IPv4 for server: ");
				port = ReadText(" Enter port for server: ");

				try {
					address = IPAddress.Parse(ip);
					IPEndPoint server = new IPEndPoint(address, Int32.Parse(port));
					result.Connect(server);
					done = true;
				} catch (Exception) {
					Console.WriteLine($"\nCould not connect to {ip}");
				}
			} while (!done);
			return result;
		}
	}
}

