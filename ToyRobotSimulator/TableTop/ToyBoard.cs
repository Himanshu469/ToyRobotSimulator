using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Interface;
using ToyRobotSimulator.Toy;

namespace ToyRobotSimulator.TableTop
{
    /// <summary>
    /// Toy Board class is the Table/Board where the toy is positioned.
    /// It has Properties for rows and Column
    /// </summary>
    public class ToyBoard :IValidateBoardPosition
    {
        #region Constructor
        public ToyBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }
        #endregion

        #region Public Properties
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public bool IsValidPosition(ToyPosition toyPosition)
        {
            return toyPosition.X < Columns && toyPosition.X >= 0 &&
                     toyPosition.Y < Rows && toyPosition.Y >= 0;
        }
        #endregion


    }
}
