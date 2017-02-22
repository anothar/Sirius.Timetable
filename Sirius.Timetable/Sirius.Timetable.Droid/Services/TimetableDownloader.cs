using System;
using System.Net;
using System.Threading.Tasks;
using Sirius.Timetable.Core.Services;

namespace Sirius.Timetable.Droid.Services
{
	/// <summary>
	///     Класс
	/// </summary>
	public class TimetableDownloader : ITimetableDownloader
	{
		private const string JsonUrl = "http://project2.sochisirius.ru/schedule/getforday/";
		private const string Key = "/ddd3a42ebd1ebce7f821d7d2fb04cac8";
		private readonly ITimetableCacher _cacher;
		public TimetableDownloader()
		{
			_cacher = ServiceLocator.GetService<ITimetableCacher>();
		}

		private static string GetFileUrl(DateTime d)
		{
			return JsonUrl + d.ToString("yyyy-MM-dd") + Key;
		}

		public async Task<string>  GetJsonText(DateTime date)
		{
			var jsonText = _cacher.Get(date);
			if (!String.IsNullOrEmpty(jsonText))
				return jsonText;
			try
			{
				var str = GetFileUrl(date);
				var result = await new WebClient().DownloadStringTaskAsync(new Uri(str));
				_cacher.Cache(result, date);
				return result;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}