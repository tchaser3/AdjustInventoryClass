/* Title:           Adjust Inventory Class
 * Date:            6-9-17
 * Author:          Terry Holmes */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace AdjustInventoryDLL
{
    public class AdjustInventoryClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up the data
        AdjustInventoryDataSet aAdjustInventoryDataSet;
        AdjustInventoryDataSetTableAdapters.adjustinventoryTableAdapter aAdjustInventoryTableAdapter;

        InsertAdjustInventoryRecordDataTableAdapters.QueriesTableAdapter aInsertAdjustInventoryRecordTableAdapter;

        FindAdjustInventoryByDateRangeDataSet aFindAdjustInventoryByDateRangeDataSet;
        FindAdjustInventoryByDateRangeDataSetTableAdapters.FindAdjustInventoryByDateRangeTableAdapter aFindAdjustInventorybyDateRangeTableAdapter;

        FindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateDataSet aFindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateDataSet;
        FindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateDataSetTableAdapters.FindAdjustedInventoryByPartIDWarehouseIDEmployeeIDDateTableAdapter aFindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateTableAdapter;

        public FindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateDataSet FindAdjustInventoryByPartIDWarehouseIDEmployeeIDDate(int intPartID, int intWarehouseID, int intEmployeeID, DateTime datTransactionDate)
        {
            try
            {
                aFindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateDataSet = new FindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateDataSet();
                aFindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateTableAdapter = new FindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateDataSetTableAdapters.FindAdjustedInventoryByPartIDWarehouseIDEmployeeIDDateTableAdapter();
                aFindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateTableAdapter.Fill(aFindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateDataSet.FindAdjustedInventoryByPartIDWarehouseIDEmployeeIDDate, intPartID, intWarehouseID, intEmployeeID, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Adjust Inventory Class // Find Adjust Inventory By Part ID Warehouse ID Employee ID Date " + Ex.Message);
            }

            return aFindAdjustInventoryByPartIDWarehouseIDEmployeeIDDateDataSet;
        }
        public FindAdjustInventoryByDateRangeDataSet FindAdjustInventoryByDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindAdjustInventoryByDateRangeDataSet = new FindAdjustInventoryByDateRangeDataSet();
                aFindAdjustInventorybyDateRangeTableAdapter = new FindAdjustInventoryByDateRangeDataSetTableAdapters.FindAdjustInventoryByDateRangeTableAdapter();
                aFindAdjustInventorybyDateRangeTableAdapter.Fill(aFindAdjustInventoryByDateRangeDataSet.FindAdjustInventoryByDateRange, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Adjust Inventory Class // Find Adjust Inventory By Date Range " + Ex.Message);
            }

            return aFindAdjustInventoryByDateRangeDataSet;
        }
        public bool InsertAdjustInventoryRecord(int intPartID, int intQuantity, string strExplanation, int intEmployeeID, int intWarehouseID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertAdjustInventoryRecordTableAdapter = new InsertAdjustInventoryRecordDataTableAdapters.QueriesTableAdapter();
                aInsertAdjustInventoryRecordTableAdapter.InsertAdjustInventoryRecord(intPartID, intQuantity, strExplanation, intEmployeeID, DateTime.Now, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Adjust Inventory Class // Insert Adjust Inventory Record " + Ex.Message);
            }

            return blnFatalError;
        }
        public AdjustInventoryDataSet GetAdjustInventoryInfo()
        {
            try
            {
                aAdjustInventoryDataSet = new AdjustInventoryDataSet();
                aAdjustInventoryTableAdapter = new AdjustInventoryDataSetTableAdapters.adjustinventoryTableAdapter();
                aAdjustInventoryTableAdapter.Fill(aAdjustInventoryDataSet.adjustinventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Adjust Inventory Class // Get Adjust Inventory Info " + Ex.Message);
            }

            return aAdjustInventoryDataSet;
        }
        public void UpdateAdjustInventoryDB(AdjustInventoryDataSet aAdjustInventoryDataSet)
        {
            try
            {
                aAdjustInventoryTableAdapter = new AdjustInventoryDataSetTableAdapters.adjustinventoryTableAdapter();
                aAdjustInventoryTableAdapter.Update(aAdjustInventoryDataSet.adjustinventory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Adjust Inventory Class // Update Adjust Inventory DB " + Ex.Message);
            }
        }
    }
}
