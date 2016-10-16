using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class DCCare_BloodSugarPage
    {
        public int PatientID { get; set; }
        public int GlucoseDay { get; set; }
        public int TopHighValue { get; set; }
        public int TopLowValue { get; set; }
        public int AvgValue { get; set; }
        public int LowerCount { get; set; }
        public int HigherCount { get; set; }
        public int GoodCount { get; set; }
        public int TotalCount { get; set; }
        public BloodSugarTable TableData { get; set; }
        public BarChart SectionCountData { get; set; }
        public BarChart BeforeAfterMealData { get; set; }
        public LineChart TrendData { get; set; }
        public List<PieChartData> BoundCountData { get; set; }
        public List<MealTypeTimingType> MealTimingType { get; set; }
    }
    public class MealTypeTimingType
    {
        public int MealTypeID { get; set; }
        public string MealTypeName { get; set; }
        public int TimingTypeID { get; set; }
        public string TimingTypeName { get; set; }
        public bool Checked { get; set; }
    }
    public class BloodSugarTable
    {
        public List<BloodSugarTableRow> Body { get; set; }
        public List<BloodSugarTableRow> Foot { get; set; }
    }
    public class BloodSugarTableRow
    {
        public string RecordDate { get; set; }
        public List<U_BloodSugar> RecordValue { get; set; }
        public List<decimal> Value { get; set; }
    }

    public class BarChart
    {
        public List<string> labels { get; set; }
        public List<BarChartData> datasets { get; set; }
    }
    public class LineChart
    {
        public List<string> labels { get; set; }
        public List<LineChartData> datasets { get; set; }
    }
    public class PieChartData
    {
        public int value { get; set; }
        public string color { get; set; }
        public string highlight { get; set; }
        public string label { get; set; }
        public string labelColor { get; set; }
        public int labelFontSize { get; set; }
    }
    public class BarChartData
    {
        public List<int> data { get; set; }
        public string fillColor { get; set; }
        public string strokeColor { get; set; }
        public string highlightFill { get; set; }
        public string highlightStroke { get; set; }
        public string label { get; set; }
    }
    public class LineChartData
    {
        public string label { get; set; } 
        public string metadata { get; set; }
        public List<string> data { get; set; }
        public string fillColor { get; set; }
        public string strokeColor { get; set; }
        public string pointColor { get; set; }
        public string pointStrokeColor { get; set; }
        public string pointHighlightFill { get; set; }
        public string pointHighlightStroke { get; set; }
    }
}