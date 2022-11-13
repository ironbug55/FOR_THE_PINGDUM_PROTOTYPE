using Cysharp.Threading.Tasks;
using FTP.Core.Managers;
using UnityEngine;

namespace FTP.Infrastructre.Managers
{
    public abstract class ManagerBase : MonoBehaviour, IManager
    {
        public abstract UniTask Initialize();
        public abstract UniTask CleanUp();
        public virtual void DeltaUpdate(float deltaTime) { }
        public virtual void FixedDeltaUpdate(float fixedDeltaUpdate) { }
    }
}