using Cysharp.Threading.Tasks;
using FTP.Infrastructre.Managers;
using System.Collections.Generic;
using FTP.Infrastructre.States;
using FTP.Infrastructre.Bootstraps;
using UnityEngine;

namespace FTP.Core.Managers.State
{
    public class StateManager : ManagerBase, IStateManager
    {
        private IState _activeState;

        private Stack<IState> _stateHistory = new Stack<IState>();

        public override UniTask CleanUp()
        {
            HandleHistory(true);

            if (_activeState != null)
            {
                _activeState.OnLeave();
            }

            return UniTask.CompletedTask;
        }

        public override async UniTask Initialize()
        {
            await ChangeState<InitialState>(); //The state that starts everything.
        }

        public async UniTask<T> ChangeState<T>(bool clearHistory = false) where T : IState, new()
        {
            HandleHistory(clearHistory);

            T newState = await ChangeState(new T());

            return newState;
        }

        private async UniTask<T> ChangeState<T>(T state) where T : IState
        {
            if (_activeState != null)
            {
                await _activeState.OnLeave();
            }

            await state.Initialize();
            await state.OnEnter();

            _activeState = state;

            return (T)_activeState;
        }

        private void HandleHistory(bool clearHistory)
        {
            if (clearHistory)
            {
                _stateHistory.Clear();
            }
            else
            {
                if (_activeState != null)
                {
                    _stateHistory.Push(_activeState);
                }
            }
        }
    }
}
