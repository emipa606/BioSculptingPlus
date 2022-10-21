using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    public class CompBiosculpterPod_BeautyCycle : CompBiosculpterPod_Cycle
    {
        public override void CycleCompleted(Pawn pawn)
        {
            Trait toRemove = null;
            int currentBeauty = 0;

            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                if (trait.def == TraitDefOf.Beauty)
                {
                       switch (trait.Degree)
                    {
                        case -2: // Staggeringly ugly
                            toRemove = trait;
                            currentBeauty -= 2;
                            break;
                        case -1: // Ugly
                            toRemove = trait;
                            currentBeauty -= 1;
                            break;
                        case 1: // Pretty
                            toRemove = trait;
                            currentBeauty += 1;
                            break;
                        case 2: // Beautiful
                            currentBeauty += 2;
                            break;
                        default: // Nothing
                            break;
                    }
                }
            }

            switch (currentBeauty)
            {
                case -2:
                    pawn.story.traits.RemoveTrait(toRemove);
                    pawn.story.traits.GainTrait(new Trait(TraitDefOf.Beauty, -1, forced: true));
                    Messages.Message("BiosculpterBeautyCycleComplete_Ugly".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
                    break;
                case -1:
                    pawn.story.traits.RemoveTrait(toRemove);
                    Messages.Message("BiosculpterBeautyCycleComplete_Normal".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
                    break;
                case 0:
                    pawn.story.traits.GainTrait(new Trait(TraitDefOf.Beauty, 1, forced: true));
                    Messages.Message("BiosculpterBeautyCycleComplet_Pretty".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
                    break;
                case 1:
                    pawn.story.traits.RemoveTrait(toRemove);
                    pawn.story.traits.GainTrait(new Trait(TraitDefOf.Beauty, 2, forced: true));
                    Messages.Message("BiosculpterBeautyCycleComplete_Beautiful".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
                    break;
                default:
                    Messages.Message("BiosculpterBeautyCycleFailed".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.NegativeEvent);
                    break;
            }
            return;
        }
    }
}
