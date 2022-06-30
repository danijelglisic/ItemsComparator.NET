using ItemsComapring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsComapring.Repositories
{
    public interface IItemRepository
    {
        List<Item> GetAllItems();
        List<ItemsCombination> GetAllCombinations();
        CompareModel CompareItems(CompareModel comparedItems);
        CompareModel GetNextCombination();
        List<Item> GetListItems();
        List<ItemsCombination> GetListCombinations();
    }
}
