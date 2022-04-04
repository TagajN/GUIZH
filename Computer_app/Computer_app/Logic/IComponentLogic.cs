using Computer_app.Models;
using System.Collections.Generic;

namespace Computer_app.Logic
{
    public interface IComponentLogic
    {
        double AllCost { get; }

        void AddToBasket(ComponentAsset componentAsset);
        void Invoice(IList<ComponentAsset> basket);
        void RemoveFromBasket(ComponentAsset componentAsset);
        void SetupCollections(IList<ComponentAsset> storage, IList<ComponentAsset> basket);
        double UpdatePrice(ComponentAsset componentAsset);
    }
}