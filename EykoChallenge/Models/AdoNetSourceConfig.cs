using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EykoChallenge.Models
{
	public class AdoNetSourceConfig : DataSourceConfig
	{
		public string ConnectionString { get; set; }
		public string TableName { get; set; }
	}
}
