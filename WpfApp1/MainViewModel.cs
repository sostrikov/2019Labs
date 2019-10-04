using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
	class MainViewModel
	{
		public IEnumerable<int> Numbers
		{
			get { return Enumerable.Range(1, 100); }
		}
	}
}
