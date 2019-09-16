namespace Tic_Tac_Toe_Game
{
    using System;

    public class GameLogic
    {
        #region Members
        private static eCellValues s_WinnerSign = eCellValues.None;
        #endregion Members

        #region Public Services
        public static eCellValues SignOfTheWinner 
        {
            get
            {
                return s_WinnerSign;
            }
        }

        public static bool IsGameEnded(Board i_Board, byte i_Row, byte i_Col)
        {
            return i_Board.IsFull ||
                   IsThereAWinner(i_Board, i_Row, i_Col);
        }

        public static bool IsThereAWinner(Board i_Board, byte i_Row, byte i_Col)
        {
            bool isThereAWinner = false;

            if (!checkRow(i_Board, i_Row) && !checkCol(i_Board, i_Col))
            {
                if (i_Row == i_Col)
                { // Position on the main diagonal
                    isThereAWinner = checkMainDiagonal(i_Board);
                }

                if (!isThereAWinner && isCellOnSecondaryDiagonal(i_Board, i_Row, i_Col))
                {
                    isThereAWinner = checkSecondaryDiagonal(i_Board);
                }
            }
            else
            {
                isThereAWinner = true;
            }

            return isThereAWinner;
        }

        public static bool IsValidMove(Board i_Board, int i_Row, int i_Col)
        {
            bool isValidMove = true;

            if (i_Board[(byte)i_Row, (byte)i_Col].Status == eCellStatus.Occupied)
            {
                isValidMove = false;
            }

            return isValidMove;
        }
        #endregion Public Services

        #region Utills
        private static bool checkSecondaryDiagonal(Board i_Board)
        {
            bool isThereASequence = true;
            byte row = 0;
            byte col = (byte)(i_Board.Size - 1);
            eCellValues firstValChecked;

            if (i_Board[row, col].Value.Text != string.Empty)
            {
                firstValChecked = (eCellValues)Enum.Parse(typeof(eCellValues), i_Board[row, col].Value.Text);
                while (row + 1 < i_Board.Size)
                {
                    row++;
                    col--;
                    if (firstValChecked.ToString() != i_Board[row, col].Value.Text)
                    {
                        isThereASequence = false;
                        break;
                    }
                }

                if (isThereASequence)
                {
                    s_WinnerSign = firstValChecked;
                }
            }
            else
            {
                isThereASequence = false;
            }

            return isThereASequence;
        }

        private static bool isCellOnSecondaryDiagonal(Board i_Board, byte i_Row, byte i_Col)
        {
            return i_Row + i_Col + 1 == i_Board.Size;
        }

        private static bool checkMainDiagonal(Board i_Board)
        {
            bool isThereASequence = true;
            byte row = 0;
            byte col = 0;
            eCellValues firstValChecked;

            if (i_Board[row, col].Value.Text != string.Empty)
            {
                firstValChecked = (eCellValues)Enum.Parse(typeof(eCellValues), i_Board[row, col].Value.Text);
                while (row + 1 < i_Board.Size)
                {
                    row++;
                    col++;
                    if (firstValChecked.ToString() != i_Board[row, col].Value.Text)
                    {
                        isThereASequence = false;
                        break;
                    }
                }

                if (isThereASequence)
                {
                    s_WinnerSign = firstValChecked;
                }
            }
            else
            {
                isThereASequence = false;
            }

            return isThereASequence;
        }

        private static bool checkCol(Board i_Board, byte i_Col)
        {
            bool isThereASequence = true;
            eCellValues firstValChecked;

            if (i_Board[0, i_Col].Value.Text != string.Empty)
            {
                firstValChecked = (eCellValues)Enum.Parse(typeof(eCellValues), i_Board[0, i_Col].Value.Text);
                for (byte i = 1; i < i_Board.Size; i++)
                {
                    if (firstValChecked.ToString() != i_Board[i, i_Col].Value.Text)
                    {
                        isThereASequence = false;
                        break;
                    }
                }

                if (isThereASequence)
                {
                    s_WinnerSign = firstValChecked;
                }
            }
            else
            {
                isThereASequence = false;
            }

            return isThereASequence;
        }

        private static bool checkRow(Board i_Board, byte i_Row)
        {
            bool isThereASequence = true;
            eCellValues firstValChecked;

            if (i_Board[i_Row, 0].Value.Text != string.Empty)
            {
                firstValChecked = (eCellValues)Enum.Parse(typeof(eCellValues), i_Board[i_Row, 0].Value.Text);
                for (byte i = 1; i < i_Board.Size; i++)
                {
                    if (firstValChecked.ToString() != i_Board[i_Row, i].Value.Text)
                    {
                        isThereASequence = false;
                        break;
                    }
                }

                if (isThereASequence)
                {
                    s_WinnerSign = firstValChecked;
                }
            }
            else
            {
                isThereASequence = false;
            }

            return isThereASequence;
        }
        #endregion Utills
    }
}
