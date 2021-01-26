using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SingletonDemo;

namespace RefactoringSingletonDemo
{
    public class RefactoringLobby : MonoBehaviour
    {
        [SerializeField] private Text coinText = null;
        private DungenType selectedDungenType;

        void Awake()
        {
            coinText.text = string.Format("{0}개", RefactoringUserInfoManager.Coin);
        }

        public void OnClickedNormalDungeon()
        {
            
            selectedDungenType = DungenType.Normal;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("Game");
        }

        public void OnClickedEventDungeon()
        {
            selectedDungenType = DungenType.Event;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("Game");
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            var game = FindObjectOfType<RefactoringGame>();
            game.OnStartGame(selectedDungenType);
        }
    }
}