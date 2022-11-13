using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Infrastructre.Screens
{
    public abstract class BaseScreen : MonoBehaviour, IScreen
    {
        public abstract UniTask Initialize();

        public virtual UniTask OnHide()
        {
            gameObject.SetActive(false);
            return UniTask.CompletedTask; 
        }

        public virtual UniTask OnShow()
        {
            gameObject.SetActive(true);
            return UniTask.CompletedTask;
        }
    }
}