using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameControler controller, string verb)
    {
        controller.currentText.text = "Type a verb followed by a noun: ";
        controller.currentText.text += "\nAllowed verbs: \nGo, Examine, Get, Use, TalkTo, Give, Inventory, Say";
    }
}

