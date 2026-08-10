using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class AnimationInstaller : MonoInstaller
    {
        [SerializeField]
        private Animator _animator;

        public override void InstallBindings()
        {
            Container.Bind<Animator>().FromInstance(_animator).AsSingle();
        }
    }
}