using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FTP.Infrastructre.States
{
    /// <summary>
    /// State base's main function is defining _initialState and controlling other states by StateBase's type.
    /// </summary>
    public class StateBase : MonoBehaviour, IState
    {
        public virtual UniTask Initialize()
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnEnter()
        {
            return UniTask.CompletedTask;
        }

        public virtual UniTask OnLeave()
        {
            return UniTask.CompletedTask;
        }
    }
}
