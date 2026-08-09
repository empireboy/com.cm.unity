using CM.Core.Domain;
using UnityEngine;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridViewInstaller : MonoInstaller
    {
        [field: SerializeField]
        protected GridView GridView { get; private set; }

        protected Core.Domain.Grid Grid { get; private set; }

        public override void InstallBindings()
        {
            Container.BindInstance(GridView).AsSingle();

            BoundsInt bounds = GridView.Tilemap.cellBounds;
            Int2 origin = new(bounds.min.x, bounds.min.y);

            Grid = new(bounds.size.x, bounds.size.y, origin);

            Container.BindInstance(Grid).AsSingle();
        }
    }
}