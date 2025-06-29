using UnityEngine;
using Watcher;
using RWCustom;

namespace LizardTemplate.Lizards;

sealed class TestLizard : Lizard
{
    // registers the color and rot module for your lizard
    public TestLizard(AbstractCreature abstractCreature, World world) : base(abstractCreature, world)
    {
        var state = Random.state;
        Random.InitState(abstractCreature.ID.RandomSeed);
        effectColor = Custom.HSL2RGB(Custom.WrappedRandomVariation(.5f, .5f, .5f), .3f, Custom.ClampedRandomVariation(.5f, .5f, .5f));
        if (rotModule is LizardRotModule mod && LizardState.rotType != LizardState.RotType.Slight)
            effectColor = Color.Lerp(effectColor, mod.RotEyeColor, LizardState.rotType == LizardState.RotType.Opossum ? .2f : .8f);
        Random.state = state;
    }

    // the graphics module
    public override void InitiateGraphicsModule() => graphicsModule ??= new TestLizardGraphics(this);

    // piece of code that fixes a bug with fisobs
    public override void LoseAllGrasps() => ReleaseGrasp(0);
}
