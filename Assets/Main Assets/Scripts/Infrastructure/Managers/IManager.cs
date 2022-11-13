using Cysharp.Threading.Tasks;

namespace FTP.Infrastructre.Managers
{
    public interface IManager
    {
        public abstract UniTask Initialize();
        public abstract UniTask CleanUp();
        public abstract void DeltaUpdate(float deltaTime);
        public abstract void FixedDeltaUpdate(float fixedDeltaUpdate);
    }
}
