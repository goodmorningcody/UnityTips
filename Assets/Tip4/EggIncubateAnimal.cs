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

    public class EggIncubateAnimal : MonoBehaviour
    {
        private Text stateText = null;
        private Coroutine coroutine = null;

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



        public void RequestIncubate()
        {
            StartCoroutine(Incubate());
        }

        IEnumerator Incubate()
        {
            stateText.text = "알을 품기 시작함";
            yield return new WaitForSeconds(3f);
            stateText.text = "알이 모두 부화함";
        }
    }
}