using EykoChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EykoChallenge.Services
{
	public interface IDataSourceRepository
	{
		public DataSource GetSourceByName(string name);
		public IEnumerable<DataSource> GetSources();
		public void AddSource(DataSource ds);
		public void RemoveSource(DataSource ds);
	}
}
