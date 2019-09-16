namespace Tic_Tac_Toe_Game
{
    using System;
    using System.Windows.Forms;

    public delegate void MoveEventHandler(Position i_Position);

    public class GameManager
    {
        #region Members
        private Player m_Player1;
        private Player m_Player2;
        private ePlayerTurn m_PlayerTurn;

        public event MoveEventHandler ComputerPlayed;
        #endregion Members

        #region Constructor
        public GameManager(Player i_Player1, Player i_Player2)
        {
            m_Player1 = i_Player1;
            m_Player1.Sign = eCellValues.X;
            m_Player1.Score = 0;
            m_Player2 = i_Player2;
            m_Player2.Sign = eCellValues.O;
            m_Player2.Score = 0;
            m_PlayerTurn = ePlayerTurn.Player1;
        }
        #endregion Constructor

        #region Properties
        public eCellValues PlayerSign
        {
            get
            {
                eCellValues sign;

                if (m_PlayerTurn == ePlayerTurn.Player1)
                {
                    sign = m_Player1.Sign;
                }
                else
                {
                    sign = m_Player2.Sign;
                }

                return sign;
            }
        }

        public ePlayerTurn PlayerTurn
        {
            get
            {
                return m_PlayerTurn;
            }
        }

        public byte Player1Score
        {
            get
            {
                return m_Player1.Score;
            }
        }

        public byte Player2Score
        {
            get
            {
                return m_Player2.Score;
            }
        }
        #endregion Properties

        #region Public Services
        public void ReactToPlayerMove(Board i_Board, int i_Row, int i_Col)
        {
            if (GameLogic.IsGameEnded(i_Board, (byte)i_Row, (byte)i_Col))
            {
                if (GameLogic.IsThereAWinner(i_Board, (byte)i_Row, (byte)i_Col))
                {
                    if (m_PlayerTurn == ePlayerTurn.Player1)
                    {
                        m_Player1.Score++;
                        throw new GameEndedException(m_Player1);
                    }
                    else
                    {
                        m_Player2.Score++;
                        throw new GameEndedException(m_Player2);
                    }
                }
                else
                { // Tie
                    throw new GameEndedException(null);
                }
            }
            else
            { // Game did not end. switch turns.
                m_PlayerTurn = (m_PlayerTurn == ePlayerTurn.Player1) ? ePlayerTurn.Player2 : ePlayerTurn.Player1;
            }
        }

        public void GetComputerTurn(Board i_Board)
        {
            Position position;

            do
            {
                position = m_Player2.MakeAMove(i_Board);
            }
            while (!GameLogic.IsValidMove(i_Board, (int)position.Row, (int)position.Col));

            onComputerPlayed(position);
            ReactToPlayerMove(i_Board, (int)position.Row, (int)position.Col);
        }
        #endregion Public Services

        #region Utills
        private void onComputerPlayed(Position i_Position)
        {
            if (ComputerPlayed != null)
            {
                ComputerPlayed.Invoke(i_Position);
            }
        }
        #endregion Utills
    }
}
