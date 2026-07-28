using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Infrastructure
{
    [CreateAssetMenu(fileName = "CharacterSettings", menuName = "CM/SO/Character Settings")]
    public class CharacterSettingsSO : ScriptableObject
    {
        public JumpSettings jumpSettings;
        public MovementSettings movementSettings;
    }
}
