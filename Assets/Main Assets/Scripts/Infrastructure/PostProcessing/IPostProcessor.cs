using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Infrastructre.PostProcessing
{
    public interface IPostProcessor
    {
        public Material PostProcessingMaterial { get; }
        public UniTask Initalize(bool isDebugging);
        public void OnPostProcessing(RenderTexture sourceRenderTexture, RenderTexture targetRenderTexture);
    }
}
