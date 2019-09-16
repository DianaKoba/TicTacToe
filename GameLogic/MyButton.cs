namespace Tic_Tac_Toe_Game
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;

    public partial class MyButton : Button
    {
        #region Members
        private readonly int r_Row;
        private readonly int r_Col;
        #endregion Members

        #region Constructor
        public MyButton(int i_Row, int i_Col)
        {
            InitializeComponent();
            r_Row = i_Row;
            r_Col = i_Col;
        }
        #endregion Constructor

        #region Properties
        public int Row
        {
            get
            {
                return r_Row;
            }
        }

        public int Col
        {
            get
            {
                return r_Col;
            }
        }
        #endregion Properties
    }
}
