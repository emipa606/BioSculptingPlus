using System.Collections.Generic;
using System.Xml;
using Verse;

namespace BioSculptingPlus;

internal class PatchOperationCheckSettings : PatchOperation
{
    private PatchOperation match;

    private PatchOperation nomatch;
    private List<string> settings;

    protected override bool ApplyWorker(XmlDocument xml)
    {
        var foundMatch = true;
        foreach (var setting in settings)
        {
            foundMatch = setting switch
            {
                "ShowBeautyCycle" => BioSculptingPlusMod.BioSculptingPlusSettings.BeautyCycleSettings.Enabled &&
                                     foundMatch,
                "ShowVoiceCycle" => BioSculptingPlusMod.BioSculptingPlusSettings.VoiceCycleSettings.Enabled &&
                                    foundMatch,
                "ShowAgeIncreaseCycle" =>
                    BioSculptingPlusMod.BioSculptingPlusSettings.AgeIncreaseCycleSettings.Enabled && foundMatch,
                "ShowToughCycle" => BioSculptingPlusMod.BioSculptingPlusSettings.ToughCycleSettings.Enabled &&
                                    foundMatch,
                "ShowImmunityCycle" => BioSculptingPlusMod.BioSculptingPlusSettings.ImmunityCycleSettings.Enabled &&
                                       foundMatch,
                _ => false
            };
        }

        if (foundMatch && match != null)
        {
            return match.Apply(xml);
        }

        return nomatch == null || nomatch.Apply(xml);
    }
}