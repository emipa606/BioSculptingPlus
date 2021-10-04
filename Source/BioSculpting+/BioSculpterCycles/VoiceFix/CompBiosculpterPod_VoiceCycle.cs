using RimWorld;
using Verse;

namespace BioSculptingPlus
{
    class CompBiosculpterPod_VoiceCycle : CompBiosculpterPod_Cycle
    {
        public override void CycleCompleted(Pawn pawn)
        {
            Trait toRemove = null;
            foreach (Trait trait in pawn.story.traits.allTraits)
            {
                switch (trait.Label)
                {
                    case "annoying voice":
                        toRemove = trait;
                        break;
                    case "creepy breathing":
                        toRemove = trait;
                        break;
                }
            }

            if (toRemove != null)
            {
                pawn.story.traits.RemoveTrait(toRemove);
                Messages.Message("BiosculpterVoiceFixCycleComplete_Fix".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.PositiveEvent);
            }
            else
            {
                 Messages.Message("BiosculpterVoiceFixCycleComplete_Fail".Translate(pawn.Named("PAWN")), pawn, MessageTypeDefOf.NegativeEvent);
            }

            return;
        }
    }
}
