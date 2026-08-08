using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Infrastructure
{
    [CreateAssetMenu(fileName = "GridActorSettings", menuName = "CM/SO/Grid Actor Settings")]
    public class GridActorSettingsSO : ScriptableObject
    {
        public GridActorSettings settings;
    }
}
