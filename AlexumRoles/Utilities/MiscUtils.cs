using AlexumRoles.Roles;
using MiraAPI.GameOptions;
using MiraAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using AlexumRoles.Extensions;

namespace AlexumRoles.Utilities;
public static class MiscUtils
{
    public static int KillersAliveCount => Helpers.GetAlivePlayers().Count(x =>
        x.Data.Role.IsImpostor ||
        x.Data.Role.CheckIsNeutralKilling());

    public static int RealKillersAliveCount => Helpers.GetAlivePlayers().Count(x =>
        x.Data.Role.IsImpostor ||
        x.Data.Role.CheckIsNeutralKilling());

    public static int NKillersAliveCount => Helpers.GetAlivePlayers().Count(x =>
        x.Data.Role.CheckIsNeutralKilling());

    public static int NonImpKillersAliveCount => Helpers.GetAlivePlayers().Count(x =>
        x.Data.Role.CheckIsNeutralKilling() ||
        x.Data.Role is IAlexumCrewRole { IsPowerCrew: true });

    public static int ImpAliveCount => Helpers.GetAlivePlayers().Count(x =>
        x.Data.Role.IsImpostor);

    public static int CrewKillersAliveCount => Helpers.GetAlivePlayers().Count(x =>
        x.Data.Role is IAlexumCrewRole { IsPowerCrew: true });

    public static T? GetRole<T>() where T : RoleBehaviour
    {
        return PlayerControl.AllPlayerControls.ToArray().ToList().Find(x => x.Data.Role is T)?.Data?.Role as T;
    }

    public static bool StartsWithVowel(this string word)
    {
        var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
        return vowels.Any(vowel => word.StartsWith(vowel.ToString(), StringComparison.OrdinalIgnoreCase));
    }

    public static List<PlayerControl> GetCrewmates(List<PlayerControl> impostors)
    {
        return PlayerControl.AllPlayerControls.ToArray()
            .Where(player => impostors.All(imp => imp.PlayerId != player.PlayerId)).ToList();
    }

    public static List<PlayerControl> GetImpostors(List<NetworkedPlayerInfo> infected)
    {
        return infected.Select(impData => impData.Object).ToList();
    }
}
