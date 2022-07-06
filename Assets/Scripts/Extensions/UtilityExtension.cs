using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class UtilityExtension
    {
        public static T GetRandomItem<T>(this List<T> list)
        {
            int index = Random.Range(0, list.Count);
            return list[index];
        }
    }
}