using AlexumRoles.Roles.Neutral;
using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.GameEnd;
using AlexumRoles.GameOver;
using UnityEngine;
using System.Collections.Generic;
using MiraAPI.Roles;
using AmongUs.GameOptions;
using AlexumRoles.Roles;
using AlexumRoles.Utilities;
using AlexumRoles.Extensions;

namespace AlexumRoles
{
    public static class EventHandler
    {
        public static void Initialize()
        {
            MiraEventManager.RegisterEventHandler<AfterMurderEvent>(@event =>
            {
                CheckJackalWin();
                CheckDefaultWin();
                CheckOrphanSidekick(@event.Target);
            });
        }

        public static void CheckOrphanSidekick(PlayerControl player)
        {
            if (player == null) return;

            if (player.Data.Role is JackalRole)
            {
                foreach (var p in PlayerControl.AllPlayerControls)
                {
                    if (p.Data.Role is SidekickRole && !p.Data.IsDead)
                    {
                        p.RpcSetRole((RoleTypes)RoleId.Get<JackalRole>(), true);
                        break;
                    }
                }
            }
        }

        public static void CheckJackalWin()
        {
            var aliveJackals = new List<PlayerControl>();
            var aliveImpostors = new List<PlayerControl>();
            var aliveOthers = new List<PlayerControl>();

            foreach (var p in PlayerControl.AllPlayerControls)
            {
                if (p == null || p.Data.IsDead) continue;

                if (p.Data.Role is JackalRole)
                {
                    aliveJackals.Add(p);
                }
                else if (p.Data.Role.IsImpostor)
                {
                    aliveImpostors.Add(p);
                    aliveOthers.Add(p);
                }
                else
                {
                    aliveOthers.Add(p);
                }
            }

            // Jackal wins if at least one Jackal is alive,
            // all impostors are dead,
            // and Jackals outnumber everyone else
            if (aliveJackals.Count > 0 &&
                aliveImpostors.Count == 0 &&
                aliveJackals.Count >= aliveOthers.Count)
            {
                CustomGameOver.Trigger<JackalGameOver>(aliveJackals.ConvertAll(p => p.Data));
            }
        }

        public static void CheckDefaultWin()
        {
            var aliveImpostors = new List<PlayerControl>();
            var aliveCrew = new List<PlayerControl>();

            foreach (var p in PlayerControl.AllPlayerControls)
            {
                if (p == null || p.Data.IsDead) continue;

                if (p.Data.Role.IsImpostor)
                    aliveImpostors.Add(p);
                else if (!p.Data.Role.IsNeutral())
                    aliveCrew.Add(p);
            }

            // Impostor win: crew all dead or equal numbers
            if (aliveImpostors.Count > 0 && aliveImpostors.Count >= aliveCrew.Count && MiscUtils.NKillersAliveCount == 0)
            {
                CustomGameOver.Trigger<ImpostorGameOver>(aliveImpostors.ConvertAll(p => p.Data));
                return;
            }

            // Crew win: impostors all dead
            if (aliveImpostors.Count == 0 && MiscUtils.NKillersAliveCount == 0 && aliveCrew.Count > 0)
            {
                CustomGameOver.Trigger<CrewmateGameOver>(aliveCrew.ConvertAll(p => p.Data));
            }
        }
    }
}
