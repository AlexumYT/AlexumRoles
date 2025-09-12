using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI.PluginLoading;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using MiraAPI;
using Reactor.Utilities;
using AlexumRoles.Buttons;
using MiraAPI.Hud;
using AlexumRoles.GameOver;
using MiraAPI.GameEnd;

namespace AlexumRoles;

[BepInAutoPlugin("alexum.alexumroles", "AlexumRoles")]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(MiraApiPlugin.Id)]
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public partial class AlexumRolesPlugin : BasePlugin, IMiraPlugin
{
    public Harmony Harmony { get; } = new(Id);
    public string OptionsTitleText => "Alexum\nAlexum Roles";
    public ConfigFile GetConfigFile() => Config;
    public override void Load()
    {
        ReactorCredits.Register("Alexum Roles", Version, false, ReactorCredits.AlwaysShow);
        Harmony.PatchAll();
        EventHandler.Initialize();
        Logger<AlexumRolesPlugin>.Message("Alexum Roles Loaded");

        foreach (var res in typeof(AlexumAssets).Assembly.GetManifestResourceNames())
        {
            Logger<AlexumRolesPlugin>.Info("[Resource] " + res);
        }
    }
}