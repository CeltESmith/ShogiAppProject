using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ShogiLogic;

namespace ShogiUI
{
    public static class Images
    {
        private static readonly Dictionary<PieceType, ImageSource> whiteSources = new()
        {
            {PieceType.Lance, LoadImage("Assets/LanceW.png") },
            {PieceType.Knight, LoadImage("Assets/KnightW.png") },
            {PieceType.SilverGeneral, LoadImage("Assets/SilverGeneralW.png") },
            {PieceType.GoldGeneral, LoadImage("Assets/GoldGeneralW.png") },
            {PieceType.King, LoadImage("Assets/KingW.png") },
            {PieceType.Bishop, LoadImage("Assets/BishopW.png") },
            {PieceType.Rook, LoadImage("Assets/RookW.png") },
            {PieceType.Pawn, LoadImage("Assets/PawnW.png") }
        };

        private static readonly Dictionary<PieceType, ImageSource> blackSources = new()
        {
            {PieceType.Lance, LoadImage("Assets/LanceB.png") },
            {PieceType.Knight, LoadImage("Assets/KnightB.png") },
            {PieceType.SilverGeneral, LoadImage("Assets/SilverGeneralB.png") },
            {PieceType.GoldGeneral, LoadImage("Assets/GoldGeneralB.png") },
            {PieceType.King, LoadImage("Assets/KingB.png") },
            {PieceType.Bishop, LoadImage("Assets/BishopB.png") },
            {PieceType.Rook, LoadImage("Assets/RookB.png") },
            {PieceType.Pawn, LoadImage("Assets/PawnB.png") }
        };

        private static ImageSource LoadImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.Relative));
        }

        public static ImageSource GetImage(Player color, PieceType type)
        {
            return color switch
            {
                Player.White => whiteSources[type],
                Player.Black => blackSources[type],
                _ => null
            };
        }

        public static ImageSource GetImage(Piece piece)
        {
            if (piece == null)
            {
                return null;
            }

            return GetImage(piece.Color, piece.Type);
        }
    }
}
