using FTP.Infrastructre.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FTP.Scriptables.PostProcessing
{
    [CreateAssetMenu(fileName = "PostProcessingData", menuName = "Data/PostProcessingData", order = 1)]
    public class PostProcessingData : ScriptableObject
    {
        /// <summary>
        /// PostProcessesor that holds all post processors which includes on game
        /// </summary>
        public List<PostProcessorBase> PostProcessor = new List<PostProcessorBase>();
    }
}
