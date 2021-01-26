using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RefactoringSingletonDemo;

namespace SingletonDemo
{
    public class Game : MonoBehaviour
    {        
        [SerializeField] private Text coinText = null;

        public void OnClickedExit()
        {
            SceneManager.LoadScene("Lobby");
        }

        public void OnClickedGainCoin()
        {
            RefactoringStaticPlayManager.GainCoin();
            UpdateCoin();
        }

        public void OnClickedLooseCoin()
        {
            RefactoringStaticPlayManager.LooseCoin();
            UpdateCoin();
        }

        private void UpdateCoin()
        {
            coinText.text = string.Format("{0}", RefactoringStaticPlayManager.Coin);
        }
    }
}