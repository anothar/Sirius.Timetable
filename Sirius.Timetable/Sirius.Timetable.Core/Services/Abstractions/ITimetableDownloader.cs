using System;
using System.Threading.Tasks;

namespace SiriusTimetable.Core.Services.Abstractions
{
	public interface ITimetableDownloader
	{
		Task<string> GetJsonText(DateTime date);
	}
}