using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Hangman_V2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	public class Globals
	{
		public static char[] word;
		public static int incorrect = 0;

	}


	public partial class MainWindow : Window
	{
		

		public MainWindow()
		{
			InitializeComponent();
		}

		private void buttonSubmit_Click(object sender, RoutedEventArgs e)
		{
			
			Globals.word = textBoxWord.Text.ToUpper().ToCharArray();
			game game = new game();
			game.Show();
			game.buttonStart_Click(sender, e);
			Close();
		}

		private void textBoxWord_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
				buttonSubmit_Click(sender, e);
		}

	}
}
