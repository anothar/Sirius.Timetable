namespace SiriusTimetable.Core.Services.Abstractions
{
	public interface ICacheService
	{
		void Cache(string data);
		string Get();
	}
}