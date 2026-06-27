using System;
using SwinGameSDK;
using CardGames.GameLogic;

namespace CardGames
{
    public class SnapGame
    {
        public static void LoadResources()
        {
            Bitmap cards;
            cards = SwinGame.LoadBitmapNamed("Cards", "Cards.png");
            SwinGame.BitmapSetCellDetails(cards, 82, 110, 13, 5, 53);

            SwinGame.LoadFontNamed("GameFont", "ChunkFive-Regular.otf", 12);
        }

        private static void HandleUserInput(Snap myGame)
        {
            SwinGame.ProcessEvents();

            if (SwinGame.KeyTyped(KeyCode.vk_SPACE))
            {
                myGame.FlipNextCard();
            }
        }

        private static void DrawGame(Snap myGame)
        {
            SwinGame.ClearScreen(Color.White);

            // background
            SwinGame.DrawCell(
                SwinGame.BitmapNamed("Cards"),
                52, 155, 153
            );

            Card top = myGame.TopCard;

            if (top != null)
            {
                SwinGame.DrawText(
                    "Top Card is " + top.ToString(),
                    Color.RoyalBlue,
                    "GameFont",
                    0, 20
                );

                SwinGame.DrawText(
                    "Player 1 score: " + myGame.Score(0),
                    Color.RoyalBlue,
                    "GameFont",
                    0, 30
                );

                SwinGame.DrawText(
                    "Player 2 score: " + myGame.Score(1),
                    Color.RoyalBlue,
                    "GameFont",
                    0, 40
                );

                SwinGame.DrawCell(
                    SwinGame.BitmapNamed("Cards"),
                    top.CardIndex,
                    521, 153
                );
            }
        } // ✅ correct end of DrawGame

        private static void UpdateGame(Snap myGame)
        {
            myGame.Update();
        }

        public static void Main()
        {
            SwinGame.OpenGraphicsWindow("Snap!", 860, 500);

            LoadResources();

            Snap myGame = new Snap();

            while (!SwinGame.WindowCloseRequested())
            {
                HandleUserInput(myGame);
                DrawGame(myGame);
                UpdateGame(myGame);
            }
        }
    }
}