using Cysharp.Threading.Tasks;

namespace FTP.Infrastructre.States
{
    /// <summary>
    /// Game flow state interface that handles the functions
    /// </summary>
    public interface IState
    {
        public UniTask Initialize();
        public UniTask OnEnter();
        public UniTask OnLeave();
    }
}
