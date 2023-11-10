using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viselitsa
{
	public partial class Game : Form
	{

		string Secret_word;
		int count_error = 0;

		public Game()
		{
			InitializeComponent();
			Secret_word = File.Get_Secret_Word("words.txt");
			secret_word.Text = new string('*', Secret_word.Length);
			pBoxHangMan.Image = Image.FromFile("hangman" + count_error + ".png");
		}

		private void Check_Word(char letter)
		{
			bool flag = false;
			string new_text = string.Empty;
			for (int i = 0; i < Secret_word.Length; i++)
			{
				if (Secret_word[i] == letter)
				{
					new_text += letter;
					flag = true;
				}
				else new_text += secret_word.Text[i];
			}

			if (!flag) pBoxHangMan.Image = Image.FromFile("hangman" + ++count_error + ".png");
			secret_word.Text = new_text;

			if (count_error == 7) { 
				if (MessageBox.Show("Вы проиграли!") == DialogResult.OK)
				{
					foreach (Control control in this.Controls) control.Visible = false;
					btnPlayAgain.Visible = btnClose.Visible = labelEndGame.Visible = true;
				}
			}
		}
		private void btn_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			Check_Word(btn.Name[btn.Name.Length - 1]);
			btn.Enabled = false;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnPlayAgain_Click(object sender, EventArgs e)
		{
			Application.Restart();
		}
	}
}
