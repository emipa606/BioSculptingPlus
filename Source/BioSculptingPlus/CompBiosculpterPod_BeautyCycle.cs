using RimWorld;
using Verse;

namespace BioSculptingPlus;

public class CompBiosculpterPod_BeautyCycle : CompBiosculpterPod_Cycle
{
    private readonly TraitDef beauty = TraitDef.Named("Beauty");

    public override void CycleCompleted(Pawn pawn)
    {
        Trait trait = null;
        var num = 0;
        foreach (var allTrait in pawn.story.traits.allTraits)
        {
            if (allTrait.def == beauty)
            {
                switch (allTrait.Degree)
                {
                    case -2:
                        trait = allTrait;
                        num -= 2;
                        break;
                    case -1:
                        trait = allTrait;
                        num--;
                        break;
                    case 1:
                        trait = allTrait;
                        num++;
                        break;
                    case 2:
                        num += 2;
                        break;
                }
            }
        }

        switch (num)
        {
            case -2:
                pawn.story.traits.RemoveTrait(trait);
                pawn.story.traits.GainTrait(new Trait(beauty, -1, true));
                Messages.Message("BiosculpterBeautyCycleComplete_Ugly".Translate(pawn.Named("PAWN")), pawn,
                    MessageTypeDefOf.PositiveEvent);
                break;
            case -1:
                pawn.story.traits.RemoveTrait(trait);
                Messages.Message("BiosculpterBeautyCycleComplete_Normal".Translate(pawn.Named("PAWN")), pawn,
                    MessageTypeDefOf.PositiveEvent);
                break;
            case 0:
                pawn.story.traits.GainTrait(new Trait(beauty, 1, true));
                Messages.Message("BiosculpterBeautyCycleComplet_Pretty".Translate(pawn.Named("PAWN")), pawn,
                    MessageTypeDefOf.PositiveEvent);
                break;
            case 1:
                pawn.story.traits.RemoveTrait(trait);
                pawn.story.traits.GainTrait(new Trait(beauty, 2, true));
                Messages.Message("BiosculpterBeautyCycleComplete_Beautiful".Translate(pawn.Named("PAWN")), pawn,
                    MessageTypeDefOf.PositiveEvent);
                break;
            default:
                Messages.Message("BiosculpterBeautyCycleFailed".Translate(pawn.Named("PAWN")), pawn,
                    MessageTypeDefOf.NegativeEvent);
                break;
        }
    }
}