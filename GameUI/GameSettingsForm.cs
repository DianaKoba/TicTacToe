namespace GameUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Tic_Tac_Toe_Game;

    public partial class GameSettingsForm : Form
    {
        #region Members
        #region Consts
        private const string k_DefaultPlayer2Name = "Computer";
        private const string k_LeftDelimiter = "[";
        private const string k_RightDelimiter = "]";
        private const string k_InvalidNameError = "Invalid player name. Only letters allowed";
        private const string k_ToolTipText = "Player name (letters only)";
        private const byte k_BoardMinSize = 4;
        private const byte k_BoardMaxSize = 10;
        private const int k_ToolTipDuration = 2000;
        #endregion Consts
        private Player m_Player1 = new Player();
        private Player m_Player2 = new Player();
        private Board m_Board = new Board();
        private ToolTip m_ToolTip = new ToolTip();
        #endregion Members

        #region Costructor
        public GameSettingsForm()
        {
            InitializeComponent();
            m_ToolTip.SetToolTip(this.TextBoxPlayer1Name, k_ToolTipText);
            m_ToolTip.SetToolTip(this.TextBoxPlayer2Name, k_ToolTipText);
            m_Player2.Type = ePlayerTypes.Computer;
        }
        #endregion Costructor

        #region Event Handlers
        private void m_TextPlayer1_TextChanged(object sender, EventArgs e)
        {
            verifyValidName(TextBoxPlayer1Name);
            enableDisableStartButton(TextBoxPlayer1Name);
        }

        private void m_TextPlayer2_TextChanged(object sender, EventArgs e)
        {
            if (CheckBoxPlayer2.Checked)
            { // Prevent error message on "[Computer]"
                verifyValidName(TextBoxPlayer2Name);
                enableDisableStartButton(TextBoxPlayer2Name);
            }
        }

        private void m_CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxPlayer2.Checked)
            {
                TextBoxPlayer2Name.Enabled = true;
                TextBoxPlayer2Name.Text = string.Empty;
                TextBoxPlayer2Name.BackColor = Color.White;
                m_Player2.Type = ePlayerTypes.Person;
            }
            else
            {
                TextBoxPlayer2Name.Enabled = false;
                TextBoxPlayer2Name.Text = string.Format("{0}{1}{2}", k_LeftDelimiter, k_DefaultPlayer2Name, k_RightDelimiter);
                m_Player2.Type = ePlayerTypes.Computer;
            }
        }

        private void m_NumericRows_ValueChanged(object sender, EventArgs e)
        {
            NumericCols.Value = NumericRows.Value;
        }

        private void m_NumericCols_ValueChanged(object sender, EventArgs e)
        {
            NumericRows.Value = NumericCols.Value;
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            try
            {
                m_Player1.Name = TextBoxPlayer1Name.Text;
                m_Player2.Name = (m_Player2.Type == ePlayerTypes.Person) ? TextBoxPlayer2Name.Text : k_DefaultPlayer2Name;
                m_Board.Size = (byte)NumericCols.Value; // Rows == Cols
                this.Visible = false;
                GameBoardForm gameBoardForm = new GameBoardForm(m_Player1, m_Player2, m_Board);
                gameBoardForm.ShowDialog();
            }
            catch (Exception ex)
            { // We are verifying all values on the fly, so we souldn't get any exception here!
                showErrorMessage(ex.Message);
            }
            finally
            {
                closeApplication();
            }
        }
        #endregion Event Handlers

        #region Utils
        private void closeApplication()
        {
            Application.Exit();
        }

        private void enableDisableStartButton(TextBox i_TextBox)
        {
            if (i_TextBox.Text == string.Empty)
            {
                ButtonStart.Enabled = false;
            }
            else
            {
                ButtonStart.Enabled = true;
            }
        }

        private void verifyValidName(TextBox i_TextBox)
        {
            if (i_TextBox.Text.Length > 0)
            {
                if (!Player.IsValidName(i_TextBox.Text))
                {
                    m_ToolTip.Show(k_InvalidNameError, i_TextBox, k_ToolTipDuration);
                    removeInvalidChars(i_TextBox);
                }
            }

            // Move the Cursor to the end of the text
            i_TextBox.SelectionStart = i_TextBox.Text.Length;
            i_TextBox.SelectionLength = 0;
        }

        private void removeInvalidChars(TextBox i_TextBox)
        {
            string tempCopy = i_TextBox.Text;

            for (int i = 0; i < tempCopy.Length; i++)
            {
                if (!Player.IsCharValid(tempCopy[i]))
                {
                    tempCopy = tempCopy.Remove(i, 1);
                }
            }
            
            i_TextBox.Text = tempCopy;
        }

        private void showErrorMessage(string i_Msg)
        {
            MessageBox.Show(i_Msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion Utils
    }
}
