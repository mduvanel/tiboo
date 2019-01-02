using System.Collections.Generic;

namespace Tiboo
{
    public static class SoundMixer
    {
        // Enum covering all possible sound FX
        public enum SoundFX
        {
            HELLO,
            WHERE_TO_GO,
            GREEN_RABBIT,
            BLUE_RABBIT,
            RED_MOUSE,
            YELLOW_MOUSE,
            OPEN_WALL,
            CLOSED_WALL,
            RABBIT_HOLE,
            MOUSE_HOLE,
            MAGIC_DOOR,
            BORDER,
            THOU_SHALT_PASS,
            THOU_SHALT_NOT_PASS,
            PLAY_AGAIN,
            VICTORY,
            DEFEAT
        }

        static readonly Dictionary<KeyValuePair<Player.Animal, Player.Color>, SoundFX> PLAYER_SOUNDS =
            new Dictionary<KeyValuePair<Player.Animal, Player.Color>, SoundFX>
            {
                { new KeyValuePair<Player.Animal, Player.Color>(
                    Player.Animal.MOUSE,
                    Player.Color.RED
                  ), SoundFX.RED_MOUSE },
                { new KeyValuePair<Player.Animal, Player.Color>(
                    Player.Animal.MOUSE,
                    Player.Color.YELLOW
                  ), SoundFX.YELLOW_MOUSE },
                { new KeyValuePair<Player.Animal, Player.Color>(
                    Player.Animal.RABBIT,
                    Player.Color.BLUE
                  ), SoundFX.BLUE_RABBIT },
                { new KeyValuePair<Player.Animal, Player.Color>(
                    Player.Animal.RABBIT,
                    Player.Color.GREEN
                  ), SoundFX.GREEN_RABBIT }
            };

        static SoundFX GetPlayerSound(Player player)
        {
            return PLAYER_SOUNDS[new KeyValuePair<Player.Animal, Player.Color>(
                player.AnimalType, player.ColorType
            )];
        }

        static readonly Dictionary<Wall.Type, SoundFX> WALL_SOUNDS =
            new Dictionary<Wall.Type, SoundFX>
            {
                { Wall.Type.OPEN, SoundFX.OPEN_WALL },
                { Wall.Type.CLOSED, SoundFX.CLOSED_WALL },
                { Wall.Type.RABBIT_HOLE, SoundFX.RABBIT_HOLE },
                { Wall.Type.MAGIC_DOOR, SoundFX.MAGIC_DOOR },
                { Wall.Type.MOUSE_HOLE, SoundFX.MOUSE_HOLE }
            };

        static SoundFX GetWallSound(Wall.Type wallType)
        {
            return WALL_SOUNDS[wallType];
        }

        public static List<SoundFX> GetWelcomeSounds(Player player)
        {
            return new List<SoundFX> {
                SoundFX.HELLO,
                GetPlayerSound(player),
                SoundFX.WHERE_TO_GO
            };
        }

        public static List<SoundFX> GetNextPlayerSounds(MoveDetails moveDetails, Game game)
        {
            if (game.GameOver())
            {
                return new List<SoundFX> { SoundFX.DEFEAT };
            }
            else
            {
                if (moveDetails.PlayAgain)
                {
                    return new List<SoundFX> { SoundFX.PLAY_AGAIN };
                }
                else
                {
                    return GetWelcomeSounds(game.CurrentPlayer());
                }
            }
        }

        public static List<SoundFX> GetMoveSounds(MoveDetails moveDetails)
        {
            if (moveDetails.Status == MoveDetails.MoveStatus.ABORTED)
            {
                return new List<SoundFX> {
                    SoundFX.BORDER
                };
            }
            else
            {
                // First insert the purely move-related sounds
                return new List<SoundFX>
                {
                    GetWallSound(moveDetails.WallType),
                    moveDetails.Status == MoveDetails.MoveStatus.FAILURE ?
                               SoundFX.THOU_SHALT_NOT_PASS :
                               SoundFX.THOU_SHALT_PASS
                };
            }
        }
    }
}