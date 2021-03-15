using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EykoChallenge.Models
{
	class AwsS3SourceConfig : DataSourceConfig
	{
		public string Bucket { get; set; }
		public string ObjectKey { get; set; }
		public string AccountName { get; set; }
	}
}
