using FTP.Infrastructre.Managers;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Scriptables.Manager
{
    [CreateAssetMenu(fileName = "ManagerData", menuName = "Data/ManagerData", order = 1)]
    public class ManagersData : ScriptableObject
    {
        /// <summary>
        /// Managers that holds all managers which includes on game
        /// </summary>
        public List<ManagerBase> Managers = new List<ManagerBase>();
    }
}
