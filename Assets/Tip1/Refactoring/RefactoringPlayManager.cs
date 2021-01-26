using SingletonDemo;

namespace RefactoringSingletonDemo
{
    // singleton with generic
    public class RefactoringPlayManager : Singleton<RefactoringPlayManager>
    {
        private int _coin;
        private int CoinChangeAmount => (dungenType == DungenType.Normal ? 1 : UnityEngine.Random.Range(1, 100));
        public int Coin => _coin;
        public DungenType dungenType { private get; set; }

        public void GainCoin()
        {
            _coin += CoinChangeAmount;
        }

        public void LooseCoin()
        {
            _coin -= CoinChangeAmount;
        }
    }
}