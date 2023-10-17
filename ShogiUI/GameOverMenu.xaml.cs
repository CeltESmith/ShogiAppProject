﻿using ShogiLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShogiUI
{
	/// <summary>
	/// Interaction logic for GameOverMenu.xaml
	/// </summary>
	public partial class GameOverMenu : UserControl
	{
		public event Action<Option> OptionSelected;

		public GameOverMenu(GameState gameState)
		{
			InitializeComponent();

			Result result = gameState.Result;
			WinnerText.Text = GetWinnerText(result.Winner);
			ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
		}

		private static string GetWinnerText(Player winner)
		{
			return winner switch
			{
				Player.White => "WHITE WINS!",
				Player.Black => "BLACK WINS!",
				_ => "IT'S A DRAW!"
			};
		}

		private static string PlayerString(Player player)
		{
			return player switch
			{
				Player.White => "White",
				Player.Black => "Black",
				_ => ""
			};
		}

		private static string GetReasonText(EndReason reason, Player currentPlayer)
		{
			return reason switch
			{
				EndReason.Stalemate => $"STALEMATE - {PlayerString(currentPlayer)} CAN'T MOVE",
				EndReason.Checkmate => $"CHECKMATE - {PlayerString(currentPlayer)} CAN'T MOVE",
				//EndReason.FiftyMoveRule => "FIFTY_MOVE RULE",
				//EndReason.InsufficientMaterial => "INSUFFICIENT MATERIAL",
				//EndReason.ThreeFoldRepetition => "THREEFOLD REPETITION", 
				_ => ""
			};
		}

		private void Restart_Click(object sender, RoutedEventArgs e)
		{
			OptionSelected?.Invoke(Option.Restart);
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			OptionSelected?.Invoke(Option.Exit);
        }
    }
}
