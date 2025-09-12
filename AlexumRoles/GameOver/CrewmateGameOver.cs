using MiraAPI.GameEnd;
using MiraAPI.Utilities;
using UnityEngine;
using System.Collections.Generic;
using Reactor.Utilities;
using System.Linq;
using AlexumRoles.Roles;

namespace AlexumRoles.GameOver;

public class CrewmateGameOver : CustomGameOver
{
    public override bool VerifyCondition(PlayerControl playerControl, NetworkedPlayerInfo[] winners)
    {
        if (winners == null || winners.Length == 0) return false;

        foreach (var p in winners)
        {
            if (p.Role is IAlexumCrewRole)
                return true;
        }

        return false;
    }

    public override void AfterEndGameSetup(EndGameManager endGameManager)
    {
        endGameManager.WinText.text = "Crewmates Wins!";
        endGameManager.WinText.color = Color.cyan;
        endGameManager.BackgroundBar.material.SetColor(ShaderID.Color, Color.cyan);
    }
}
