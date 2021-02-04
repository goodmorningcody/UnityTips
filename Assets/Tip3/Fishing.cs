using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OOPWithInterface
{
    public interface IFishStorage
    {
        int TotalCount { get; }
        Fish GetBestFish();
    }

    public class Fishing : MonoBehaviour, IFishStorage
    {
        private Fish catchingFish = null;
        private List<Fish> caughtFish = new List<Fish>();
        private bool IsCatched => catchingFish != null && Random.Range(0, 10) > 5;
        [SerializeField] private World world = null;
        [SerializeField] private UI ui = null;
        public int TotalCount => caughtFish.Count;

        public delegate void OnSnatchButtonClicked();
        public delegate void OnRefreshedFish();


        public int WoorukCount => throw new System.NotImplementedException();

        public Fish GetBestFish()
        {
            Fish bestFish = null;
            foreach(var fish in caughtFish )
            {
                if ( bestFish == null || bestFish.Length < fish.Length )
                {
                    bestFish = fish;
                }
            }
            return bestFish;
        }

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
                caughtFish.Add(catchingFish);
                Debug.LogError(string.Format("{0}({1}cm)를 잡음", catchingFish.Name, catchingFish.Length));
                ui.Refresh(this);
            }
            else
            {
                Debug.LogError("물고기 없거나 혹은 놓쳤음");
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