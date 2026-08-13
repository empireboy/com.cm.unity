using CM.Core.Application;
using CM.Core.Domain;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GameStateManagerInstaller : MonoInstaller
    {
        [SerializeField]
        private GameState _startGameState;

        public override void InstallBindings()
        {
            Container.BindInstance(new GameStateManager(_startGameState));
        }
    }
}