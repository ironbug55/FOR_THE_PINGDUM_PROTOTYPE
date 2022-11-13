using Cysharp.Threading.Tasks;
using FTP.Infrastructre.Managers;
using FTP.Infrastructre.States;

namespace FTP.Core.Managers.State
{
    public interface IStateManager : IManager
    {
        public UniTask<T> ChangeState<T>(bool clearHistory = false) where T : IState, new();
    }
}
