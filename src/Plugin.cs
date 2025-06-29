global using LizardTemplate.Lizards;
using BepInEx;
using BepInEx.Logging;
using Fisobs.Core;
using System.Security.Permissions;

// Allows access to private members (thanks mod template, i would have forgotten this)
#pragma warning disable CS0618
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618

namespace LizardTemplate;

// don't remove any of this, but put additional hooks as needed (not for lizards, those are handled in LizardHooks.cs)
[BepInPlugin("com.author.lizardtemplate", "Lizard Template", "0.1.0"), BepInDependency("io.github.dual.fisobs")]
sealed class Plugin : BaseUnityPlugin
{
    public static new ManualLogSource Logger;
    bool IsInit;

    public void OnEnable()
    {
        Logger = base.Logger;
        On.RainWorld.OnModsInit += OnModsInit;
        On.LizardBreeds.BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate += On_LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate;
        On.LizardVoice.GetMyVoiceTrigger += On_LizardVoice_GetMyVoiceTrigger;
        // this registers the lizard ingame
        Content.Register(new TestLizardCritob());
    }

    private void OnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
    {
        orig(self);

        if (IsInit) return;
        IsInit = true;

        // Initialize assets, your mod config, and anything that uses RainWorld here (thanks mod template)
        Logger.LogDebug("Hello world!");
    }
}
