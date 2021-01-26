namespace RefactoringSingletonDemo
{
    // small class
    public static class RefactoringUserInfoManager
    {
        private static int _coin;
        public static int Coin => _coin;

        public static void UpdateCoin(int amount)
        {
            _coin += amount;
            if ( _coin < 0 )
            {
                _coin = 0;
            }
        }
    }
}