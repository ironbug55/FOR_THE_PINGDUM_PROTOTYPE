using Cysharp.Threading.Tasks;
using FTP.Infrastructre.Authentications;
using FTP.Infrastructre.Managers;

namespace FTP.Core.Managers.Authentication
{
    public interface IAuthenticationManager : IManager
    {
        public T GetAuthenticator<T>() where T : IAuthenticator, new();

        public UniTask SignOut();
    }
}