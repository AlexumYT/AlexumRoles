using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Modifiers;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using MiraAPI.Patches;
using MiraAPI.Networking;
using Rewired;
using UnityEngine;
using System.Collections;
using BepInEx.Unity.IL2CPP.Utils;
using AlexumRoles.Roles.Crewmate;

namespace AlexumRoles.Buttons.Crewmate
{
    public class SelfSacrificeButton : CustomActionButton<DeadBody>
    {
        public override string Name => "Sacrifice";

        public override float Cooldown => 30f; // tweak if you want

        public override int MaxUses => -1;

        public override LoadableAsset<Sprite> Sprite => AlexumAssets.SheriffKillButton; // replace with your own asset if you want

        public override KeyboardKeyCode Defaultkeybind => KeyboardKeyCode.K;

        public override ButtonLocation Location => ButtonLocation.BottomRight;

        public override ModifierKey Modifier1 => ModifierKey.Control;

        private DeadBody bodyTarget;

        protected override void OnClick()
        {
            if (bodyTarget == null) return;

            // Kill yourself
            PlayerControl.LocalPlayer.RpcCustomMurder(PlayerControl.LocalPlayer);

            // Start coroutine to check and revive after 5s
            HudManager.Instance.StartCoroutine(ReviveRoutine(bodyTarget));
        }

        private IEnumerator ReviveRoutine(DeadBody targetBody)
        {
            yield return new WaitForSeconds(5f);

            if (targetBody != null && targetBody.gameObject != null)
            {
                PlayerControl deadPlayer = GameData.Instance.GetPlayerById(targetBody.ParentId).Object;
                if (deadPlayer != null && deadPlayer.Data.IsDead)
                {
                    deadPlayer.Revive(); // Assuming MiraAPI or your mod has a revive function
                    targetBody.gameObject.SetActive(false);
                }
            }
        }

        public override DeadBody GetTarget()
        {
            // Find nearest dead body instead of player
            bodyTarget = PlayerControl.LocalPlayer.GetNearestDeadBody(Distance);
            return bodyTarget;
        }

        public override void SetOutline(bool active)
        {
            if (bodyTarget != null)
            {
                bodyTarget.GetComponent<SpriteRenderer>()?.material.SetColor("_OutlineColor", active ? Color.yellow : Color.clear);
            }
        }

        public override bool IsTargetValid(DeadBody target)
        {
            return target != null;
        }

        public override bool Enabled(RoleBehaviour role)
        {
            return role is AltruistRole;
        }
    }
}
