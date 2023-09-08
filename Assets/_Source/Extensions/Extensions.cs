using UnityEngine;

namespace Extensions
{
    public static class Extensions
    {
        public static bool Contains(this LayerMask mask, int layer) =>mask == (mask | (1 << layer));
    }
}
