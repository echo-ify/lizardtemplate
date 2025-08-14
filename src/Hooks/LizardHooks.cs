global using static LizardTemplate.Hooks.LizardHooks;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

namespace LizardTemplate.Hooks;

public static class LizardHooks
{
    internal static CreatureTemplate On_LizardBreeds_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate(On.LizardBreeds.orig_BreedTemplate_Type_CreatureTemplate_CreatureTemplate_CreatureTemplate_CreatureTemplate orig, CreatureTemplate.Type type, CreatureTemplate lizardAncestor, CreatureTemplate pinkTemplate, CreatureTemplate blueTemplate, CreatureTemplate greenTemplate)
    {
        // breed stuff, this determines your lizard's general stats.
        CreatureTemplate temp;
        LizardBreedParams breedParams;
        if (type == CreatureTemplateType.TestLizard)
        {
            temp = orig(type, lizardAncestor, pinkTemplate, blueTemplate, greenTemplate);
            breedParams = (temp.breedParameters as LizardBreedParams)!;
            temp.type = type;
            temp.name = "TestLizard";
            breedParams.template = type;
            breedParams.baseSpeed = 4.2f;
            breedParams.terrainSpeeds[1] = new(1f, 1f, 1f, 1f);
            breedParams.terrainSpeeds[3] = new(1f, 1f, 1f, 1f);
            breedParams.terrainSpeeds[4] = new(1f, 1f, 1f, 1f);
            breedParams.terrainSpeeds[5] = new(.1f, 1f, 1f, 1f);
            breedParams.terrainSpeeds[6] = new(.1f, 1f, 1f, 1f);
            breedParams.standardColor = new(.5f, .5f, .5f);
            breedParams.biteDelay = 2;
            breedParams.biteInFront = 20f;
            breedParams.biteRadBonus = 20f;
            breedParams.biteHomingSpeed = 4.5f;
            breedParams.biteChance = .9f;
            breedParams.attemptBiteRadius = 120f;
            breedParams.getFreeBiteChance = 1f;
            breedParams.biteDamage = 1f;
            breedParams.biteDamageChance = .2f;
            breedParams.toughness = 2f;
            breedParams.stunToughness = 4f;
            breedParams.regainFootingCounter = 1;
            breedParams.bodyMass = 2f;
            breedParams.bodySizeFac = 1f;
            breedParams.floorLeverage = 8f;
            breedParams.maxMusclePower = 12f;
            breedParams.wiggleSpeed = .8f;
            breedParams.wiggleDelay = 20;
            breedParams.bodyStiffnes = .4f;
            breedParams.swimSpeed = 1f;
            breedParams.idleCounterSubtractWhenCloseToIdlePos = 10;
            breedParams.danger = .5f;
            breedParams.aggressionCurveExponent = .7f;
            breedParams.headShieldAngle = 160f;
            temp.visualRadius = 2300f;
            temp.waterVision = .7f;
            temp.throughSurfaceVision = .95f;
            breedParams.perfectVisionAngle = Mathf.Lerp(1f, -1f, 4f / 9f);
            breedParams.periferalVisionAngle = Mathf.Lerp(1f, -1f, 7f / 9f);
            breedParams.biteDominance = 1f;
            breedParams.limbSize = 2.9f;
            breedParams.stepLength = 1f;
            breedParams.liftFeet = .3f;
            breedParams.feetDown = .5f;
            breedParams.noGripSpeed = .25f;
            breedParams.limbSpeed = 6f;
            breedParams.limbQuickness = .6f;
            breedParams.limbGripDelay = 1;
            breedParams.smoothenLegMovement = true;
            breedParams.legPairDisplacement = .3f;
            breedParams.walkBob = 2.7f;
            breedParams.tailSegments = 16;
            breedParams.tailStiffness = 300f;
            breedParams.tailStiffnessDecline = .25f;
            breedParams.tailLengthFactor = .8f;
            breedParams.tailColorationStart = .9f;
            breedParams.tailColorationExponent = 8f;
            breedParams.headSize = 1f;
            breedParams.neckStiffness = .37f;
            breedParams.jawOpenAngle = 150f;
            breedParams.jawOpenLowerJawFac = .7666667f;
            breedParams.jawOpenMoveJawsApart = 25f;
            breedParams.headGraphics = new int[5];
            breedParams.framesBetweenLookFocusChange = 20;
            breedParams.tamingDifficulty = 3f;
            temp.movementBasedVision = .3f;
            temp.waterPathingResistance = 3f;
            temp.dangerousToPlayer = breedParams.danger;
            temp.doPreBakedPathing = false;
            temp.requireAImap = true;
            temp.preBakedPathingAncestor = pinkTemplate;
            temp.meatPoints = 7;
            temp.baseDamageResistance = breedParams.toughness * 2f;
            temp.baseStunResistance = breedParams.toughness;
            temp.damageRestistances[(int)Creature.DamageType.Bite, 0] = 2.5f;
            temp.damageRestistances[(int)Creature.DamageType.Bite, 1] = 3f;
            return temp;
        }
        return orig(type, lizardAncestor, pinkTemplate, blueTemplate, greenTemplate);
    }

    // voice
    internal static SoundID On_LizardVoice_GetMyVoiceTrigger(On.LizardVoice.orig_GetMyVoiceTrigger orig, LizardVoice self)
    {
        var res = orig(self);
        List<SoundID> list;
        SoundID soundID;
        if (self.lizard is Lizard l)
        {
            if (l is TestLizard)
            {
                // the voice here is green lizard, you can change that if needed
                var array = new[]
                {
                    SoundID.Lizard_Voice_Green_A
                };
                list = [];
                for (var i = 0; i < array.Length; i++)
                {
                    soundID = array[i];
                    if (soundID.Index != -1 && l.abstractPhysicalObject.world.game.soundLoader.workingTriggers[soundID.Index])
                        list.Add(soundID);
                }
                if (list.Count == 0)
                    res = SoundID.None;
                else
                    res = list[Random.Range(0, list.Count)];
            }
     
        }
        return res;
    }
}
