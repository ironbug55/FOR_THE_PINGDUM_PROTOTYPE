using FTP.Infrastructre.Screens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Scriptables.Screen
{
    [CreateAssetMenu(fileName = "ScreensData",menuName = "Data/ScreensData", order = 1)]
    public class ScreensData : ScriptableObject
    {
        public List<BaseScreen> Screens = new List<BaseScreen>();
    }
}
