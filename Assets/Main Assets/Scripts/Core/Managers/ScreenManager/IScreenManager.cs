using FTP.Infrastructre.Managers;
using FTP.Infrastructre.Screens;

namespace FTP.Core.Managers.Screen
{
    public interface IScreenManager : IManager
    {
        public T ShowScreen<T>() where T : IScreen;
    }
}