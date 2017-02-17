using Sirius.Timetable.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Timetable.Core
{
    /// <summary>
    /// Класс 
    /// </summary>
    public class TimetableDownloader
    {
        private ICacheTimetable Cacher;
        
        public TimetableDownloader()
        {
            Cacher = ServiceLocator.GetService<ICacheTimetable>();
        }

	    private readonly string jsonUrl = "http://project2.sochisirius.ru/schedule/getforday/";
        private readonly string key = "/ddd3a42ebd1ebce7f821d7d2fb04cac8";

        private string GetFileUrl(DateTime d)
        {
            return jsonUrl + d.ToString("yyyy-MM-dd") + key;
        }

	    public async Task<string> GetJsonText(DateTime date)
	    {
            try
            {
                return await Cacher.Get(date);
            }
            catch(Exception e)
            {
                var client = new HttpClient();
                var response = await client.GetAsync(GetFileUrl(date));
                string result = await response.Content.ReadAsStringAsync();
                Cacher.Cache(result);
                return result;
            }

		}
    }
}