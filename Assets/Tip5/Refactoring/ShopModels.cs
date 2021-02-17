using System.Collections.Generic;

namespace OOPWithGeneric
{
    public abstract class BaseShopModel<T> where T : class, IFishingGadget
    {
        protected List<IFishingGadget> items = new List<IFishingGadget>(); //이건 되는데
        // protected List<T> items = new List<T>(); //이건 안됨. 유니티 C#의 제네릭이 아직은 약함

        public void Add(T item)
        {
            items.Add(item);
        }

        public T GetItemByIndex(int index)
        {
            return items.Count > index ? items[index] as T: null;
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
        public void Init(List<IFishingGadget> items)
        {
            this.items = items;
        }
    }

    public interface IShop
    {
        string Title { get; }
        bool Buy(int index);
        void Init(List<IFishingGadget> items);
    }

    public class FishingRodShopModel : BaseShopModel<FishingRodGadget>, IShop
    {
        public string Title => "낚시대 상점";
    }

    public class FishingLineShopModel : BaseShopModel<FishingLineGadget>, IShop
    {
        public string Title => "낚시줄 상점";
    }

    public class FishingWheelShopModel : BaseShopModel<FishingWheelGadget>, IShop
    {
        public string Title => "낚시릴 상점";
    }
}