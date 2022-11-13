using Cysharp.Threading.Tasks;
using FTP.Core.Managers.State;
using FTP.Core.States;
using FTP.Infrastructre.Managers;

namespace FTP.Infrastructre.States
{
    public class InitialState : IState
    {
        private RefManager<IStateManager> _stateManager = new RefManager<IStateManager>();

        public UniTask Initialize()
        {
            return UniTask.CompletedTask;
        }

        public async UniTask OnEnter()
        {
            await _stateManager.GetManager.ChangeState<LoginState>();
        }

        public UniTask OnLeave()
        {
            return UniTask.CompletedTask;
        }
    }
}
