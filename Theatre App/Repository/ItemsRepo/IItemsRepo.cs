using Theatre_App.Models;

namespace Theatre_App.Repository.ItemsRepo
{
    public interface IItemsRepo
    {
        List<Items> GetItems();
        Items addItem(Items item);
        Items updateItem(Items item);
        Items deleteItem(Items item);


    }
}
