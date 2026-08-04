using CM.Core.Domain;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridViewInstaller : MonoInstaller
    {
        [field: SerializeField]
        protected GridView GridView { get; private set; }

        [field: SerializeField]
        protected Tilemap Tilemap { get; private set; }

        protected Core.Domain.Grid Grid { get; private set; }

        public override void InstallBindings()
        {
            Container.BindInstance(GridView).AsSingle();
            Container.BindInstance(Tilemap).AsSingle();

            BoundsInt bounds = Tilemap.cellBounds;

            Grid = new(bounds.size.x, bounds.size.y);

            Container.BindInstance(Grid).AsSingle();
        }
    }
}