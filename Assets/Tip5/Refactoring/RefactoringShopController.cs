using UnityEngine;

namespace OOPWithGeneric
{
    public class RefactoringShopController : MonoBehaviour
    {
        [SerializeField] private RefactoringMonoShop monoShopPrefab = null;

        public void OnClickedFishingRodShop()
        {
            var monoShop = Instantiate<RefactoringMonoShop>(monoShopPrefab, transform);
            monoShop.Init<FishingRodShopModel>();
        }
        public void OnClickedFishingLineShop()
        {
            var monoShop = Instantiate<RefactoringMonoShop>(monoShopPrefab, transform);
            monoShop.Init<FishingLineShopModel>();
        }
        public void OnClickedFishingWheelShop()
        {
            var monoShop = Instantiate<RefactoringMonoShop>(monoShopPrefab, transform);
            monoShop.Init<FishingWheelShopModel>();
        }

        public void OnClickedFishingLureShop()
        {
            var monoShop = Instantiate<RefactoringMonoShop>(monoShopPrefab, transform);
            monoShop.Init<FishingLureShopModel>();
        }
    }
}