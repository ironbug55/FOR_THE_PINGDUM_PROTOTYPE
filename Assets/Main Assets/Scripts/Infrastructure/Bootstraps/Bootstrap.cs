using FTP.Infrastructre.Managers;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using FTP.Infrastructre.Utils;
using FTP.Scriptables.Manager;

namespace FTP.Infrastructre.Bootstraps
{
    /// <summary>
    /// God tier class
    /// <para>
    /// </para> 
    /// Which is the handles all stuff in the game
    /// </summary>
    public class Bootstrap : MonoBehaviour
    {
        public static Bootstrap Instance;

        [SerializeField] 
        private ManagersData _managerSettings;

        //Had to divide as _managers and _managersIdentifiers to handle IManager by type and handle ManagerIdentifer to get manager.
        //Example: CoreLoopManager have to handle IManager components and if any script wants to refer one single manager, can call it by his interface from _managersIdentifiers.
        private Dictionary<Type, IManager> _managers = new Dictionary<Type, IManager>();
        private Dictionary<Type, IManager> _managersIdentifiers = new Dictionary<Type, IManager>();

        public async void Awake()
        {
            if(Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            await InitializeBootstrap();
            await InitializeManagers();
        }

        public T GetManager<T>() where T : IManager
        {
            return (T)_managersIdentifiers[typeof(T)];
        }

        public Dictionary<Type, IManager> GetAllManagers()
        {
            return _managers;
        }

        private async UniTask InitializeBootstrap()
        {
            Instance = this;

            DontDestroyOnLoad(this);
            RefManager.SetBootstrap(this);

            await UniTask.CompletedTask;
        }

        private async UniTask InitializeManagers()
        {
            foreach (ManagerBase manager in _managerSettings.Managers)
            {
                var instantiatedManager = Instantiate(manager);
                instantiatedManager.transform.SetParent(transform);

                Helper.RemoveCloneNameOnGameobject(instantiatedManager.gameObject);

                Type[] managerInterfaces = instantiatedManager.GetType().GetInterfaces();

                foreach (Type managerInterface in managerInterfaces)
                {
                    if(typeof(IManager) != managerInterface)
                    {
                        _managersIdentifiers.Add(managerInterface, instantiatedManager);
                        
                    }
                }

                _managers.Add(instantiatedManager.GetType(), instantiatedManager);
            }

            List<UniTask> managerInitializations = new List<UniTask>();

            foreach(IManager manager in _managers.Values)
            {
                managerInitializations.Add(manager.Initialize());

                Debug.Log($"{manager.GetType().Name} has been initialized");
            }

            await UniTask.WhenAll(managerInitializations);
        }

        private async void OnDestroy()
        {
            foreach(IManager insantiatedManager in _managers.Values)
            {
                await insantiatedManager.CleanUp();
                Debug.Log($"Manager {insantiatedManager.GetType().Name} cleaned up.");
            }
        }
    }
}
