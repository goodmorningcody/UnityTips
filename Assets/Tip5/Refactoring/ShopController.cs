using UnityEngine;

namespace OOPWithGeneric
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private MonoShop monoShopPrefab = null;

        public void OnClickedFishingRodShop()
        {
            var monoShop = Instantiate<MonoShop>(monoShopPrefab, transform);
            monoShop.Init<FishingRodShopModel>();
        }
        public void OnClickedFishingLineShop()
        {
            var monoShop = Instantiate<MonoShop>(monoShopPrefab, transform);
            monoShop.Init<FishingLineShopModel>();
        }
        public void OnClickedFishingWheelShop()
        {
            var monoShop = Instantiate<MonoShop>(monoShopPrefab, transform);
            monoShop.Init<FishingWheelShopModel>();
        }
    }
}