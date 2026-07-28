using CM.Core.Domain;
using UnityEngine;

namespace CM.Unity.Infrastructure
{
    public static class Float2Extension
    {
        public static Vector2 ToVector2(this Float2 float2)
        {
            return new Vector2(float2.x, float2.y);
        }

        public static Vector3 ToVector3(this Float2 float2)
        {
            return new Vector3(float2.x, 0, float2.y);
        }
    }
}