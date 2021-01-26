namespace RefactoringSingletonDemo
{
    // small class
    public static class Refactoring3UserInfoManager
    {
        private static int _coin;
        public static int Coin => _coin;

        public static void UpdateCoin(int amount)
        {
            _coin += amount;
        }
    }
}