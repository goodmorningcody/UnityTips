using SingletonDemo;

namespace RefactoringSingletonDemo
{
    // static class
    public static class RefactoringStaticPlayManager
    {
        private static int _coin;
        private static int CoinChangeAmount => (dungenType == DungenType.Normal ? 1 : UnityEngine.Random.Range(1, 100));
        public static int Coin => _coin;
        public static DungenType dungenType { private get; set; }

        public static void GainCoin()
        {
            _coin += CoinChangeAmount;
        }

        public static void LooseCoin()
        {
            _coin -= CoinChangeAmount;
        }
    }
}