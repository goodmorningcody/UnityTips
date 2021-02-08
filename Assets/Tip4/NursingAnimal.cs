using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Hunting
{
    // NursingAnimal class
    // 젖을 먹이는 동물
    // 1. 자궁에서 태아를 키움
    // 2. 자궁에서 자란 태아 랜덤 출산
    // 3. 출산 후 랜덤한 시간에 수유
    // 4. 일정 시간 보살핌
    // 5. 독립 후 다시 1번
    public class NursingAnimal : MonoBehaviour
    {
        [SerializeField] private float pregnantInterval = 5f;
        private Text stateText = null;
        private int childrenCount = 0;
        private Coroutine coroutine = null;

        void Awake()
        {
            stateText = GetComponentInChildren<Text>();
            stateText.text = "";
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
                childrenCount = 0;
                yield return new WaitForSeconds(pregnantInterval);
                childrenCount = Random.Range(1, 5);
                stateText.text = string.Format("{0}마리 출산.", childrenCount);
                yield return Nursing();
                yield return new WaitForSeconds(5f);
                stateText.text = string.Format("모두 출가");
            }
        }
        IEnumerator Nursing()
        {
            for( var i = 0; i<childrenCount; ++i )
            {
                yield return new WaitForSeconds(Random.Range(1f, 2f));
                stateText.text = string.Format("{0}번 모유 수유.", i);
            }
        }
    }
}