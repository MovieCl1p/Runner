
using Core.ResourceManager;
using Game.Player;
using UnityEngine;

namespace Game.Factory
{
    public class GameFactory
    {

        public PlayerController GetPlayer()
        {
            if (!ResourcesCache.IsResourceLoaded("Player"))
            {
                ResourcesCache.SetupResourcesCache("Player", "Player");
            }

            var prefab = ResourcesCache.GetObject<PlayerController>("Player", "Player");
            PlayerController player = GameObject.Instantiate<PlayerController>(prefab);

            return player;
        }
    }
}
