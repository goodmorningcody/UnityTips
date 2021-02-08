using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Hunting
{
    // LungAnimal class
    // 폐호흡을 하는 동물
    // 1. breathInterval 간격으로 호흡을 함
    // 2. 동물마다 breathInterval 값이 다름
    public class LungAnimal : MonoBehaviour
    {
        [SerializeField] float breathInterval = 3f;
        private Text stateText = null;
        private Coroutine breathCoroutine = null;

        void Awake()
        {
            stateText = GetComponentInChildren<Text>();
            stateText.text = "";
        }

        void OnEnable()
        {
            breathCoroutine = StartCoroutine(Breaths());
        }

        void OnDisable()
        {
            StopCoroutine(breathCoroutine);
            breathCoroutine = null;
        }

        IEnumerator Breaths()
        {
            while(true)
            {
                yield return new WaitForSeconds(breathInterval);
                stateText.text = "숨을 들이마심.";
                yield return new WaitForSeconds(breathInterval);
                stateText.text = "숨을 내뱉음.";
            }
        }
    }
}
