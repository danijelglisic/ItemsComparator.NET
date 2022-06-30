using ItemsComapring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsComapring.Repositories
{
    public class ItemRepository : IItemRepository
    {
        List<Item> ItemsList { get; set; }
        List<ItemsCombination> CombinstionsList { get; set; }

        public ItemRepository()
        {
            this.ItemsList = GetListItems();
            this.CombinstionsList = GetListCombinations();
        }

        public List<Item> GetListItems()
        {
            return new List<Item>()
            {
                new Item() { Position = 1, Name = "Item1", Score = 0 },
                new Item() { Position = 2, Name = "Item2", Score = 0 },
                new Item() { Position = 3, Name = "Item3", Score = 0 },
                new Item() { Position = 4, Name = "Item4", Score = 0 },
                new Item() { Position = 5, Name = "Item5", Score = 0 },
                new Item() { Position = 6, Name = "Item6", Score = 0 }
            };
        }

        public List<ItemsCombination> GetListCombinations()
        {
            return new List<ItemsCombination>()
            {
                new ItemsCombination(1, "Item1", 0, 2, "Item2", 0),
                new ItemsCombination(1, "Item1", 0, 3, "Item3", 0),
                new ItemsCombination(1, "Item1", 0, 4, "Item4", 0),
                new ItemsCombination(1, "Item1", 0, 5, "Item5", 0),
                new ItemsCombination(1, "Item1", 0, 6, "Item6", 0),
                new ItemsCombination(2, "Item2", 0, 3, "Item3", 0),
                new ItemsCombination(2, "Item2", 0, 4, "Item4", 0),
                new ItemsCombination(2, "Item2", 0, 5, "Item5", 0),
                new ItemsCombination(2, "Item2", 0, 6, "Item6", 0),
                new ItemsCombination(3, "Item3", 0, 5, "Item5", 0),
                new ItemsCombination(3, "Item3", 0, 6, "Item6", 0),
                new ItemsCombination(3, "Item3", 0, 4, "Item4", 0),
                new ItemsCombination(4, "Item4", 0, 5, "Item5", 0),
                new ItemsCombination(4, "Item4", 0, 6, "Item6", 0),
                new ItemsCombination(5, "Item5", 0, 6, "Item6", 0)
            };
        }

        public CompareModel CompareItems(CompareModel comparedItems)
        {
            if (comparedItems != null)
            {
                if (comparedItems.Value1.GetType() == typeof(int) &&
                    comparedItems.Value2.GetType() == typeof(int))
                {
                    int indexOfCombination = 0;
                    bool founded = false;
                    for (int i = 0; i < this.CombinstionsList.Count(); i++)
                    {
                        if (String.Equals(this.CombinstionsList[i].Name1, comparedItems.Name1) &&
                            String.Equals(this.CombinstionsList[i].Name2, comparedItems.Name2))
                        {
                            indexOfCombination = i;
                            founded = true;
                            Item item = new Item();

                            if (comparedItems.Value1 > comparedItems.Value2)
                            {
                                item.Name = comparedItems.Name1;
                                var indexOfItem = this.ItemsList.FindIndex(x => x.Name == item.Name);
                                this.ItemsList[indexOfItem].Score++;
                            }
                            else if (comparedItems.Value1 < comparedItems.Value2)
                            {
                                item.Name = comparedItems.Name2;
                                var indexOfItem = this.ItemsList.FindIndex(x => x.Name == item.Name);
                                this.ItemsList[indexOfItem].Score++;

                            }

                            this.ItemsList = this.ItemsList.OrderByDescending(x => x.Score).ToList();

                            int position = 0;

                            foreach (var itm in this.ItemsList)
                            {
                                itm.Position = ++position;
                            }

                            break;
                        }
                    }
                    if (founded)
                    {
                        this.CombinstionsList.RemoveAt(indexOfCombination);
                    }
                }
                return GetNextCombination();
            }

            return null;
        }

        public List<ItemsCombination> GetAllCombinations()
        {
            return this.CombinstionsList;
        }

        public List<Item> GetAllItems()
        {
            this.ItemsList = this.ItemsList.OrderByDescending(x => x.Score).ToList();

            int position = 0;

            foreach (var itm in this.ItemsList)
            {
                itm.Position = ++position;
            }

            return this.ItemsList;
        }

        public CompareModel GetNextCombination()
        {
            if (this.CombinstionsList.Count() > 0)
            {
                CompareModel compareModel = new CompareModel();

                Random random = new Random();
                int indexComaringItems = random.Next(0, this.CombinstionsList.Count() - 1);

                compareModel.Name1 = this.CombinstionsList[indexComaringItems].Name1;
                compareModel.Name2 = this.CombinstionsList[indexComaringItems].Name2;
                compareModel.Position1 = this.CombinstionsList[indexComaringItems].Position1;
                compareModel.Position2 = this.CombinstionsList[indexComaringItems].Position2;
                compareModel.Score1 = this.CombinstionsList[indexComaringItems].Score1;
                compareModel.Score2 = this.CombinstionsList[indexComaringItems].Score2;

                return compareModel;
            }

            return new CompareModel
            {
                Name1 = "No name",
                Name2 = "No name",
                Position1 = 0,
                Position2 = 0,
                Score1 = 0,
                Score2 = 0
            };
        }
    }
}
