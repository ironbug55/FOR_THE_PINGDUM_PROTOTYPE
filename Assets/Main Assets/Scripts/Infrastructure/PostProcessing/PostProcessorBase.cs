using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FTP.Infrastructre.PostProcessing
{
    public abstract class PostProcessorBase : MonoBehaviour, IPostProcessor
    {

        [SerializeField] 
        private Material _postProcessingMaterial;

        private Material _sharedPostProcessingMaterial;
        public Material PostProcessingMaterial => _sharedPostProcessingMaterial;

        /// <summary>
        /// <paramref name="isDebugging"/> in case setting material from editor and seeing the changes immediately. <para>
        /// Could be useful when balancing color, brightness etc...</para>
        /// </summary>
        public UniTask Initalize(bool isDebugging)
        {
            _sharedPostProcessingMaterial = (isDebugging) ? _postProcessingMaterial : new Material(_postProcessingMaterial);

            return UniTask.CompletedTask;
        }

        

        public void OnPostProcessing(RenderTexture sourceRenderTexture, RenderTexture targetRenderTexture)
        {
            Graphics.Blit(sourceRenderTexture, targetRenderTexture, _sharedPostProcessingMaterial);
        }
    }
}
