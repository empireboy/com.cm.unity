using UnityEngine;
using UnityEngine.Tilemaps;

namespace CM.Unity.Editor
{
    public class SnapToTile : MonoBehaviour
    {
#if UNITY_EDITOR

        [SerializeField]
        private Tilemap _tilemap;

        private void OnDrawGizmosSelected()
        {
            if (Application.isPlaying)
                return;

            if (!_tilemap)
                return;

            Vector3Int tilePosition = _tilemap.WorldToCell(transform.position);

            transform.position = _tilemap.GetCellCenterWorld(tilePosition);
        }

#endif
    }
}