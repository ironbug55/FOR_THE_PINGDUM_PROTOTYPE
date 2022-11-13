using FTP.Infrastructre.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTP.Core.PostProcessing.Handler
{
    public class PostProcessingRenderHandler : MonoBehaviour, IPostProcessingRenderHandler
    {
        private List<IPostProcessor> _postProcessors = new List<IPostProcessor>();

        public void InitalizePostProcessors(List<IPostProcessor> postProcessorBases)
        {
            _postProcessors = postProcessorBases;
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            var previousRenderTexture = RenderTexture.GetTemporary(source.width, source.height);
            Graphics.Blit(source, previousRenderTexture);
            foreach (IPostProcessor postProcessor in _postProcessors)
            {
                var renderedTexture = RenderTexture.GetTemporary(source.width, source.height);

                postProcessor.OnPostProcessing(previousRenderTexture,renderedTexture);
                Graphics.Blit(renderedTexture,previousRenderTexture);

                RenderTexture.ReleaseTemporary(renderedTexture);
            }

            Graphics.Blit(previousRenderTexture, destination);
            RenderTexture.ReleaseTemporary(previousRenderTexture);
        }
    }
}
