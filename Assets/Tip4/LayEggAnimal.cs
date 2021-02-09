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
                stateText.text = string.Format("{0}개의 알을 낳음", eggCount);
                var eggIncubateAnimal = GetComponent<EggIncubateAnimal>();
                eggIncubateAnimal.RequestIncubate();
                if ( GetComponent<NursingAnimal>() is NursingAnimal nursingAnimal )
                {
                    for( var i = 0; i<eggCount; ++i )
                    {
                        nursingAnimal.RequestNursing(new NursingBaby());
                    }
                }
            }
        }
    }
}
