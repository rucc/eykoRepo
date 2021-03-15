using EykoChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EykoChallenge.Services
{
	public class DataSourceContext : DbContext
	{
		public DbSet<DataSource> DataSources { get; set; }
		public DbSet<DataSourceConfig> DataSourceConfigs { get; set; }

		public static string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().CodeBase;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={Path.Combine(AssemblyDirectory, "eyko.db")}");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<DataSource>()
				.HasIndex(ds => ds.Name)
				.IsUnique();


			modelBuilder.Entity<DataSourceConfig>().ToTable("DataSourceConfigs");
			modelBuilder.Entity<HttpApiSourceConfig>();
			modelBuilder.Entity<AwsS3SourceConfig>();
			modelBuilder.Entity<AdoNetSourceConfig>();
		}
	}
}
