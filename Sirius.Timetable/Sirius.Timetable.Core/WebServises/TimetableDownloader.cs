using Sirius.Timetable.Core.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sirius.Timetable.Core
{
    /// <summary>
    /// Класс 
    /// </summary>
    public class TimetableDownloader
    {
        private readonly ICacheTimetable _cacher;
        
        public TimetableDownloader()
        {
            _cacher = ServiceLocator.GetService<ICacheTimetable>();
        }

	    private const string JsonUrl = "http://project2.sochisirius.ru/schedule/getforday/";
	    private const string Key = "/ddd3a42ebd1ebce7f821d7d2fb04cac8";

	    private static string GetFileUrl(DateTime d)
        {
            return JsonUrl + d.ToString("yyyy-MM-dd") + Key;
        }

	    public async Task<string> GetJsonText(DateTime date)
	    {
		    var jsonText = _cacher.Get(date);
		    if (!String.IsNullOrEmpty(jsonText))
				return jsonText;
		    try
		    {
			    var client = new HttpClient();
			    var test = GetFileUrl(date);

				var result = await client.GetStringAsync(test);
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