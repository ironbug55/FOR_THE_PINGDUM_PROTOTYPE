using Cysharp.Threading.Tasks;
using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FTP.Core.Authenticators.Email
{
    public class EmailAuthenticator : BaseAuthenticator , IEmailAuthenticator
    {
        public async UniTask<bool> EmailAuthenticate(string email, string password)
        {
            Debug.Log("test");
            var authenticateTask = auth.SignInWithEmailAndPasswordAsync(email, password);

            FirebaseUser user = null;
            await authenticateTask.ContinueWith(task =>
            {
                if (task.IsCanceled || task.IsFaulted)
                {
                    return;
                }

                user = task.Result;
            });

            return user != null;
        }

        public async UniTask<bool> EmailSignUp(string email, string password)
        {
            var signupTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);

            FirebaseUser user = null;

            await signupTask.ContinueWith(task => 
            {
                if(task.IsCanceled || task.IsFaulted)
                {
                    return; 
                }

                user = task.Result;
            });
            
            return user != null;
        }
    }
}
