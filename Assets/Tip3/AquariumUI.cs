using UnityEngine;
using UnityEngine.UI;

namespace OOPWithInterface
{
    public class AquariumUI : MonoBehaviour
    {
        [SerializeField] private Text totalCountText = null;
        [SerializeField] private Text bestFishText = null;

        public void Refresh()
        {
        }
    }
}