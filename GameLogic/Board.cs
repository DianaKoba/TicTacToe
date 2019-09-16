namespace Tic_Tac_Toe_Game
{
    using System;
    using System.Text;
    using System.Windows.Forms;

    public class Board
    {
        #region Members
        #region Consts
        private const char k_HorizontalDelimeter = '=';
        private const char k_VerticalLine = '|';
        private const char k_Space = ' ';
        private const byte k_MaxSizeOfBoard = 10;
        private const byte k_MinSizeOfBoard = 4;
        #endregion Consts
        private byte m_Size = 0;
        private Cell<MyButton>[,] m_Cells = null;
        private byte m_OccupiedCells = 0;
        #endregion Members

        #region Properties
        public static byte MaxSize
        {
            get
            {
                return k_MaxSizeOfBoard;
            }
        }

        public static byte MinSize
        {
            get
            {
                return k_MinSizeOfBoard;
            }
        }

        public byte Size
        {
            get
            {
                return m_Size;
            }

            set
            {
                m_Size = (value < k_MinSizeOfBoard || value > k_MaxSizeOfBoard) ? (byte)0 : value;
            }
        }

        public bool IsFull
        {
            get
            {
                return m_OccupiedCells == m_Size * m_Size;
            }
        }
        #endregion Properties

        #region Public Services
        public Cell<MyButton> this[byte i_Row, byte i_Col]
        {
            get
            {
                Cell<MyButton> result = null;

                if (i_Row >= 0 && i_Row < m_Size && i_Col >= 0 && i_Col < m_Size)
                {
                    result = m_Cells[i_Row, i_Col];
                }

                return result;
            }

            set
            {
                if (i_Row >= 0 && i_Row < m_Size && i_Col >= 0 && i_Col < m_Size)
                {
                    m_Cells[i_Row, i_Col].Value = value.Value;
                }
            }
        }

        public void Update(int i_Row, int i_Col)
        {
            m_Cells[i_Row, i_Col].Status = eCellStatus.Occupied;
            m_OccupiedCells++;
        }

        public void Create()
        {
            m_OccupiedCells = 0;
            m_Cells = new Cell<MyButton>[m_Size, m_Size];
            for (byte i = 0; i < m_Size; i++)
            {
                for (byte j = 0; j < m_Size; j++)
                {
                    m_Cells[i, j] = new Cell<MyButton>(i, j);
                }
            }
        }

        public void Add(MyButton i_Button, int i_Row, int i_Col)
        {
            m_Cells[i_Row, i_Col].Value = i_Button;
        }

        public void Reset()
        {
            foreach (Cell<MyButton> cell in m_Cells)
            {
                cell.Value.Text = string.Empty;
                cell.Status = eCellStatus.Empty;
            }

            m_OccupiedCells = 0;
        }
        #endregion Public Services
    }
}