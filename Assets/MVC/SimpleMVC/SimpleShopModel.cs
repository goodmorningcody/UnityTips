namespace MVC
{
    public interface IObservableGetter
    {
    }
    

    public interface ModelObserverable<T> where T : IObservableGetter
    {
        void OnChanged(T modelGetter);
    }

    public interface SimpleShopModelGetter : IObservableGetter
    {
        ShopTab SelectedTab { get; }
        string ShopTitle { get; }
    }
    
    public class SimpleShopModel : IObservableGetter, SimpleShopModelGetter
    {
        public ShopTab SelectedTab { get; private set; }
        private ModelObserverable<SimpleShopModelGetter> observer = null;

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

        public SimpleShopModel(ModelObserverable<SimpleShopModelGetter> observer)
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