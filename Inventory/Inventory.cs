using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Technica.Inventory
{
    [System.Serializable]
    public class Inventory : MonoBehaviour
    {
        public int InventorySize;
        public int MaxStackSize;
        public int[,] Items;

        public bool Setup()
        {
            Items = new int[InventorySize, MaxStackSize];
            return true;
        }

        public bool AddItem(int ItemID, int ItemAmount)
        {
            for (int i = 0; i < InventorySize; i++)
            {
                // Found match for existing item
                if(Items[i, 0] == ItemID)
                {
                    // Check if we still have space to add an item
                    for (int j = 0; j < MaxStackSize; j++)
                    {
                        // If we found an emtpy spot, add the amount of items
                        if(Items[i, j] != 0)
                        {
                            AddAmountOfItemsToArray(ItemID, ItemAmount);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                // Check if there is not an existing item that's different than the item we try to add
                else if(Items[i, 0] == 0)
                {
                    continue;
                }
                
                // Add the item on an empty spot
                else
                {
                    AddAmountOfItemsToArray(ItemID, ItemAmount);
                }
                
            }
            return true;
        }

        private void AddAmountOfItemsToArray(int ItemID, int ItemAmount)
        {

        }
       
        public bool RemoveItem()
        {
            return true;
        }
    }
}
