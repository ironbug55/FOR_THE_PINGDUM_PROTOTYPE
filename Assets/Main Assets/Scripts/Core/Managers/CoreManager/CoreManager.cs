using FTP.Infrastructre.Bootstraps;
using FTP.Infrastructre.Managers;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using Google;

namespace FTP.Core.Managers.Core
{
    public class CoreManager : ManagerBase
    {
        private Dictionary<Type, IManager> _managers;
        public override UniTask Initialize()
        {
            _managers = Bootstrap.Instance.GetAllManagers();

            return UniTask.CompletedTask;
        }

        /// <summary>
        /// Fixed update of all managers
        /// </summary>
        public void FixedUpdate()
        {
            float fixedUpdateTime = Time.fixedDeltaTime;
            
            foreach (IManager manager in _managers.Values)
            {
                manager.FixedDeltaUpdate(fixedUpdateTime);
            }
        }

        /// <summary>
        /// Delta update of all managers
        /// </summary>
        private void Update()
        {
            float deltaTime = Time.deltaTime;
            foreach (IManager manager in _managers.Values)
            {
                manager.DeltaUpdate(deltaTime);
            }
        }

        public override UniTask CleanUp()
        {
            return UniTask.CompletedTask;
        }
    }
}
