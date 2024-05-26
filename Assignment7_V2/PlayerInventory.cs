using Assignment7_V2.Enumerations;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Assignment7_V2;

class PlayerInventory
{
    #region ----- PROPERTIES
    /// <summary>A list of items currently in the players inventory</summary>
    public List<Items> Inventory { get => inventory; set => inventory = value; }
    #endregion

    #region ----- FIELDS
    private List<Items> inventory;
    #endregion

    #region ----- CONSTRUCTOR
    /// <summary>Default Constructor</summary>
    public PlayerInventory(bool cheat = false)
    {
        inventory = [];

        if (cheat)
        {
            Cheat();
            return;
        }

        AddItem(QuestItems.Rubber_Duck);
        AddItem(QuestItems.Snake_Skin);
        AddItem(QuestItems.Rusty_Key);
    }
    #endregion

    #region ----- METHODS
    /// <summary>Constructs and adds Item(s) to player inventory</summary>
    /// <param name="item">Input QuestItem corresponding to created item</param>
    public void AddItem(QuestItems item)
    {
        Items newItem = new Items(item);
        inventory.Add(newItem);
    }

    /// <summary>Destroys an item upon using it from player inventory</summary>
    /// <param name="items"></param>
    public void DeleteItem(QuestItems qitem)
    {
        int i = 0;

        foreach (Items item in inventory) // itterates through inventory
        {
            if (item.Name == qitem) // if match
            {
                inventory.RemoveAt(i);
                break;
            }
            i++;
        }
    }

    /// <summary>Returns an item from players inventory</summary>
    /// <param name="qItem">coresponding quest item of item to be found</param>
    public Items GetItemFromQuestItem(QuestItems qItem)
    {
        Items newItem = null;
        foreach (Items item in inventory)
        {
            if (item.Name == qItem)
            {
                newItem = item;
                break;
            }
        }

        return newItem;
    }

    /// <summary>Checks if players inventory contains item</summary>
    /// <param name="qitem">coresponding quest item of item to be found</param>
    /// <returns>true - if found</returns>
    public bool OwnedCheck(QuestItems qitem)
    {
        bool found = false;

        foreach (Items item in inventory)
        {
            if (item.Name == qitem)
            {
                found = true;
                break;
            }
        }
        return found;
    }

    /// <summary>Attempts to get interactions for an item at a location</summary>
    /// <param name="item">input item</param>
    /// <param name="location">location is where the player is currently targeting</param>
    /// <returns>An array of interactions, otherwise an array containing an errorinteraction if no or null interactions</returns>
    public static Interactions?[] GetInteractions(Items item, Point? location)
    {
        if (item.TargetLocation is null || location is null) // the targetlocation current menu items target location
            return [Interactions.ErrorMessage]; // returns an array indicating to display item's error message

        List<Interactions?> interactionsList = []; // a temporary list to simplify readability and returning *

        int i = 0;
        foreach (Interactions interaction in item.Interaction) // itterates input item interactions
        {
            if (item.TargetLocation == location) // and adds them to the list if if matching locations
                interactionsList.Add(item.Interaction[i]);

            i++;
        }

        if (interactionsList.Count == 0) // also if no interactions
            return [Interactions.ErrorMessage]; // returns an array indicating to display item's error message

        return [.. interactionsList]; // finally, if there are interactions * returns them as an array
    }

    /// <summary>Attempts to find an item in players inventory</summary>
    /// <param name="atLocation">Current menu location</param>
    /// <returns>True and the item if found</returns>
    public Tuple<bool, Items> FindInventoryItemFromPoint(Point atLocation)
    {
        bool findItem = false;
        Items itemx = new(0);

        foreach (Items item in inventory)
        {
            if (item.InventoryLocation == atLocation)
            {
                findItem = true;
                itemx = item;
                break;
            }
        }
        return new Tuple<bool, Items>(findItem, itemx);
    }
    #endregion

    #region ----- CHEATS/DECOMMENTED ----- ENABLE IN DEFAULT CONSTRUCTOR
    /// <summary>For testing purpose only, adds all items to inventory</summary>
    public void Cheat()
    {
        //↑↑↓↓←→←→ba(select)start
        int count = Enum.GetNames(typeof(QuestItems)).Length;

        for (int i = 0; i < count; i++)
        {
            AddItem((QuestItems)i);
        }
    }
    #endregion
}