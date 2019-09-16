namespace Tic_Tac_Toe_Game
{
    public struct Position
    {
        #region Members
        private uint m_X;
        private uint m_Y;
        #endregion Members

        #region Properties
        public uint Row
        {
            get
            {
                return m_X;
            }

            set
            {
                m_X = value;
            }
        }

        public uint Col
        {
            get
            {
                return m_Y;
            }

            set
            {
                m_Y = value;
            }
        }
        #endregion Properties
    }
}
