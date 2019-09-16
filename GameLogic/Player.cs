namespace Tic_Tac_Toe_Game
{
    using System;

    public class Player
    {
        #region Members
        private string m_Name = string.Empty;
        private ePlayerTypes m_Type = ePlayerTypes.None;
        private byte m_Score = 0;
        private eCellValues m_Sign = eCellValues.None;
        #endregion Members

        #region Properties
        public byte Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public eCellValues Sign
        {
            get
            {
                return m_Sign;
            }

            set
            {
                m_Sign = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                if (IsValidName(value))
                {
                    m_Name = value;
                }
                else
                {
                    throw new FormatException(string.Format("Invalid name <{0}>", value));
                }
            }
        }

        public ePlayerTypes Type
        {
            get
            {
                return m_Type;
            }

            set
            {
                m_Type = value;
            }
        }
        #endregion Properties

        #region Public Services
        public static bool IsValidName(string i_Name)
        {
            bool isValidName = true;

            foreach (char c in i_Name)
            {
                if (!IsCharValid(c))
                {
                    isValidName = false;
                    break;
                }
            }

            return isValidName;
        }

        public static bool IsCharValid(char i_Char)
        {
            return char.IsLetter(i_Char) || char.IsWhiteSpace(i_Char);
        }

        internal Position MakeAMove(Board i_Board)
        {
            Position selectedPosition = default(Position);
            Random random = new Random();

            selectedPosition.Row = (byte)(random.Next(Board.MinSize, Board.MaxSize + 1) % i_Board.Size);
            selectedPosition.Col = (byte)(random.Next(Board.MinSize, Board.MaxSize + 1) % i_Board.Size);

            return selectedPosition;
        }
        #endregion Public Services
    }
}
