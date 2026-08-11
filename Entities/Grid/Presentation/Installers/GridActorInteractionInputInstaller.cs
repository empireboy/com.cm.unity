using CM.Unity.Infrastructure;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridActorInteractionInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Core.Domain.ITickable>().To<GridActorInteractionInputController>().AsSingle();

            Container.BindInterfacesTo<TickableAdapter>().AsSingle();
        }
    }
}