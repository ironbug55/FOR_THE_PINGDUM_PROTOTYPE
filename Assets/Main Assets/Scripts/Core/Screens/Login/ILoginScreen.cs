using Cysharp.Threading.Tasks;
using FTP.Infrastructre.Screens;
using System;

namespace FTP.Core.Screens.Login
{
    public interface ILoginScreen : IScreen
    {
        public Func<string, string, UniTask> OnEmailAuthentication { get; set; }
        public Func<string, string, UniTask> OnEmailSignUp { get; set; }
    }
}
