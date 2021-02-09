using System.Collections;
using System.Collections.Generic;
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

    public class NursingBaby
    {
    }

    public class NursingAnimal : MonoBehaviour
    {
        private Text stateText = null;
        private Coroutine coroutine = null;
        public Queue<NursingBaby> nursingBabies = new Queue<NursingBaby>();

        void Awake()
        {
            stateText = GetComponentInChildren<Text>();
            stateText.text = "";
        }

        void OnDisable()
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }



        public void RequestNursing(NursingBaby baby)
        {
            nursingBabies.Enqueue(baby);
            if ( coroutine == null )
            {
                StartCoroutine(Nursing());
            }
        }

        IEnumerator Nursing()
        {
            while(true)
            {
                if ( nursingBabies.Count == 0 )
                {
                    coroutine = null;
                    break;
                }
                stateText.text = "모유 수유 시작.";
                yield return new WaitForSeconds(Random.Range(1f, 2f));
                stateText.text = "모유 수유 끝";
                nursingBabies.Dequeue();
            }
        }
    }
}