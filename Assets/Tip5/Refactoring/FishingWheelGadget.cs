namespace OOPWithGeneric
{
    public class FishingWheelGadget : IFishingGadget
    {
        private string itemName = null;
        private int price;
        public string ItemName => itemName;
        public int Price => price;
    }

    public class FishingMotorWheelGadget : FishingWheelGadget
    {
        public new string ItemName => "전동릴";
        public new int Price => 100;
        public void AutoReeling()
        {
        }
    }

    public class FishingLureGadget : IFishingGadget
    {
        private string itemName = null;
        private int price;
        public string ItemName => itemName;
        public int Price => price;
    }
}