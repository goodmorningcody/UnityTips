using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SingletonDemo;

namespace RefactoringSingletonDemo
{
    public class RefactoringGame : MonoBehaviour
    {        
        [SerializeField] private Text coinText = null;
        private DungenType playingDungenType;
        private int CoinChangeAmount => playingDungenType == DungenType.Normal ? 1 : Random.Range(1, 100);
        private string CointCountText => string.Format("{0}개", RefactoringUserInfoManager.Coin);

        public void OnStartGame(DungenType dungenType)
        {
            playingDungenType = dungenType;
            coinText.text = CointCountText;
        }

        public void OnClickedExit()
        {
            SceneManager.LoadScene("Lobby");
        }

        public void OnClickedGainCoin()
        {
            UpdateCoin(CoinChangeAmount);
        }

        public void OnClickedLooseCoin()
        {
            UpdateCoin(CoinChangeAmount * -1);
        }

        private void UpdateCoin(int coinAmount)
        {
            RefactoringUserInfoManager.UpdateCoin(coinAmount);
            coinText.text = CointCountText;
        }
    }
}