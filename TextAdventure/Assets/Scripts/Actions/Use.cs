using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action
{
    public override void RespondToInput(GameControler controller, string noun)
    {
        ///checks items in room
        if (UseItems(controller, controller.player.currentLocation.items, noun))
            return;

        ///checks item in inventory
        if (UseItems(controller, controller.player.inventory, noun))
            return;


        controller.currentText.text = "Nothing happens ";
    }
    private bool UseItems(GameControler controller, List<Items> items, string noun)
    {
        foreach (Items item in items)
        {
            if (item.itemName == noun)
            {
                if(controller.player.CanUseItem(controller, item))
                {
                    return true;
                }
                if (item.InteractionWith(controller, "use", noun))
                {
                    return true;
                }
                controller.currentText.text = "There is nothing interesting about the " + noun;
                return true;
            }
        }
        return false;
    }

}
