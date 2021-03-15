using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EykoChallenge.Services
{
	public class DataSourceUnitOfWork : IDataSourceUnitOfWork
	{
		readonly DataSourceContext m_ctx;
		readonly IDataSourceRepository m_dsRepo;
		public DataSourceUnitOfWork()
		{
			m_ctx = new DataSourceContext();
			m_dsRepo = new DataSourceRepository(m_ctx);
		}

		public IDataSourceRepository DataSourceRepository => m_dsRepo;

		public void Dispose()
		{
			m_ctx.Dispose();
		}

		public int Save()
		{
			return m_ctx.SaveChanges();
		}
	}
}
