using FTP.Infrastructre.Screens;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Core.Screens.Gameplay
{
    public interface IGameplayScreen : IScreen
    {
        public event Action OnSignOut;
    }
}