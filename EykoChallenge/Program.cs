using EykoChallenge.Models;
using EykoChallenge.Services;
using System;
using System.Collections.Generic;

namespace EykoChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			using(var unit = new DataSourceUnitOfWork())
			{
				/*
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

				unit.DataSourceRepository.AddSource(new DataSource
				{
					Name = "s3-user-list",
					Config = new AwsS3SourceConfig
					{
						AccountName = "fake",
						Bucket = "users",
						ObjectKey = "list.csv"
					}
				});
				*/
				var x = unit.DataSourceRepository.GetSourceByName("opendata");
				Console.WriteLine(x.GetType());
				unit.Save();
			}
		}
	}
}
