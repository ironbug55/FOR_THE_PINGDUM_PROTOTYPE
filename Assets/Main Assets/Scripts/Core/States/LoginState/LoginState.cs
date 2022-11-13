using Cysharp.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;
using FTP.Infrastructre.States;
using FTP.Infrastructre.Managers;
using FTP.Core.Managers.State;
using FTP.Core.Managers.Screen;
using FTP.Core.Screens.Login;
using FTP.Core.Managers.Authentication;
using FTP.Core.Authenticators.Email;

namespace FTP.Core.States
{
    public class LoginState : IState
    {
        
        private RefManager<IScreenManager> _screenManager = new RefManager<IScreenManager>();
        
        private RefManager<IStateManager> _stateManager = new RefManager<IStateManager>();
        
        private RefManager<IAuthenticationManager> _authenticationManager = new RefManager<IAuthenticationManager>();


        private ILoginScreen _loginScreen;

        public UniTask Initialize()
        {
            return UniTask.CompletedTask;
        }

        public async UniTask OnEnter()
        {
            _loginScreen = _screenManager.GetManager.ShowScreen<ILoginScreen>();

            var currentUser = FirebaseAuth.DefaultInstance.CurrentUser;

            if (currentUser != null)
            {
                Debug.Log($"{currentUser.Email} already signed in.");
                await GoToGameplay();
            }

            SetLoginScreenEvents();
        }

        public UniTask OnLeave()
        {
            return UniTask.CompletedTask;
        }

        private async UniTask GoToGameplay()
        {
            await _loginScreen.OnHide();
            await _stateManager.GetManager.ChangeState<GameplayState>();
        }

        private void SetLoginScreenEvents()
        {
            _loginScreen.OnEmailAuthentication += EmailAuthentication;
            _loginScreen.OnEmailSignUp += EmailSignUp;
        }

        private async UniTask EmailAuthentication(string mail, string password)
        {
            var emailAuthenticatior = _authenticationManager.GetManager.GetAuthenticator<EmailAuthenticator>();

            var isEmailAuthenticated = await emailAuthenticatior.EmailAuthenticate(mail, password);

            if (isEmailAuthenticated)
            {
                await GoToGameplay();
            }
        }

        private async UniTask EmailSignUp(string mail, string password)
        {
            var emailAuthenticatior = _authenticationManager.GetManager.GetAuthenticator<EmailAuthenticator>();

            var isEmailSignedUp = await emailAuthenticatior.EmailSignUp(mail, password);

            if (isEmailSignedUp)
            {
                await GoToGameplay();
            }
        }
    }
}
