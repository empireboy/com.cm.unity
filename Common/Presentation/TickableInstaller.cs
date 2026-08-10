using Zenject;

namespace CM.Unity.Presentation
{
    public class TickableInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TickableAdapter>().AsSingle();
        }
    }
}