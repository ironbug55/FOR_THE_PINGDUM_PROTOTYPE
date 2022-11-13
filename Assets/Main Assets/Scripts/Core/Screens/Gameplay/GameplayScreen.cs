using Cysharp.Threading.Tasks;
using FTP.Infrastructre.Screens;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace FTP.Core.Screens.Gameplay
{
    public class GameplayScreen : BaseScreen, IGameplayScreen
    {
        /// <summary>
        /// For debugging.
        /// </summary>
        /// <returns></returns>
        [SerializeField]
        private Button _signoutButton;

        public event Action OnSignOut;

        public override async UniTask Initialize()
        {
            await DefineEvents();
        }

        private UniTask DefineEvents()
        {
            _signoutButton.onClick.AddListener(() => OnSignOut?.Invoke());

            return UniTask.CompletedTask;
        }
    }
}
