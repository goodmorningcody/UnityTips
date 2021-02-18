using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPWithGeneric
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private MonoShop monoShopPrefab = null;

        public void OnClickedFishingRodShop()
        {
            var monoShop = Instantiate<MonoShop>(monoShopPrefab, transform);
            monoShop.Init(MonoShop.Type.Rod);
        }
        public void OnClickedFishingLineShop()
        {
            var monoShop = Instantiate<MonoShop>(monoShopPrefab, transform);
            monoShop.Init(MonoShop.Type.Line);
        }
        public void OnClickedFishingWheelShop()
        {
            var monoShop = Instantiate<MonoShop>(monoShopPrefab, transform);
            monoShop.Init(MonoShop.Type.Wheel);
        }
    }
}
