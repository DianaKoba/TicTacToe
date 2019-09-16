namespace Tic_Tac_Toe_Game
{
    using System;
    using System.Collections.Generic;

    public class Cell<T> where T : class
    {
        #region Members
        private readonly Position r_Position;
        private eCellStatus m_CellStatus = eCellStatus.Empty;
        private T m_CellValue = null;
        #endregion Members

        #region Constructors
        internal Cell(Position i_Position)
        {
            r_Position.Row = i_Position.Row;
            r_Position.Col = i_Position.Col;
        }

        internal Cell(byte i_Row, byte i_Col)
        {
            r_Position.Row = i_Row;
            r_Position.Col = i_Col;
        }
        #endregion Constructors

        #region Properties
        internal Position Position
        {
            get
            {
                return r_Position;
            }
        }

        internal T Value
        {
            get
            {
                return m_CellValue;
            }

            set
            {
                m_CellValue = value;
            }
        }

        internal eCellStatus Status
        {
            get
            {
                return m_CellStatus;
            }

            set
            {
                m_CellStatus = value;
            }
        }
        #endregion Properties
    }
}