using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OOPWithGeneric
{
    public class MonoShop : MonoBehaviour
    {
        public enum Type
        {
            Rod,
            Line,
            Wheel,
        }

        [SerializeField] private Text shopTitle = null;
        private List<IFishingGadget> items = null;

        public void Init(Type type)
        {
            shopTitle.text = GetTitle(type);
            items = GetFishingGadgets(type);
        }

        private List<IFishingGadget> GetFishingGadgets(Type type)
        {
            switch (type)
            {
                case Type.Rod:
                    return new List<IFishingGadget>(){new FishingRodGadget(), new FishingRodGadget(), new FishingRodGadget()};
                case Type.Line:
                    return new List<IFishingGadget>(){new FishingLineGadget(), new FishingLineGadget(), new FishingLineGadget()};
                case Type.Wheel:
                    return new List<IFishingGadget>(){new FishingWheelGadget(), new FishingWheelGadget(), new FishingWheelGadget()};
                default:
                    throw new System.Exception("알 수 없는 타입의 상점입니다.");
            }
        }

        private string GetTitle(Type type)
        {
            switch (type)
            {
                case Type.Rod:
                    return "낚시대 상점";
                case Type.Line:
                    return "낚시줄 상점";
                case Type.Wheel:
                    return "낚시릴 상점";
                default:
                    throw new System.Exception("알 수 없는 타입의 상점입니다.");
            }
        }

        public IFishingGadget GetItemByIndex(int index)
        {
            return items.Count > index ? items[index]: null;
        }

        public bool Buy(int index)
        {
            if ( items.Count > index )
            {
                UnityEngine.Debug.Log(string.Format("{0}을 구매했습니다.", items[index].ItemName));
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void OnClickedClose()
        {
            Destroy(gameObject);
        }
    }
}