using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using DiabetesCarePlatform.Models;
using DiabetesCarePlatform.Models.DataTable;
using DiabetesCarePlatform.Repository;

namespace DiabetesCarePlatform
{
    public class HealthEduRepository 
    {
        BaseRepository Dap = new BaseRepository();
        public string Message;

        public CG_HealthEducationResultModel SP_GetCG_HealthEducationList(int mDisplayRecords)
        {
            CG_HealthEducationResultModel rm = new CG_HealthEducationResultModel();
            Dictionary<String, Object> field = new Dictionary<string, object>();
            rm.aaData=Dap.ModelListSP<CG_HealthEducation>("SP_GetCG_HealthEducationList", field);
            rm.iTotalRecords = rm.aaData.Count();
            rm.iTotalDisplayRecords = mDisplayRecords;
            return rm;
        }

        public CG_HealthEducation SP_GetCG_HealthEducation(int NewsID)
        {
            CG_HealthEducation mCG_HealthEducation = new CG_HealthEducation();
            Dictionary<String, Object> field = new Dictionary<string, object>();
            field.Add("@NewsID", NewsID);
            return Dap.ModelListSP<CG_HealthEducation>("SP_GetCG_HealthEducation", field)[0];

        }


        public bool Update(CG_HealthEducation mCG_HealthEducation)
        {
            Dictionary<String, Object> field = new Dictionary<string, object>();
            try
            {
                field.Add("NewsID", mCG_HealthEducation.NewsID);
                field.Add("NewsType", mCG_HealthEducation.NewsType);
                field.Add("PublishDate", mCG_HealthEducation.PublishDate);
                field.Add("EndDate", mCG_HealthEducation.EndDate);
                field.Add("Title", mCG_HealthEducation.Title);
                field.Add("SmallPictureUrl", mCG_HealthEducation.SmallPictureUrl);
                field.Add("Subtitle", mCG_HealthEducation.SubTitle);
                field.Add("HtmlBody", mCG_HealthEducation.HtmlBody);
                field.Add("Enable", mCG_HealthEducation.Enable);
                Dap.NonQuerySP("SP_UpdateCG_HealthEducation", field);
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

    }
}