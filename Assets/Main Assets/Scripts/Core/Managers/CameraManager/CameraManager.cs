using Cysharp.Threading.Tasks;
using FTP.Core.PostProcessing.Handler;
using FTP.Infrastructre.Managers;
using FTP.Infrastructre.Utils;
using UnityEngine;

namespace FTP.Core.Managers.Camera
{
    public class CameraManager : ManagerBase, ICameraManager
    {
        [SerializeField]
        private UnityEngine.Camera _camera;
        private UnityEngine.Camera _instantiatedCamera;

        private PostProcessingRenderHandler _postProcessingRenderHandler;
        public PostProcessingRenderHandler PostProcessingRenderHandler => _postProcessingRenderHandler;
        
        public override UniTask Initialize()
        {
            InstantiateCamera();
            return UniTask.CompletedTask;
        }

        public override UniTask CleanUp()
        {
            return UniTask.CompletedTask;
        }

        private void InstantiateCamera()
        {
            _instantiatedCamera = Instantiate(_camera);
            Helper.RemoveCloneNameOnGameobject(_instantiatedCamera.gameObject);

            _postProcessingRenderHandler = _instantiatedCamera.GetComponent<PostProcessingRenderHandler>();
        }
    }
}
