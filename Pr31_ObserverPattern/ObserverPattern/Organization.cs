using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Organization
    {
        public string Name { get; }

		private string _address;

		public string Address
		{
			get { return _address; }
			set 
			{ 
				_address = value; 
			}
		}

		public Organization(string name)
		{
			Name = name;
		}



	}
}
