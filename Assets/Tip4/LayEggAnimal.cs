using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using ReferenceAndEventDemo;

namespace Hunting
{
    // LayEggAnimal
    // 알을 낳는 동물
    public class LayEggAnimal : MonoBehaviour
    {
        private Text stateText = null;
        void Awake()
        {
            stateText = GetComponentInChildren<Text>();
        }

        public void RequestGiveBirth()
        {
            int eggCount = Random.Range(5, 10);
            stateText.text = string.Format("{0}개의 알을 낳음", eggCount);
            this.Emit(new LaidEggsEvent(eggCount));
        }
    }
}
