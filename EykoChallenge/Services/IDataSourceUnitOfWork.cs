using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EykoChallenge.Services
{
	public interface IDataSourceUnitOfWork: IDisposable
	{
		IDataSourceRepository DataSourceRepository { get; }

		int Save();
	}
}
