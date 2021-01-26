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
            coinText.text = string.Format("{0}", Refactoring3UserInfoManager.Coin);
        }

        public void OnClickedNormalDungeon()
        {
            SceneManager.LoadScene("Game");
            selectedDungenType = DungenType.Normal;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void OnClickedEventDungeon()
        {
            SceneManager.LoadScene("Game");
            selectedDungenType = DungenType.Event;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            var game = FindObjectOfType<RefactoringGame>();
            game.OnStartGame(selectedDungenType);
        }
    }
}