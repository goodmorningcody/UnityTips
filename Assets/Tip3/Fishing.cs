using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPWithInterface
{
    public class Fishing : MonoBehaviour
    {
        public enum State
        {
            Idle,
            Caught
        }

        private State state = State.Idle;
        private Fish catchingFish = null;
        private List<Fish> caughtFish = new List<Fish>();
        private bool IsCatched => catchingFish == null || Random.Range(0, 10) > 5;
        [SerializeField] private World world = null;
        [SerializeField] private UI ui = null;

        private void Start()
        {
            ui.StartSnatchListener(OnSnatch);
            StartCoroutine(StartFishing());
        }

        private void OnSnatch()
        {
            StopAllCoroutines();
            world.Snatched();
            if ( IsCatched )
            {
                Debug.LogError("물고기 없음");
            }
            else
            {
                caughtFish.Add(catchingFish);
                Debug.LogError(string.Format("{0}({1}cm)를 잡음", catchingFish.Name, catchingFish.Length));
            }
            StartCoroutine(StartFishing());
        }

        private void Destroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator StartFishing()
        {
            while(true)
            {
                yield return CatchAsync();
                world.Caught();
                yield return ReleaseAsync();
                world.Released();
            }
        }

        private IEnumerator CatchAsync()
        {
            Debug.Log("캐스팅");
            yield return new WaitForSeconds(Random.Range(3f, 10f));
            catchingFish = new Fish(Random.Range(0, 10) > 5 ? "광어" : "우럭", Random.Range(1f, 50f));
            Debug.Log("찌 흔들림");
        }
        private IEnumerator ReleaseAsync()
        {
            Debug.Log("잡아 당겨랴!");
            yield return new WaitForSeconds(Random.Range(3f, 10f));
            catchingFish = null;
            Debug.Log("놓쳤음");
        }
    }
}