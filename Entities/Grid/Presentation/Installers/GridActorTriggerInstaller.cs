using CM.Core.Domain;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridActorTriggerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GridActorTriggerController>().AsSingle();
        }
    }
}
