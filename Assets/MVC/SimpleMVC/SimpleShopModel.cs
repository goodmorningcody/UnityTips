namespace MVC
{
    public interface ShopModelChangeListener
    {
        void OnChangedShopModel(SimpleShopModel model);
    }
    
    public class SimpleShopModel
    {
        public ShopTab SelectedTab { get; private set; }
        private ShopModelChangeListener listener = null;

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

        public SimpleShopModel(ShopModelChangeListener listener)
        {
            this.listener = listener;
            ChangeShopTab(SelectedTab);
        }

        public void ChangeShopTab(ShopTab clickedShopTab)
        {
            SelectedTab = clickedShopTab;
            listener.OnChangedShopModel(this);
        }
    }
}