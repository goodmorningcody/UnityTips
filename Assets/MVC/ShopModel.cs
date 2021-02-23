namespace MVC
{
    public enum ShopTab
    {
        Wheel,
        Line,
        Rod,
    }

    public struct ChangedShopModelEvent : IEvent
    {
    }

    public class ShopModel : Observable
    {
        public ShopTab SelectedTab { get; private set; }

        public string ShopTitle
        {
            get
            {
                switch( SelectedTab )
                {
                    case ShopTab.Wheel:
                        return "낚시릴 상점";
                    case ShopTab.Line:
                        return "낚시줄 상점";
                    case ShopTab.Rod:
                        return "낚싯대 상점";
                    default:
                        throw new System.NotImplementedException();
                }
            }
        }

        public ShopModel()
        {
            SelectedTab = ShopTab.Wheel;
        }

        public void ChangedShopTab(ShopTab clickedShopTab)
        {
            SelectedTab = clickedShopTab;
            SendMessage(new EventPayload(new ChangedShopModelEvent()));
        }
    }
}