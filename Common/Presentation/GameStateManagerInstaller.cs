using CM.Core.Application;
using CM.Core.Domain;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GameStateManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(new GameStateManager(GameStates.Gameplay));
        }
    }
}