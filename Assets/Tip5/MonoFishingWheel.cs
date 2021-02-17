using UnityEngine;

namespace OOPWithGeneric
{
    // 1. MonoFishing* 클래스에 중복이 발생했다. 어떻게 처리할 수 있을까?
    public class MonoFishingWheel : MonoBehaviour, IFishingGadget
    {
        [SerializeField] private string itemName = null;
        [SerializeField] private int price;
        public string ItemName => itemName;
        public int Price => price;
    }
}