using Cysharp.Threading.Tasks;
using FTP.Infrastructre.Authentications;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Core.Authenticators.Email
{
    public interface IEmailAuthenticator : IAuthenticator
    {
        public UniTask<bool> EmailAuthenticate(string email, string password);
        public UniTask<bool> EmailSignUp(string email, string password);
    }
}
