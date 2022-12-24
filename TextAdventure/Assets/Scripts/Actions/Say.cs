using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Say")]
public class Say : Action
{
    public override void RespondToInput(GameControler controller, string noun)
    {
        if (SayToItem(controller, controller.player.currentLocation.items, noun))
            return;

        controller.currentText.text = "Nothing responds!";
    }

    private bool SayToItem(GameControler controller, List<Items> items, string noun)
    {
        foreach(Items item in items)
        {
            if (item.itemEnabled)
            {
                if (controller.player.CanTalkToItem(controller, item))
                {
                    if(item.InteractionWith(controller, "say", noun))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

}
