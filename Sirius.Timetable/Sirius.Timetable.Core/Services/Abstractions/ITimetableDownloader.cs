using System;

namespace SiriusTimetable.Core.Services.Abstractions
{
	public interface ITimetableDownloader
	{
		string GetJsonString(DateTime date);
	}
}