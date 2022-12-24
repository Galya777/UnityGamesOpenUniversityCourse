using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currentLocation;

    public List<Items> inventory = new List<Items>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeLocation(GameControler controller, string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);

        if(connection != null) {
            if (connection.connectionEnable)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    internal bool CanUseItem(GameControler controller, Items item)
    {
        if (item.target == null)
            return true;

        if (HasItem(item.target))
        {
            return true;
        }   
        if (currentLocation.HasItem(item.target))
           return true;

        return false;
    }
    internal bool CanTalkToItem (GameControler controller, Items item)
    {
        return item.playerCanTalk;
    }
    internal bool CanGiveToItem(GameControler controller, Items item)
    {
        return item.playerCanGive;
    }
    internal bool CanReadItem(GameControler controller, Items item)
    {
        return item.playerCanRead;
    }
    private bool HasItem(Items itemToCheck)
    {
        foreach(Items item in inventory)
        {
            if (item == itemToCheck && item.itemEnabled)
                return true;

        
        }
        return false;
    }

    public bool HasByItemName(string noun)
    {
        foreach(Items item in inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower() && item.itemEnabled)
                return true;

        }
        return false;
    }

    public void Teleport(GameControler controler, Location destination)
    {
        currentLocation= destination;
    }
}
