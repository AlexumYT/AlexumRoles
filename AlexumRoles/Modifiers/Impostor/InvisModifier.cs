using Il2CppSystem;
using MiraAPI.Modifiers.Types;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Reactor.Utilities;

namespace AlexumRoles.Modifiers;

public class InvisModifier : TimedModifier
{
    private bool _shouldHide = false;

    public override string ModifierName => "Invised";
    public override bool HideOnUi => true;
    public override float Duration => 15f;
    public override bool AutoStart => true;
    public override bool RemoveOnComplete => true;

    private Dictionary<SpriteRenderer, Color> _originalColors = new();
    private Color _originalNameColor;
    private Color _originalCBTextColor;

    public override void OnActivate()
    {
        if (Player.AmOwner)
        {
            _shouldHide = true;

            foreach (var cosmetic in Player.cosmetics.transform.GetComponentsInChildren<SpriteRenderer>(true))
            {
                _originalColors[cosmetic] = cosmetic.color;
            }

            var rend = Player.cosmetics.currentBodySprite.BodySprite;
            _originalColors[rend] = rend.color;

            _originalNameColor = Player.cosmetics.nameText.color;
            _originalCBTextColor = Player.cosmetics.colorBlindText.color;

            var pet = Player.GetPet();
            if (pet != null)
            {
                foreach (var petRend in pet.GetComponentsInChildren<SpriteRenderer>(true))
                {
                    _originalColors[petRend] = petRend.color;
                }
            }
            else
            {
                Logger<AlexumRolesPlugin>.Info("No Pet Found");
            }
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (!Player || !_shouldHide)
            return;

        // Fully hide body, cosmetics, and name text
        var rend = Player.cosmetics.currentBodySprite.BodySprite;
        var tmp = Player.cosmetics.nameText;
        var cbtmp = Player.cosmetics.colorBlindText;

        tmp.color = Color.Lerp(tmp.color, new Color(tmp.color.r, tmp.color.g, tmp.color.b, 0f), Time.deltaTime * 8f);
        cbtmp.color = Color.Lerp(tmp.color, new Color(tmp.color.r, tmp.color.g, tmp.color.b, 0f), Time.deltaTime * 8f);
        rend.color = Color.Lerp(rend.color, new Color(1, 1, 1, 0f), Time.deltaTime * 8f);

        foreach (var cosmetic in Player.cosmetics.transform.GetComponentsInChildren<SpriteRenderer>(true))
        {
            cosmetic.color = Color.Lerp(cosmetic.color, new Color(1, 1, 1, 0f), Time.deltaTime * 8f);
        }

        var pet = Player.GetPet();
        if (pet != null)
        {
            foreach (var petRend in pet.GetComponentsInChildren<SpriteRenderer>(true))
            {
                petRend.color = Color.Lerp(petRend.color, new Color(1, 1, 1, 0f), Time.deltaTime * 8f);
            }
        }
    }

    public override void OnTimerComplete()
    {
        if (Player.AmOwner)
        {
            foreach (var kvp in _originalColors)
            {
                if (kvp.Key != null)
                    kvp.Key.color = kvp.Value;
            }

            Player.cosmetics.nameText.color = _originalNameColor;
            Player.cosmetics.colorBlindText.color = _originalCBTextColor;

            _shouldHide = false;
        }
    }
}
