using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server {
	public readonly struct DecryptData {
		public DecryptData(int n, int e, int d) {
			N = n;
			E = e;
			D = d;
		}
		public int N { get; init; }
		public int E { get; init; }
		public int D { get; init; }
	}
}
