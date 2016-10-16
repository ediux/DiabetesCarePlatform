using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesCarePlatform.Models
{
    public class DCCare_BloodPressurePage
    {

        public int PatientID { get; set; }
        public int PressureDay { get; set; }

        public int Systolic_TopHighValue { get; set; }
        public int Systolic_TopLowValue { get; set; }
        public int Systolic_AvgValue { get; set; }

        public int Diastolic_TopHighValue { get; set; }
        public int Diastolic_TopLowValue { get; set; }
        public int Diastolic_AvgValue { get; set; }

        public int Heartbeat_TopHighValue { get; set; }
        public int Heartbeat_TopLowValue { get; set; }
        public int Heartbeat_AvgValue { get; set; }

        public int Systolic_LowerCount { get; set; }
        public int Systolic_HigherCount { get; set; }
        public int Systolic_GoodCount { get; set; }
        public int Systolic_TotalCount { get; set; }

        public int Diastolic_LowerCount { get; set; }
        public int Diastolic_HigherCount { get; set; }
        public int Diastolic_GoodCount { get; set; }
        public int Diastolic_TotalCount { get; set; }

        public int Heartbeat_LowerCount { get; set; }
        public int Heartbeat_HigherCount { get; set; }
        public int Heartbeat_GoodCount { get; set; }
        public int Heartbeat_TotalCount { get; set; }

        public BloodSugarTable TableData { get; set; }
        public BarChart SectionCountData { get; set; }
        public LineChart TrendData { get; set; }
        public List<PieChartData> Heartbeat_BoundCountData { get; set; }
        public List<PieChartData> Diastolic_BoundCountData { get; set; }
        public List<PieChartData> Systolic_BoundCountData { get; set; }
        public List<BloodPressureData> PressureList { get; set; }
        //public List<MealTypeTimingType> MealTimingType { get; set; }
    }
    public class BloodPressureData
    {
        public Int64 ID { get; set; }
        public int AppUserID { get; set; }
        public string Date { get; set; }
        public string WeekDay { get; set; }
        public string Time { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public int Heartbeat { get; set; }
        public DateTime RecordTime { get; set; }
    }

    //public class PressureType
    //{
    //    public int MealTypeID { get; set; }
    //    public string MealTypeName { get; set; }
    //    public int TimingTypeID { get; set; }
    //    public string TimingTypeName { get; set; }
    //}
}