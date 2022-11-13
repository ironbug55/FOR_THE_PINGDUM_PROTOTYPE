using Cysharp.Threading.Tasks;
using FTP.Infrastructre.Managers;
using FTP.Infrastructre.PostProcessing;

namespace FTP.Core.Managers.PostProcessing
{
    public interface IPostProcessingManager : IManager
    {
        public UniTask InitalizePostProcessings();
        public T GetPostProcessor<T>() where T : IPostProcessor;
    }
}
