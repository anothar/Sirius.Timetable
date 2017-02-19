namespace Sirius.Timetable.Core.Services
{
	public interface ISelectedTeamCacher
	{
		string Get();
		void Cache(string team);
	}
}