using MiraAPI.GameEnd;
using MiraAPI.Utilities;
using UnityEngine;
using System.Collections.Generic;
using Reactor.Utilities;
using System.Linq;
using AlexumRoles.Roles.Neutral;

namespace AlexumRoles.GameOver;

public class JackalGameOver : CustomGameOver
{
    public override bool VerifyCondition(PlayerControl playerControl, NetworkedPlayerInfo[] winners)
    {
        if (winners == null || winners.Length == 0) return false;

        // Check if any winner is Jackal or Sidekick
        foreach (var p in winners)
        {
            if (p.Role is JackalRole || p.Role is SidekickRole)
                return true;
        }

        return false;
    }

    public override void AfterEndGameSetup(EndGameManager endGameManager)
    {
        // Display Jackal victory UI
        endGameManager.WinText.text = "Jackal Wins!";
        endGameManager.WinText.color = Color.cyan;
        endGameManager.BackgroundBar.material.SetColor(ShaderID.Color, Color.cyan);

        foreach (var p in PlayerControl.AllPlayerControls)
        {
            if (p.Data.Role is SidekickRole)
            {
                endGameManager.WinText.text = "Jackal & Sidekick Wins!";
                break;
            }
        }
    }
}
