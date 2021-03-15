using log4net;
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
		readonly ILog m_logger;
		public DataSourceUnitOfWork()
		{
			m_ctx = new DataSourceContext();
			m_dsRepo = new DataSourceRepository(m_ctx);
			m_logger = LogManager.GetLogger(GetType());
			m_logger.Info("uow session start");
		}

		public IDataSourceRepository DataSourceRepository => m_dsRepo;

		public void Dispose()
		{
			m_ctx.Dispose();
		}

		public int Save()
		{
			m_logger.Info("saving changes uow session");
			return m_ctx.SaveChanges();
		}
	}
}
