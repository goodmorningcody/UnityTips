using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SingletonDemo
{
    public class Lobby : MonoBehaviour
    {
        [SerializeField] private Text coinText = null;

        void Awake()
        {
            coinText.text = string.Format("{0}", PlayManager.GetInstance().coin);
        }

        public void OnClickedNormalDungeon()
        {
            SceneManager.LoadScene("Game");
            PlayManager.GetInstance().dungenType = DungenType.Normal;
        }

        public void OnClickedEventDungeon()
        {
            SceneManager.LoadScene("Game");
            PlayManager.GetInstance().dungenType = DungenType.Event;
        }
    }
}