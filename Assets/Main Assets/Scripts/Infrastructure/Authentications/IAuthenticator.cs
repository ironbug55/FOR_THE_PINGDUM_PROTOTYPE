using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FTP.Infrastructre.Authentications
{
    public interface IAuthenticator
    {
        public UniTask Initalize();
        public UniTask<bool> Authenticate();
    }
}
