namespace GameUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum ePlayerTypes
    {
        None,
        Person,
        Computer
    }

    public struct GameInfo
    {
        private string m_Player1Name;
        private string m_Player2Name = "Computer";
        private ePlayerTypes m_Player2Type = ePlayerTypes.Computer;

        public string Player1Name
        {
            get
            {
                return m_Player1Name;
            }

            set
            {
                if (verifyName(value))
                {
                    m_Player1Name = value;
                }
            }
        }

        private bool verifyName(string i_Name)
        {
            bool isOK = true;

            foreach (char c in i_Name)
            {
                if (!char.IsLetter(c))
                {
                    isOK = false;
                    break;
                }
            }

            return isOK;
        }
    }
}
