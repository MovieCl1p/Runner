using Game.Components.Level;
using Game.Player;

namespace Game.Model
{
    public class LevelSessionModel
    {
        public int LevelId { get; set; }

        public PlayerController Player { get; set; }

        public LevelController Level { get; set; }
    }
}
