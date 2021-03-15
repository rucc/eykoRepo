using EykoChallenge.Models;
using EykoChallenge.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services
{
	public class DataSourceUnitOfWorkTest
	{
		[SetUp]
		public void CreateDb()
		{
			var ctx = new DataSourceContext();
			ctx.Database.Migrate();
			ctx.Database.ExecuteSqlRaw("delete from DataSources;");
			ctx.Database.ExecuteSqlRaw("delete from DataSourceConfigs;");
		}

		[Test]
		public void TestConfigTypeMapping()
		{
			int sulId = 0;
			using (var unit = new DataSourceUnitOfWork())
			{
				unit.DataSourceRepository.AddSource(new DataSource
				{
					Name = "opendata",
					Config = new HttpApiSourceConfig
					{
						Method = "GET",
						Url = "https://services.arcgis.com/ZOyb2t4B0UYuYNYH/arcgis/rest/services/Restaurant_Open_Data/FeatureServer/0/query",
						QueryParams = new Dictionary<string, string> {
							{ "where", "objectid>1900" },
							{ "outfields", "*" },
							{ "f", "json" },
							{ "outSR", "1" }
						}
					}
				});

				var sul = new DataSource
				{
					Name = "s3-user-list",
					Config = new AwsS3SourceConfig
					{
						AccountName = "fake",
						Bucket = "users",
						ObjectKey = "list.csv"
					}
				};
				unit.DataSourceRepository.AddSource(sul);
				unit.Save();
				sulId = sul.Id;
				Assert.Greater(sulId, 0);
			}

			using (var unit = new DataSourceUnitOfWork())
			{
				var ds = unit.DataSourceRepository.GetSourceByName("opendata");
				Assert.IsNotNull(ds);
				Assert.IsNotNull(ds.Config);
				Assert.IsInstanceOf<HttpApiSourceConfig>(ds.Config);
				Assert.IsNotNull(ds.Id);
				Assert.Throws<InvalidCastException>(() => { var x = (AwsS3SourceConfig)ds.Config; });
				var httpCfg = (HttpApiSourceConfig)ds.Config;
				Assert.IsTrue(httpCfg.QueryParams.ContainsKey("f"));
				Assert.AreEqual("json", httpCfg.QueryParams["f"]);

				ds = unit.DataSourceRepository.GetSourceByName("fake");
				Assert.IsNull(ds);

				var sul = unit.DataSourceRepository.GetSources().SingleOrDefault(d => d.Id == sulId);
				Assert.IsNotNull(sul);
				Assert.IsInstanceOf<AwsS3SourceConfig>(sul.Config);
				Assert.AreEqual("s3-user-list", sul.Name);
			}
		}

		[Test]
		public void TestNameUniqueness()
		{
			using (var unit = new DataSourceUnitOfWork())
			{
				unit.DataSourceRepository.AddSource(new DataSource
				{
					Name = "dont-dupe-me"
				});
				unit.DataSourceRepository.AddSource(new DataSource
				{
					Name = "dont-dupe-me"
				});
				Assert.Throws<DbUpdateException>(() => { unit.Save(); });
			}
		}

		[Test]
		public void TestNameRequired()
		{
			using (var unit = new DataSourceUnitOfWork())
			{
				unit.DataSourceRepository.AddSource(new DataSource());
				Assert.Throws<DbUpdateException>(() => { unit.Save(); });
			}
		}
	}
}
