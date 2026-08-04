using CM.Core.Domain;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridViewInstaller : MonoInstaller
    {
        [SerializeField]
        private GridView _gridView;

        [SerializeField]
        private Tilemap _tilemap;

        public override void InstallBindings()
        {
            Container.BindInstance(_gridView).AsSingle();
            Container.BindInstance(_tilemap).AsSingle();

            BoundsInt bounds = _tilemap.cellBounds;

            Core.Domain.Grid grid = new(bounds.size.x, bounds.size.y);

            for (int i = 0; i < bounds.size.x; i++)
            {
                for (int j = 0; j < bounds.size.y; j++)
                {
                    grid.GetCell(new Int2(i, j)).IsBlocked = Random.value < 0.15f;
                }
            }

            Container.BindInstance(grid).AsSingle();
        }
    }
}