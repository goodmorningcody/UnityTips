using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Hunting
{
    // LayEggAnimal
    // 알을 낮는 동물
    public class LayEggAnimal : MonoBehaviour
    {
        [SerializeField] private float layEggInterval = 5f;
        private Text stateText = null; 
        private int eggCount = 0;
        private Coroutine coroutine = null;
        void Awake()
        {
            stateText = GetComponentInChildren<Text>();
        }
        void OnEnable()
        {
            coroutine = StartCoroutine(GiveBirth());
        }
        void OnDisable()
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        IEnumerator GiveBirth()
        {
            while(true)
            {
                eggCount = 0;
                yield return new WaitForSeconds(layEggInterval);
                eggCount = Random.Range(5, 10);
                stateText.text = string.Format("{0}개의 알을 낳고, 품음", eggCount);
                yield return new WaitForSeconds(10f);
                stateText.text = "알이 모두 부화함";
                yield return new WaitForSeconds(2f);
                stateText.text = "새끼 새를 보살핌";
                yield return new WaitForSeconds(2f);
                stateText.text = "새끼 새 출가";
            }
        }
    }
}