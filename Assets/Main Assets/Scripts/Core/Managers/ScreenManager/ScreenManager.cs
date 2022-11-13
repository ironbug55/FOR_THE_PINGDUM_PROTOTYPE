using Cysharp.Threading.Tasks;
using FTP.Infrastructre.Managers;
using FTP.Infrastructre.Screens;
using FTP.Infrastructre.Utils;
using FTP.Scriptables.Screen;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace FTP.Core.Managers.Screen
{
    public class ScreenManager : ManagerBase, IScreenManager
    {
        [SerializeField]
        private ScreensData _screensData;

        [SerializeField]
        private Canvas _initialCanvas;

        private Canvas _activeCanvas;

        public Canvas ActiveCanvas => _activeCanvas;

        private IScreen _activeScreen;

        private Dictionary<Type, IScreen> _screens = new Dictionary<Type, IScreen>();
        private Dictionary<Type, IScreen> _screensIdentifiers = new Dictionary<Type, IScreen>();

        public override UniTask CleanUp()
        {
            return UniTask.CompletedTask;
        }

        public async override UniTask Initialize()
        {
            await InitalizeCanvas();
            await InitalizeScreens();
        }

        private UniTask InitalizeCanvas()
        {
            _activeCanvas = Instantiate(_initialCanvas);
            Helper.RemoveCloneNameOnGameobject(_activeCanvas.gameObject);
            _activeCanvas.transform.SetParent(transform);

            return UniTask.CompletedTask;
        }

        private async UniTask InitalizeScreens()
        {
            foreach (BaseScreen screen in _screensData.Screens)
            {
                var instantiatedScreen = Instantiate(screen);
                instantiatedScreen.transform.SetParent(_activeCanvas.transform, false);

                Helper.RemoveCloneNameOnGameobject(instantiatedScreen.gameObject);

                Type[] screenInterfaces = instantiatedScreen.GetType().GetInterfaces();

                foreach (Type screenInterface in screenInterfaces)
                {
                    if (typeof(IScreen) != screenInterface)
                    {
                        _screensIdentifiers.Add(screenInterface, instantiatedScreen);
                        Debug.Log(instantiatedScreen.name + " has been added.");
                    }
                }

                instantiatedScreen.gameObject.SetActive(false);

                _screens.Add(instantiatedScreen.GetType(), instantiatedScreen);
            }

            List<UniTask> screenInitializations = new List<UniTask>();

            foreach (IScreen screen in _screens.Values)
            {
                screenInitializations.Add(screen.Initialize());
            }


            await UniTask.WhenAll(screenInitializations);
        }

        public T ShowScreen<T>() where T : IScreen
        {
            //Todo: there could be cool screen transititons.
            if (_activeScreen != null)
                _activeScreen.OnHide();

            var screen = (T)_screensIdentifiers[typeof(T)];
            screen.OnShow();

            _activeScreen = screen;

            return (T)_screensIdentifiers[typeof(T)];
        }
    }
}
