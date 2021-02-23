namespace MVC
{
    public interface IObservableModle
    {
    }

    public interface ModelObserverable<T> where T : IObservableModle
    {
        void OnChanged(T model);
    }
    
    public class SimpleShopModel : IObservableModle
    {
        public ShopTab SelectedTab { get; private set; }
        private ModelObserverable<SimpleShopModel> observer = null;

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

        public SimpleShopModel(ModelObserverable<SimpleShopModel> observer)
        {
            this.observer = observer;
            ChangeShopTab(SelectedTab);
        }

        public void ChangeShopTab(ShopTab clickedShopTab)
        {
            SelectedTab = clickedShopTab;
            observer.OnChanged(this);
        }
    }
}