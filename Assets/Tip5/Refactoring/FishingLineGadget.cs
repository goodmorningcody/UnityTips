namespace OOPWithGeneric
{
    public class FishingLineGadget : IFishingGadget
    {
        private string itemName = null;
        private int price;
        public string ItemName => itemName;
        public int Price => price;
    }
}