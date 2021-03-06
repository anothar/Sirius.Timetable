﻿using System;
using System.IO;
using Sirius.Timetable.Core.Services;

namespace Sirius.Timetable.Droid.Services
{
	public class SelectedTeamCacher : ISelectedTeamCacher
	{
		private readonly string _cacheLocation = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

		public string Get()
		{
			var fileName = Path.Combine(_cacheLocation, "savedTeam");
			return File.Exists(fileName) ? File.ReadAllText(fileName) : null;
		}

		public void Cache(string team)
		{
			var fileName = Path.Combine(_cacheLocation, "savedTeam");
			File.WriteAllText(fileName, team);
		}
	}
}