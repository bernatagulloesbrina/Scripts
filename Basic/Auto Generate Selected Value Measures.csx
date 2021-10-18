/*
 * Title: Auto-generate SELECTEDVALUE measures from columns
 * 
 * Author: '2021-07-30 / B.Agullo / twitter.com/AgulloBernat 
 * based on code from Daniel Otykier, twitter.com/DOtykier
 * 
 * This script, when executed, will loop through the currently selected columns,
 * creating one SELECTED measure for each column 
 */
 
// Loop through all currently selected columns:
foreach(var c in Selected.Columns)
{
    var newMeasure = c.Table.AddMeasure(
        "SELECTED " + c.Name,                    // Name
        "SELECTEDVALUE(" + c.DaxObjectFullName + ")",    // DAX expression
        c.DisplayFolder                        // Display Folder
    );
    
    // Set the format string on the new measure:
    newMeasure.FormatString = c.FormatString;

    // Provide some documentation:
    newMeasure.Description = "This measure is the selected value of " + c.DaxObjectFullName;

    // Hide the base column:
    //c.IsHidden = true;
}
