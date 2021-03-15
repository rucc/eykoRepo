using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EykoChallenge.Models
{
	public class DataSource
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

        public DataSourceConfig Config { get; set; }
	}
}
