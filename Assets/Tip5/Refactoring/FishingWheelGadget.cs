namespace OOPWithGeneric
{
    public class FishingWheelGadget : IFishingGadget
    {
        private string itemName = null;
        private int price;
        public string ItemName => itemName;
        public int Price => price;
    }
}