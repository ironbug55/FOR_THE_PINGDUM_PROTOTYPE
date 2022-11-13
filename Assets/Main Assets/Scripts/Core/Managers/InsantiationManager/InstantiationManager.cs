using FTP.Infrastructre.Managers;
using Cysharp.Threading.Tasks;
using FTP.Core.Managers.Core;

namespace FTP.Core.Managers.Instantiation
{
    public class InstantiationManager : ManagerBase, IInstantiationManager
    {
        public override UniTask CleanUp()
        {
            return UniTask.CompletedTask;
        }

        public override UniTask Initialize()
        {
            return UniTask.CompletedTask;
        }
    }
}
