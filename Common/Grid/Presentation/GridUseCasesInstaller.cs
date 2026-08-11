using CM.Core.Application;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridUseCasesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GridMovementUseCase>().AsSingle();
            Container.Bind<GridTeleportUseCase>().AsSingle();
            Container.Bind<GridOccupancyUseCase>().AsSingle();
            Container.Bind<GridInteractionUseCase>().AsSingle();
        }
    }
}