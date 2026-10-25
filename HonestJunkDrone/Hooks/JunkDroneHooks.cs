using RoR2;
using UnityEngine;

namespace HonestJunkDrone.Hooks
{
    /// <summary>
    /// The Junk Drone's Surprise state drops its items as droplets, and with the Artifact of Command each droplet opens
    /// a Command Cube with random options. The game's own opt-out is UniquePickup.ignoreArtifactBasedPickupReplacements
    /// (PickupSpawner and ItemSpawnPoint use it). The items printed by Surprise.OnExit are marked with it, so they land
    /// on the ground as regular pickups.
    /// </summary>
    internal static class JunkDroneHooks
    {
        private static bool _dropping;

        public static void Init()
        {
            On.EntityStates.Drone.DroneJunk.Surprise.OnExit += Surprise_OnExit;
            On.RoR2.PickupDropletController.CreatePickupDroplet_UniquePickup_Vector3_Vector3_bool += PickupDropletController_CreatePickupDroplet_UniquePickup_Vector3_Vector3_bool;
        }

        private static void Surprise_OnExit(On.EntityStates.Drone.DroneJunk.Surprise.orig_OnExit orig, EntityStates.Drone.DroneJunk.Surprise self)
        {
            _dropping = true;
            try
            {
                orig(self);
            }
            finally
            {
                _dropping = false;
            }
        }

        private static void PickupDropletController_CreatePickupDroplet_UniquePickup_Vector3_Vector3_bool(On.RoR2.PickupDropletController.orig_CreatePickupDroplet_UniquePickup_Vector3_Vector3_bool orig, UniquePickup pickup, Vector3 position, Vector3 velocity, bool isDuplicated)
        {
            if (_dropping)
            {
                pickup.ignoreArtifactBasedPickupReplacements = true;
            }
            orig(pickup, position, velocity, isDuplicated);
        }
    }
}
