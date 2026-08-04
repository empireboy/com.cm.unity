using CM.Core.Domain;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace CM.Unity.Presentation
{
    public class GridView : MonoBehaviour
    {
        [Inject]
        public Tilemap Tilemap { get; private set; }

        [Inject]
        public Core.Domain.Grid Grid { get; }

        private Vector3Int _origin;

        private void Awake()
        {
            _origin = Tilemap.cellBounds.min + Vector3Int.up;
        }

        public Vector3Int ToTilePosition(Int2 position)
        {
            return _origin + new Vector3Int(position.x, position.y, 0);
        }

        public Int2 ToGridPosition(Vector3Int tilePosition)
        {
            return new Int2(tilePosition.x - _origin.x, tilePosition.y - _origin.y);
        }

        public Vector3 ToWorldPosition(Int2 gridPosition)
        {
            Vector3Int tilePosition = ToTilePosition(gridPosition);

            return Tilemap.GetCellCenterWorld(tilePosition);
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            if (Tilemap == null)
                Tilemap = GetComponentInChildren<Tilemap>();

            if (_origin == Vector3.zero)
                _origin = Tilemap.cellBounds.min + Vector3Int.up;

            GUIStyle style = new()
            {
                normal =
                {
                    textColor = Color.red
                },
                alignment = TextAnchor.MiddleCenter
            };

            foreach (Vector3Int tilePosition in Tilemap.cellBounds.allPositionsWithin)
            {
                if (!Tilemap.HasTile(tilePosition))
                    continue;

                Vector3 worldPosition = Tilemap.GetCellCenterWorld(tilePosition);

                Int2 gridPosition = ToGridPosition(tilePosition);

                Handles.Label(worldPosition,$"{gridPosition.x}, {gridPosition.y}", style);
            }
        }

#endif

    }
}