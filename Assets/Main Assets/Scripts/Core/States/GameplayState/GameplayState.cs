using Cysharp.Threading.Tasks;
using FTP.Core.Managers.Authentication;
using FTP.Core.Managers.Screen;
using FTP.Core.Managers.State;
using FTP.Core.Screens.Gameplay;
using FTP.Infrastructre.Managers;
using FTP.Infrastructre.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FTP.Core.States
{
    public class GameplayState : IState
    {
        private RefManager<IScreenManager> _screenManager = new RefManager<IScreenManager>();

        private RefManager<IAuthenticationManager> _authenticationManager = new RefManager<IAuthenticationManager>();

        private IGameplayScreen _gameplayScreen;

        public UniTask Initialize()
        {
            _gameplayScreen = _screenManager.GetManager.ShowScreen<IGameplayScreen>();

            DefineEvents();
            return UniTask.CompletedTask;
        }

        public UniTask OnEnter()
        {
            return UniTask.CompletedTask;
        }

        public UniTask OnLeave()
        {
            return UniTask.CompletedTask;
        }

        private void DefineEvents()
        {
            _gameplayScreen.OnSignOut += () => { _authenticationManager.GetManager.SignOut(); };
        }
    }
}
