using CM.Core.Domain;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace CM.Unity.Presentation
{
    public class GridView : MonoBehaviour
    {
        [SerializeField]
        private Tilemap _tilemap;

        public Tilemap Tilemap => _tilemap;

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

        public Vector3 ToWorldPosition(Float2 gridPosition)
        {
            Vector3Int bottomLeftTile = new(
                Mathf.FloorToInt(gridPosition.x),
                Mathf.FloorToInt(gridPosition.y),
                0
            );

            Vector3 bottomLeftWorld = _tilemap.GetCellCenterWorld(bottomLeftTile);

            Vector3 offset = new(
                (gridPosition.x - bottomLeftTile.x) * _tilemap.cellSize.x,
                (gridPosition.y - bottomLeftTile.y) * _tilemap.cellSize.y,
                0f
            );

            return bottomLeftWorld + offset;
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
                    textColor = Color.black,
                    background = Texture2D.whiteTexture
                },
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleCenter,
                padding = new RectOffset(2, 2, 2, 2)
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