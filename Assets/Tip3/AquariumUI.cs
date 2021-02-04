using UnityEngine;
using UnityEngine.UI;

namespace OOPWithInterface
{
    public class AquariumUI : MonoBehaviour
    {
        [SerializeField] private Text totalCountText = null;
        [SerializeField] private Text bestFishText = null;

        public void Refresh(IFishStorage fishStorage)
        {
            var bestFish = fishStorage.GetBestFish();
            var totalCount = fishStorage.TotalCount;
            bestFishText.text = string.Format("{0}({1}cm)", bestFish.Name, bestFish.Length);
            totalCountText.text = string.Format("{0} 마리", totalCount);
        }
    }
}