using FTP.Infrastructre.Managers;
using Cysharp.Threading.Tasks;
using UnityEngine;
using FTP.Infrastructre.PostProcessing;
using System.Collections.Generic;
using System;
using System.Linq;
using FTP.Scriptables.PostProcessing;

namespace FTP.Core.Managers.PostProcessing
{
    public class PostProcessingManager : ManagerBase, IPostProcessingManager
    {
        /// <summary>
        /// In case setting material from editor and seeing the changes immediately. <para>
        /// Could be useful when balancing color, brightness etc...</para>
        /// </summary>
        [SerializeField]
        private bool _isDebugging = false;
        
        [SerializeField]
        private PostProcessingData _postProcessingData;

        private RefManager<ICameraManager> _cameraManager = new RefManager<ICameraManager>();
        private Dictionary<Type, IPostProcessor> _postProcessors = new Dictionary<Type, IPostProcessor>();
        private Dictionary<Type, IPostProcessor> _postProcessorIdentifiers = new Dictionary<Type, IPostProcessor>();

        public override async UniTask Initialize()
        {
            await InitalizePostProcessings();
        }

        public override UniTask CleanUp()
        {
            return UniTask.CompletedTask;
        }

        public T GetPostProcessor<T> () where T : IPostProcessor
        {
            return (T)_postProcessorIdentifiers[typeof(T)];
        }

        public async UniTask InitalizePostProcessings()
        {
            var postProcessingRender = _cameraManager.GetManager.PostProcessingRenderHandler;

            foreach (PostProcessorBase postProcessor in _postProcessingData.PostProcessor)
            {
                var postProcessorInterfaces = postProcessor.GetType().GetInterfaces();

                foreach (Type postProcessorInterface in postProcessorInterfaces)
                {
                    if(postProcessorInterface != typeof(IPostProcessor))
                    _postProcessorIdentifiers.Add(postProcessorInterface, postProcessor);
                }

                _postProcessors.Add(postProcessor.GetType(), postProcessor);
            }

            List<UniTask> managerInitializations = new List<UniTask>();

            foreach(IPostProcessor postProcessor in _postProcessors.Values)
            {
                managerInitializations.Add(postProcessor.Initalize(_isDebugging));
            }

            await UniTask.WhenAll(managerInitializations);

            postProcessingRender.InitalizePostProcessors(_postProcessors.Values.ToList());
        }
    }
}