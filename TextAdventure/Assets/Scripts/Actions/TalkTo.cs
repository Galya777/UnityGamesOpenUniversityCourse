using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TalkTo")]
public class TalkTo : Action
{
    public override void RespondToInput(GameControler controller, string noun)
    {
        if (TalkToItem(controller, controller.player.currentLocation.items, noun))
            return;

        controller.currentText.text = "There is no "+noun+" here!";
    }

    private bool TalkToItem(GameControler controller, List<Items> items, string noun)
    {
        foreach (Items item in items)
        {
            if (item.itemName == noun && item.itemEnabled)
            {
                if (controller.player.CanTalkToItem(controller, item))
                {
                    return true;
                }
                if (item.InteractionWith(controller, "talkto", noun))
                {
                    return true;
                }
                controller.currentText.text = noun+" not responding!";
                return true;
            }
        }
        return false;
    }
}