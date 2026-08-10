using Zenject;

namespace CM.Unity.Presentation
{
    public class GridActorMovementInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Core.Domain.ITickable>().To<GridActorMovementController>().AsSingle();

            Container.BindInterfacesTo<TickableAdapter>().AsSingle();
        }
    }
}