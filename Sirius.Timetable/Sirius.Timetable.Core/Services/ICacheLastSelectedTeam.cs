namespace Sirius.Timetable.Core.Services
{
    public interface ICacheLastSelectedTeam
    {
        string Get();
        void Cache(string team);
    }
}