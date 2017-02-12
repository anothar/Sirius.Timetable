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
    public static class TimetableDownloader
    {
	    public static string JsonFileUrl { get; } = "";

	    public static async Task<string> GetJsonText()
	    {
		    var client = new HttpClient();
		    var response = await client.GetAsync(JsonFileUrl);
		    return await response.Content.ReadAsStringAsync();
	    }
    }
}