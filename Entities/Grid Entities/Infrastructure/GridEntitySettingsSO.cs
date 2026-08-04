using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Infrastructure
{
    [CreateAssetMenu(fileName = "GridEntitySettings", menuName = "CM/SO/Grid Entity Settings")]
    public class GridEntitySettingsSO : ScriptableObject
    {
        public GridEntitySettings settings;
    }
}
