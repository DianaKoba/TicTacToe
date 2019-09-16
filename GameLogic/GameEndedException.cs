namespace Tic_Tac_Toe_Game
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GameEndedException : Exception
    {
        #region Members
        private Player m_Winner;
        private bool m_IsTie;
        #endregion Members

        #region Constructor
        public GameEndedException(Player i_Winner)
        {
            if (i_Winner != null)
            {
                m_Winner = i_Winner;
                m_IsTie = false;
            }
            else
            {
                i_Winner = null;
                m_IsTie = true;
            }
        }
        #endregion Constructor

        #region Properties
        public Player Winner
        {
            get
            {
                return m_Winner;
            }
        }
        #endregion Properties
    }
}
