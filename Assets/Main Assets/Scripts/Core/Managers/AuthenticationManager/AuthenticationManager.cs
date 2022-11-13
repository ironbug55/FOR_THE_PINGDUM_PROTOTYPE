using Cysharp.Threading.Tasks;
using Firebase.Auth;
using FTP.Core.Authenticators;
using FTP.Core.Managers.State;
using FTP.Core.States;
using FTP.Infrastructre.Authentications;
using FTP.Infrastructre.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Core.Managers.Authentication
{
    public class AuthenticationManager : ManagerBase, IAuthenticationManager
    {
        private Dictionary<Type, IAuthenticator> _authenticators = new Dictionary<Type, IAuthenticator>();

        private RefManager<IStateManager> _stateManager = new RefManager<IStateManager>();
        
        public override UniTask CleanUp()
        {
            _authenticators.Clear();
            return UniTask.CompletedTask;
        }

        public override UniTask Initialize()
        {
            return UniTask.CompletedTask;
        }

        public T GetAuthenticator<T>() where T : IAuthenticator, new()
        {
            if (_authenticators.ContainsKey(typeof(T)))
            {
                return (T)_authenticators[typeof(T)];
            }

            T authenticator = new T();
            _authenticators.Add(typeof(T), authenticator);
            authenticator.Initalize();

            Debug.Log($"{authenticator.GetType().Name} has been constructed.");

            return authenticator;
        }

        public async UniTask SignOut()
        {
            FirebaseAuth.DefaultInstance.SignOut();
            await _stateManager.GetManager.ChangeState<LoginState>();
        }
    }
}