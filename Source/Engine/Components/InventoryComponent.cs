using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using SadConsole.Components;
using SimpleSpaceRogue.Source.Engine.Actors.Items;
using SimpleSpaceRogue.Source.Engine.Actors;

namespace SimpleSpaceRogue.Source.Engine.Components
{
    class InventoryComponent : LogicConsoleComponent
    {
        private int inventorySize;
        private List<Actor> itemList;

        public InventoryComponent()
        {
            inventorySize = 4;
            itemList = new List<Actor>();
            itemList.Capacity = inventorySize;
        }
        public override void Draw(SadConsole.Console console, TimeSpan delta)
        {
            
        }

        public override void Update(SadConsole.Console console, TimeSpan delta)
        {

        }

        public bool AddItemToInventory(Actor itemToAdd)
        {
            if (itemList.Count >= inventorySize)
            {
                //Inventory is full
                return false;
            }
            else
            {
                itemList.Add(itemToAdd);
                return true;
            }
        }

        public bool RemoveItemFromInventory(Actor itemToRemove)
        {
            if (itemList.Count <= 0)
            {
                // Inventory is empty
                return false;
            }
            else 
            {
                itemList.Remove(itemToRemove);
                return true;
            }
        }
    }
}
