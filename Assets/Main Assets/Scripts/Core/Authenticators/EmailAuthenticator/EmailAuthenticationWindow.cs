using Cysharp.Threading.Tasks;
using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FTP.Core.Authenticators.Email
{
    /// <summary>
    /// This window could be change as screen.
    /// </summary>
    public class EmailAuthenticationWindow : MonoBehaviour
    {
        [SerializeField]
        private Button _cancelButton, _signUpButton, _loginButton;

        [SerializeField]
        private InputField _mailInputField, _passwordInputField;

        public Func<string, string, UniTask> _emailLogin;
        public Func<string, string, UniTask> _emailSignUp;

        public void Initalize(Func<string, string, UniTask> emailLogin, Func<string, string, UniTask> emailSignUp)
        {
            _emailLogin = emailLogin;
            _emailSignUp = emailSignUp;
        }

        /// <summary>
        /// You just can call it as initalize.
        /// </summary>
        private void Start()
        {
            _cancelButton.onClick.AddListener(() => CloseWindow());
            _loginButton.onClick.AddListener(() => Login());
            _signUpButton.onClick.AddListener(() => SignUp());
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public async void CloseWindow()
        {
            gameObject.SetActive(false);
            await CleanUp();
        }

        private void Login()
        {
            _emailLogin?.Invoke(_mailInputField.text, _passwordInputField.text);
        }

        private void SignUp()
        {
            _emailSignUp?.Invoke(_mailInputField.text, _passwordInputField.text);
        }

        private UniTask CleanUp()
        {
            _mailInputField.text = "";
            _passwordInputField.text = "";
            return UniTask.CompletedTask;
        }
    }
}
