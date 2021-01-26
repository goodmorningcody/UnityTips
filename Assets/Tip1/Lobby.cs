using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RefactoringSingletonDemo;

namespace SingletonDemo
{
    public class Lobby : MonoBehaviour
    {
        [SerializeField] private Text coinText = null;

        void Awake()
        {
            coinText.text = string.Format("{0}", RefactoringStaticPlayManager.Coin);
        }

        public void OnClickedNormalDungeon()
        {
            SceneManager.LoadScene("Game");
            RefactoringStaticPlayManager.dungenType = DungenType.Normal;
        }

        public void OnClickedEventDungeon()
        {
            SceneManager.LoadScene("Game");
            RefactoringStaticPlayManager.dungenType = DungenType.Event;
        }
    }
}