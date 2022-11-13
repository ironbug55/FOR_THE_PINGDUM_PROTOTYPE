using Cysharp.Threading.Tasks;
using Firebase.Auth;
using FTP.Core.Authenticators.Email;
using FTP.Core.Managers.Authentication;
using FTP.Core.Managers.State;
using FTP.Core.States;
using FTP.Infrastructre.Managers;
using FTP.Infrastructre.Screens;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace FTP.Core.Screens.Login 
{
    public class LoginScreen : BaseScreen, ILoginScreen
    {
        public Func<string, string, UniTask> OnEmailAuthentication { get; set; }
        public Func<string, string, UniTask> OnEmailSignUp { get; set; }

        [SerializeField]
        private Transform _centerPanel;

        [SerializeField]
        private Button _googleAuthenticationButton;

        [SerializeField]
        private Button _emailAuthenticationButton;

        [SerializeField]
        private EmailAuthenticationWindow _emailAuthenticationWindow;

        public async override UniTask Initialize()
        {
            await InitalizeAuthenticationButtons();
        }

        public override UniTask OnHide()
        {
            _emailAuthenticationWindow.CloseWindow();
            gameObject.SetActive(false);
            return UniTask.CompletedTask;
        }

        private UniTask InitalizeAuthenticationButtons()
        {
            //We can keep it as non interactable for a while.
            //_googleAuthenticationButton.interactable = false;

            _emailAuthenticationButton.onClick.AddListener(() => {
                _emailAuthenticationWindow.Initalize(
                OnEmailAuthentication, OnEmailSignUp
                );

                _emailAuthenticationWindow.Show();
            });
            return UniTask.CompletedTask;
        }
    }
}
