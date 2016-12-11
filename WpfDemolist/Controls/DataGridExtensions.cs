#region using

using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections;

#endregion using

namespace WpfDemolist.Controls
{
    public static class DataGridExtensions
    {
        internal static DataGridSelectColumn GetSelectColumn(this DataGrid dataGrid)
        {
            DataGridSelectColumn result = null;

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                result = dataGrid.Columns[i] as DataGridSelectColumn;

                if (result != null)
                {
                    break;
                }
            }

            return result;
        }

        public static void EnableSelect(this DataGrid dataGird)
        {
            var column = GetSelectColumn(dataGird);
            column.OwerDataGrid = dataGird;
        }

        public static void SelectAll(this DataGrid dataGrid)
        {
            DataGridSelectColumn column = GetSelectColumn(dataGrid);

            if (column == null)
            {
                throw new Exception("No Select Column");
            }

            column.SelecteAll();
        }

        public static void UnselectAll(this DataGrid dataGrid)
        {
            DataGridSelectColumn column = GetSelectColumn(dataGrid);

            if (column == null)
            {
                throw new Exception("No Select Column");
            }

            column.UnselectAll();
        }

        public static List<T> GetSelectedItems<T>(this DataGrid dataGrid)
        {
            DataGridSelectColumn column = GetSelectColumn(dataGrid);

            if (column == null)
            {
                throw new Exception("No Select Column");
            }

            return column.GetSelectedItems<T>();
        }

        public static void SetSelectedItems(this DataGrid dataGrid, IList items)
        {
            DataGridSelectColumn column = GetSelectColumn(dataGrid);

            if (column == null)
            {
                throw new Exception("No Select Column");
            }

            column.SetSelectedItems(items);
        }
    }
}