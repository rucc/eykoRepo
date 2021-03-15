using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EykoChallenge.Models
{
	public class HttpApiSourceConfig : DataSourceConfig
	{
		public string Url { get; set; }
		public string Method { get; set; } = "GET";
		public string HeadersJson { get; set; }
		[NotMapped]
		public Dictionary<string, string> Headers
		{
			get
			{
				return string.IsNullOrEmpty(HeadersJson) ?
					new Dictionary<string, string>()
					:
					JsonConvert.DeserializeObject<Dictionary<string, string>>(HeadersJson);
			}
			set
			{
				HeadersJson = JsonConvert.SerializeObject(value);
			}
		}

		public string QueryParamsJson { get; set; }
		[NotMapped]
		public Dictionary<string, string> QueryParams
		{
			get
			{
				return string.IsNullOrEmpty(QueryParamsJson) ?
					new Dictionary<string, string>()
					:
					JsonConvert.DeserializeObject<Dictionary<string, string>>(QueryParamsJson);
			}
			set
			{
				QueryParamsJson = JsonConvert.SerializeObject(value);
			}
		}

	}
}
