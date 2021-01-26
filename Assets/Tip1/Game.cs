using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            PlayManager.GetInstance().GainCoin();
            UpdateCoin();
        }

        public void OnClickedLooseCoin()
        {
            PlayManager.GetInstance().LooseCoin();
            UpdateCoin();
        }

        private void UpdateCoin()
        {
            coinText.text = string.Format("{0}", PlayManager.GetInstance().coin);
        }
    }
}