namespace OOPWithGeneric
{
    public class FishingRodGadget : IFishingGadget
    {
        private string itemName = null;
        private int price;
        public string ItemName => itemName;
        public int Price => price;
    }
}