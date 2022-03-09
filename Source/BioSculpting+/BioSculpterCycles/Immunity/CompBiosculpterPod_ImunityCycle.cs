using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_ImmunityCycle : CompBiosculpterPod_Cycle
    {
        public override void CycleCompleted(Pawn pawn)
        {
            Trait toRemove = null;
            bool isSickly = false;
            bool isImmune = false;

            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                if (trait.def == TraitDef.Named("Immunity")) // no TraitDefOf.Immunity
                {
                    switch (trait.Degree)
                    {
                        case -1: // Sickly
                            toRemove = trait;
                            isSickly = true;
                            break;
                        case 1: // Super immune
                            isImmune = true;
                            break;
                        default: // Nothing
                            break;
                    }
                }
            }

            if (isSickly)
            {
                pawn.story.traits.RemoveTrait(toRemove);
                Messages.Message("BiosculpterImmunityCycleComplete_Fix".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
            } else if (isImmune)
            {
                Messages.Message("BiosculpterImmunityCycleComplete_Fail".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.NegativeEvent);
            } else
            {
                pawn.story.traits.GainTrait(new Trait(TraitDef.Named("Immunity"), 1, forced: true));
                Messages.Message("BiosculpterImmunityCycleComplete_Success".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
            }
            
            return;
        }
    }
}
