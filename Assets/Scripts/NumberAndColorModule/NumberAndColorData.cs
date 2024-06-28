using System;
using UnityEngine;

namespace NumberAndColorModule
{
    [Serializable]
    public class NumberAndColorData
    {
        [field: SerializeField]
        public int Number { get; private set; }
        
        [field: SerializeField]
        public Color Color { get; private set; }
    }
}