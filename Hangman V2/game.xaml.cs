using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Shapes;

namespace Hangman_V2
{
	/// <summary>
	/// Interaction logic for game.xaml
	/// </summary>
	public partial class game : Window
	{

		public game()
		{
			InitializeComponent();

		}

		char[] inputView = new char[Globals.word.Length];

		public void buttonStart_Click(object sender, RoutedEventArgs e)
		{
			imageHangman.Source = BitmapToImageSource(Properties.Resources.man0);
			for (int i = 0; i < inputView.Length; i++)
			{
				if (Globals.word[i] == ' ')
					inputView[i] = ' ';
				else
					inputView[i] = '-';
			}

			textBlockInputView.Text = new string(inputView);
			

		}

		public void letter_Click(object sender, RoutedEventArgs e)
		{
			Button source = (Button)sender;
			bool isCorrect = false; //to go through entire for loop before ending
			for (int i = 0; i < Globals.word.Length; i++)
			{
				if (char.Parse(source.Content.ToString()) == Globals.word[i])
				{
					isCorrect = true;
					inputView[i] = char.Parse(source.Content.ToString());
					textBlockInputView.Text = new string(inputView);
				}

			}
			if (!isCorrect)
			{
				Globals.incorrect++;
				setHangman(Globals.incorrect);
				textBlockincorrectLetters.Text += (", " +source.Content.ToString());
			}

			//check if complete
			int missingCount = 0;
			for (int i = 0; i < inputView.Length; i++)
			{
				if (inputView[i] == '-')
					missingCount++;
			}
			if (missingCount == 0)
			{
				textBlockincorrectLetters.Visibility = Visibility.Hidden;
				labelWin.Visibility = Visibility.Visible;

			}
		}
		public void setHangman(int stage)
		{
			switch (stage)
			{
				case 1:
					imageHangman.Source = BitmapToImageSource(Properties.Resources.man1);
					break;
				case 2:
					imageHangman.Source = BitmapToImageSource(Properties.Resources.man2);
					break;
				case 3:
					imageHangman.Source = BitmapToImageSource(Properties.Resources.man3);
					break;
				case 4:
					imageHangman.Source = BitmapToImageSource(Properties.Resources.man4);
					break;
				case 5:
					imageHangman.Source = BitmapToImageSource(Properties.Resources.man5);
					textBlockincorrectLetters.Visibility = Visibility.Hidden;
					labelLose.Visibility = Visibility.Visible;
					System.Threading.Thread.Sleep(1000);
					break;
				default:
					imageHangman.Source = BitmapToImageSource(Properties.Resources.man5);
					break;
			}	

		}

		BitmapImage BitmapToImageSource(Bitmap bitmap)
		{
			using (MemoryStream memory = new MemoryStream())
			{
				bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
				memory.Position = 0;
				BitmapImage bitmapimage = new BitmapImage();
				bitmapimage.BeginInit();
				bitmapimage.StreamSource = memory;
				bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapimage.EndInit();

				return bitmapimage;
			}
		}

	}
}
