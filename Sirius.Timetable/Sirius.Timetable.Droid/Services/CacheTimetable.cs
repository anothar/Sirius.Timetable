using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sirius.Timetable.Core;
using Sirius.Timetable.Core.Services;

using System.Threading.Tasks;

namespace Sirius.Timetable.Droid.Services
{
    public class CacheTimetable : ICacheTimetable
    {
        private string cacheLocation;

        public async Task<string> Get(DateTime toGetTimetable)
        {
            string ToGetTimetable = toGetTimetable.ToString("yyyy-MM-dd") + ".json";
            string result = System.IO.File.ReadAllText(cacheLocation + ToGetTimetable);
            return result;
            /*if(DateTime.Today!=lastCached)
            {
                    var result = await new TimetableDownloader.GetJsonText();
                    lastCached = DateTime.Today;
                    return result;
            
            */

        }
        
        public async Task Cache(string Timetable)
        {
            string ToGetTimetable = DateTime.Today.ToString("yyyy-MM-dd") + ".json";
            System.IO.File.WriteAllText(cacheLocation + ToGetTimetable, Timetable);
        }

        public CacheTimetable()
        {
            cacheLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        }
    }
}