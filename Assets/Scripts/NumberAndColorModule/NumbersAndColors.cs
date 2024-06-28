using UnityEngine;

namespace NumberAndColorModule
{
    public class NumbersAndColors : MonoBehaviour
    {
        [field: SerializeField]
        public NumberAndColorData[] NumberAndColorData { get; private set; }
    }
}