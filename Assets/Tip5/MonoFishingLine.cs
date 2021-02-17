using UnityEngine;

namespace OOPWithGeneric
{
    public class MonoFishingLine : MonoBehaviour, IFishingGadget
    {
        [SerializeField] private string itemName = null;
        [SerializeField] private int price;
        public string ItemName => itemName;
        public int Price => price;
    }
}