using CM.Core.Domain;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridView : MonoBehaviour
    {
        [SerializeField]
        private Tilemap _tilemap;

        public Tilemap Tilemap => _tilemap;

        [Inject]
        private readonly Core.Domain.Grid _grid;

        private Vector3Int _origin;

        private void Awake()
        {
            _origin = new(_grid.Origin.x, _grid.Origin.y, 0);
        }

        public Vector3Int ToTilePosition(Int2 gridPosition)
        {
            return new Vector3Int(gridPosition.x, gridPosition.y, 0);
        }

        public Int2 ToGridPosition(Vector3Int tilePosition)
        {
            return new Int2(tilePosition.x, tilePosition.y);
        }

        public Int2 ToGridPosition(Vector3 worldPosition)
        {
            Vector3Int tilePosition = _tilemap.WorldToCell(worldPosition);

            return ToGridPosition(tilePosition);
        }

        public Vector3 ToWorldPosition(Int2 gridPosition)
        {
            Vector3Int tilePosition = ToTilePosition(gridPosition);

            return _tilemap.GetCellCenterWorld(tilePosition);
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            if (_tilemap == null)
                _tilemap = GetComponentInChildren<Tilemap>();

            GUIStyle style = new()
            {
                normal =
                {
                    textColor = Color.red,
                    background = Texture2D.blackTexture
                },
                alignment = TextAnchor.MiddleCenter
            };

            foreach (Vector3Int tilePosition in _tilemap.cellBounds.allPositionsWithin)
            {
                if (!_tilemap.HasTile(tilePosition))
                    continue;

                Vector3 worldPosition = _tilemap.GetCellCenterWorld(tilePosition);

                Int2 gridPosition = ToGridPosition(tilePosition);

                Handles.Label(worldPosition,$"{gridPosition.x}, {gridPosition.y}", style);
            }
        }

#endif

    }
}