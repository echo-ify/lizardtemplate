using Fisobs.Creatures;
using Fisobs.Core;
using Fisobs.Sandbox;
using UnityEngine;
using System.Collections.Generic;
using DevInterface;

namespace LizardTemplate.Lizards;

sealed class TestLizardCritob : Critob
{
    internal TestLizardCritob() : base(CreatureTemplateType.TestLizard)
    {
        // the icon of your lizard
        Icon = new SimpleIcon("Kill_Standard_Lizard", Color.grey);
        // stuff (i don't know what it is)
        LoadedPerformanceCost = 50f;
        SandboxPerformanceCost = new(.25f, .25f);
        // unlock stuff
        RegisterUnlock(KillScore.Configurable(1), SandboxUnlockID.TestLizard);
    }

    // change this if you want, it's the score you get for killing your lizard in expedition
    public override int ExpeditionScore() => 1;

    // feel free to change this too
    public override Color DevtoolsMapColor(AbstractCreature acrit) => Color.grey;

    // try to keep this short, "TLz" is just heavily shortened "TestLizard"
    public override string DevtoolsMapName(AbstractCreature acrit) => "TLz";

    // for region modders who want to add this lizard to their region via world file, don't overcomplicate this PLEASE -region modder
    public override IEnumerable<string> WorldFileAliases() => ["testlizard", "test lizard"];


    // room att, basically determines the categories for that
    public override IEnumerable<RoomAttractivenessPanel.Category> DevtoolsRoomAttraction() =>
    [
        RoomAttractivenessPanel.Category.Lizards
    ];

    // don't mess with this
    public override CreatureTemplate CreateTemplate() => LizardBreeds.BreedTemplate(Type, StaticWorld.GetCreatureTemplate(CreatureTemplate.Type.LizardTemplate), StaticWorld.GetCreatureTemplate(CreatureTemplate.Type.PinkLizard), StaticWorld.GetCreatureTemplate(CreatureTemplate.Type.BlueLizard), StaticWorld.GetCreatureTemplate(CreatureTemplate.Type.GreenLizard));

    // relationships, edit as you want
    // also watcher creatures are in WatcherEnums.CreatureTemplateType
    // dlc shared (most downpour critters) are in DLCSharedEnums.CreatureTemplateType
    public override void EstablishRelationships()
    {
        var s = new Relationships(Type);
        s.Ignores(CreatureTemplate.Type.LizardTemplate);
        s.HasDynamicRelationship(CreatureTemplate.Type.Slugcat, .5f);
        s.Fears(CreatureTemplate.Type.Vulture, .9f);
        s.Fears(CreatureTemplate.Type.KingVulture, 1f);
        s.Eats(CreatureTemplate.Type.TubeWorm, .025f);
        s.Eats(CreatureTemplate.Type.Scavenger, .8f);
        s.Eats(CreatureTemplate.Type.CicadaA, .05f);
        s.Eats(CreatureTemplate.Type.LanternMouse, .3f);
        s.Eats(CreatureTemplate.Type.BigSpider, .35f);
        s.Eats(CreatureTemplate.Type.EggBug, .45f);
        s.Eats(CreatureTemplate.Type.JetFish, .1f);
        s.Fears(CreatureTemplate.Type.BigEel, 1f);
        s.Eats(CreatureTemplate.Type.Centipede, .8f);
        s.Eats(CreatureTemplate.Type.BigNeedleWorm, .25f);
        s.Fears(CreatureTemplate.Type.DaddyLongLegs, 1f);
        s.Eats(CreatureTemplate.Type.SmallNeedleWorm, .3f);
        s.Eats(CreatureTemplate.Type.DropBug, .2f);
        s.Fears(CreatureTemplate.Type.RedCentipede, .9f);
        s.Fears(CreatureTemplate.Type.TentaclePlant, .2f);
        s.Eats(CreatureTemplate.Type.Hazer, .15f);
        s.FearedBy(CreatureTemplate.Type.LanternMouse, .7f);
        s.EatenBy(CreatureTemplate.Type.Vulture, .5f);
        s.FearedBy(CreatureTemplate.Type.CicadaA, .3f);
        s.FearedBy(CreatureTemplate.Type.JetFish, .2f);
        s.FearedBy(CreatureTemplate.Type.Slugcat, 1f);
        s.FearedBy(CreatureTemplate.Type.Scavenger, .5f);
        s.EatenBy(CreatureTemplate.Type.DaddyLongLegs, 1f);
        if (ModManager.DLCShared)
        {
            s.IgnoredBy(DLCSharedEnums.CreatureTemplateType.ZoopLizard);
            s.Ignores(DLCSharedEnums.CreatureTemplateType.ZoopLizard);
        }
    }

    // the ai of the lizard (don't change unless you have a new ai for your lizard)
    public override ArtificialIntelligence CreateRealizedAI(AbstractCreature acrit) => new LizardAI(acrit, acrit.world);

    // change "TestLizard" to your lizards file
    public override Creature CreateRealizedCreature(AbstractCreature acrit) => new TestLizard(acrit, acrit.world);

    // don't change this
    public override CreatureState CreateState(AbstractCreature acrit) => new LizardState(acrit);

    // don't fucking delete this jessica.
    public override void LoadResources(RainWorld rainWorld) { }


    // change this if you need, it's a fallback incase the lizard isn't present (e.g. when the mod is disabled or uninstalled) in arena, and hasn't been removed/changed
    public override CreatureTemplate.Type? ArenaFallback() => CreatureTemplate.Type.PinkLizard;
}
