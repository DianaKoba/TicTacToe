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

    public partial class GameBoardForm : Form
    {
        #region Members
        #region Consts
        private const int k_StartXPosition = 10;
        private const int k_StartYPosition = 10;
        private const int k_RightSpace = 5;
        private const int k_ButtomSpace = 5;
        private const int k_ButtonWidth = 50;
        private const int k_ButtonHeight = 40;
        #endregion Consts
        private string m_Player1Name;
        private string m_Player2Name;
        private ePlayerTypes m_Player2Type;
        private GameManager m_GameManager;
        private Board m_Board;
        private DialogResult m_IsNewGameRequested;
        #endregion Members

        #region Constructor
        public GameBoardForm(Player i_Player1, Player i_Player2, Board i_Board)
        {
            InitializeComponent();
            m_Player1Name = i_Player1.Name;
            m_Player2Name = i_Player2.Name;
            m_Player2Type = i_Player2.Type;
            m_Board = i_Board;
            m_Board.Create();
            m_GameManager = new GameManager(i_Player1, i_Player2);
            m_GameManager.ComputerPlayed += m_GameManager_ComputerPlayed;
            setFormSize();
            createButtons();
            createScoreLabel(i_Player1, i_Player2);
        }
        #endregion Constructor

        #region Events
        private void buttons_Click(object sender, EventArgs e)
        {
            MyButton button = sender as MyButton;

            updateFormAndBoardOnButtonSelection(button);
            try
            {
                m_GameManager.ReactToPlayerMove(m_Board, button.Row, button.Col);
                if (m_Player2Type == ePlayerTypes.Computer && m_GameManager.PlayerTurn == ePlayerTurn.Player2)
                { // If it is player2's turn and it is a computer
                    m_GameManager.GetComputerTurn(m_Board);
                }
            }
            catch (GameEndedException ex)
            {
                handleEndOfGame(ex.Winner);
            }
        }

        private void m_GameManager_ComputerPlayed(Position i_Position)
        {
            foreach (Control control in this.Controls)
            {
                if (control is MyButton)
                { // Verify it is a button
                    MyButton button = control as MyButton;
                    if (button.Row == i_Position.Row && button.Col == i_Position.Col)
                    { // Find the selected buttton
                        updateFormAndBoardOnButtonSelection(button);
                    }
                }
            }
        }
        #endregion Events

        #region Utills
        private void setFormSize()
        {
            int formWidth = k_StartXPosition + ((k_RightSpace + k_ButtonWidth) * m_Board.Size) + (k_StartXPosition - k_RightSpace);
            int formHeight = k_StartYPosition + ((k_ButtomSpace + k_ButtonHeight) * m_Board.Size);
            this.ClientSize = new Size(formWidth, formHeight);
        }

        private void createScoreLabel(Player i_Player1, Player i_Player2)
        {
            int xPosition;
            int yPosition;

            setLabelScoreText();
            xPosition = (this.ClientSize.Width / 2) - (labelScore.Width / 2);
            yPosition = this.ClientSize.Height;
            labelScore.Location = new Point(xPosition, yPosition);
            this.Controls.Add(labelScore);
        }

        private void setLabelScoreText()
        {
            labelScore.Text = string.Format("{0}: {1}   {2}: {3}", m_Player1Name, m_GameManager.Player1Score, m_Player2Name, m_GameManager.Player2Score);
        }

        private void createButtons()
        {
            for (int i = 0; i < m_Board.Size; i++)
            {
                for (int j = 0; j < m_Board.Size; j++)
                {
                    MyButton button = new MyButton(i, j);
                    initButton(button, i, j);
                    m_Board.Add(button, i, j);
                    this.Controls.Add(button);
                    button.Click += buttons_Click;
                }
            }
        }

        private void updateFormAndBoardOnButtonSelection(MyButton i_Button)
        {
            i_Button.Enabled = false;
            i_Button.Text = m_GameManager.PlayerSign.ToString();
            m_Board.Update(i_Button.Row, i_Button.Col);
        }

        private void handleEndOfGame(Player i_Winner)
        {
            if (i_Winner != null)
            {
                m_IsNewGameRequested = showWinnerMessage(i_Winner);
            }
            else
            {
                m_IsNewGameRequested = showTieMessage();
            }

            if (m_IsNewGameRequested == DialogResult.Yes)
            {
                startNewGame();
            }
            else
            {
                this.Close();
            }
        }

        private void startNewGame()
        {
            resetButtons();
            setLabelScoreText();
            m_Board.Reset();
        }

        private void resetButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is MyButton)
                {
                    control.Text = string.Empty;
                    control.Enabled = true;
                }
            }
        }

        private DialogResult showTieMessage()
        {
            string message = string.Format("Tie!{0}Would you like to play another round?", Environment.NewLine);
            return MessageBox.Show(message, "A Tie!", MessageBoxButtons.YesNo, MessageBoxIcon.None);
        }

        private DialogResult showWinnerMessage(Player i_Winner)
        {
            string message = string.Format("The winner is {0}!{1}Would you like to play another round?", i_Winner.Name, Environment.NewLine);
            return MessageBox.Show(message, "A Win!", MessageBoxButtons.YesNo, MessageBoxIcon.None);
        }

        private void initButton(Button i_Button, int i_Row, int i_Col)
        {
            int x = k_StartXPosition + ((k_RightSpace + k_ButtonWidth) * i_Col);
            int y = k_StartYPosition + ((k_ButtomSpace + k_ButtonHeight) * i_Row);

            i_Button.FlatStyle = FlatStyle.Standard;
            i_Button.Width = k_ButtonWidth;
            i_Button.Height = k_ButtonHeight;
            i_Button.Location = new Point(x, y);
            i_Button.Enabled = true;
            i_Button.Visible = true;
            i_Button.TabStop = false;
        }
        #endregion Utills
    }
}
