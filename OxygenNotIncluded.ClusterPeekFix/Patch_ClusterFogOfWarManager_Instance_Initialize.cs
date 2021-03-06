using System.Diagnostics.CodeAnalysis;
using Harmony;

namespace OxygenNotIncluded.ClusterPeekFix
{
    [HarmonyPatch(typeof(ClusterFogOfWarManager.Instance), nameof(ClusterFogOfWarManager.Instance.Initialize))]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Patch_ClusterFogOfWarManager_Instance_Initialize
    {
        public static void Postfix(ClusterFogOfWarManager.Instance __instance)
        {
            foreach (var location in ClusterGrid.Instance.cellContents.Keys)
                if (__instance.IsLocationRevealed(location))
                    __instance.PeekLocation(location, 2);
        }
    }
}
