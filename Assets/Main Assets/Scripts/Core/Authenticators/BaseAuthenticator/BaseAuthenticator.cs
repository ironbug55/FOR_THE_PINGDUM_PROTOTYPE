using Cysharp.Threading.Tasks;
using Firebase.Auth;
using FTP.Infrastructre.Authentications;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FTP.Core.Authenticators
{
    public class BaseAuthenticator : IAuthenticator
    {
        protected FirebaseAuth auth;

        public UniTask Initalize()
        {
            auth = FirebaseAuth.DefaultInstance;
            return UniTask.CompletedTask;
        }

        public virtual UniTask<bool> Authenticate()
        {
            return new UniTask<bool>();
        }
    }
}
