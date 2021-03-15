using EykoChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EykoChallenge.Services
{
	class DataSourceRepository : IDataSourceRepository
	{
		readonly DataSourceContext m_ctx;

		public DataSourceRepository(DataSourceContext ctx)
		{
			m_ctx = ctx;
		}

		public void AddSource(DataSource ds)
		{
			m_ctx.DataSources.Add(ds);
		}

		public DataSource GetSourceByName(string name)
		{
			return m_ctx.DataSources.Include(ds => ds.Config).FirstOrDefault(ds => ds.Name == name);
		}

		public IEnumerable<DataSource> GetSources()
		{
			return m_ctx.DataSources.Include(ds => ds.Config).ToList();
		}

		public void RemoveSource(DataSource ds)
		{
			m_ctx.DataSources.Remove(ds);
		}
	}
}
