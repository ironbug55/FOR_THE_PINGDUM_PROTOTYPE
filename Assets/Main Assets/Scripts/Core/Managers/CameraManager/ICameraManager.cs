using FTP.Core.PostProcessing.Handler;
using FTP.Infrastructre.Managers;

namespace FTP.Core.Managers
{
    public interface ICameraManager : IManager
    {
        public PostProcessingRenderHandler PostProcessingRenderHandler { get; }
    }
}
