using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace DBL
{
    public class Helper
    {
        public static void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                {
                    if (row.Cells[cellIndex].Text != "")
                        if (row.Cells[cellIndex].Text == previousRow.Cells[cellIndex].Text)
                        {
                            row.Cells[cellIndex].RowSpan = previousRow.Cells[cellIndex].RowSpan < 2 ? 2 : previousRow.Cells[cellIndex].RowSpan + 1;
                            previousRow.Cells[cellIndex].Visible = false;
                        }
                }
            }
        }


        public static void MergeRowsforNeedsAvailble(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int cellIndex = 0; cellIndex < 3; cellIndex++)
                {
                    if (row.Cells[cellIndex].Text != "")
                        if (row.Cells[cellIndex].Text == previousRow.Cells[cellIndex].Text)
                        {
                            row.Cells[cellIndex].RowSpan = previousRow.Cells[cellIndex].RowSpan < 2 ? 2 : previousRow.Cells[cellIndex].RowSpan + 1;
                            previousRow.Cells[cellIndex].Visible = false;
                        }
                }
            }
        }
    }
}
