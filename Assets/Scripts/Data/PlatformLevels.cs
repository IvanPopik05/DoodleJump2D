using System.Collections.Generic;
using UnityEngine;

namespace Generator_Container
{
    [CreateAssetMenu(fileName = "PlatformLevels", menuName = "Levels/Platform", order = 1)]
    public class PlatformLevels : ScriptableObject
    {
        [SerializeField] private List<Level> _levels;
        public List<Level> Levels => _levels;
    }
}