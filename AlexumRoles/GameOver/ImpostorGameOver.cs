using MiraAPI.GameEnd;
using MiraAPI.Utilities;
using UnityEngine;
using System.Collections.Generic;
using Reactor.Utilities;
using System.Linq;
using AlexumRoles.Roles;

namespace AlexumRoles.GameOver;

public class ImpostorGameOver : CustomGameOver
{
    public override bool VerifyCondition(PlayerControl playerControl, NetworkedPlayerInfo[] winners)
    {
        if (winners == null || winners.Length == 0) return false;

        foreach (var p in winners)
        {
            if (p.Role.IsImpostor)
                return true;
        }

        return false;
    }

    public override void AfterEndGameSetup(EndGameManager endGameManager)
    {
        endGameManager.WinText.text = "Impostors Wins!";
        endGameManager.WinText.color = Color.red;
        endGameManager.BackgroundBar.material.SetColor(ShaderID.Color, Color.cyan);
    }
}
