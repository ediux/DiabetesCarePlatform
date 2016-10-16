using DiabetesCarePlatform.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using DiabetesCarePlatform;
using DiabetesCarePlatform.Models.DataTable;

namespace DiabetesCarePlatform.Controllers
{
    public class HealthEduController : Controller
    {
        //
        // GET: /HealthEdu/
        public ActionResult Index()
        {
            HealthEduRepository mHealthEduRepository = new HealthEduRepository();
            CG_HealthEducationResultModel rm = mHealthEduRepository.SP_GetCG_HealthEducationList(10);
            return View(rm);
        }
        public ActionResult Article(int NewsID)
        {
            CG_HealthEducation mCG_HealthEducation;
            if (NewsID > 0)
            {
                HealthEduRepository mHealthEduRepository = new HealthEduRepository();
                mCG_HealthEducation = mHealthEduRepository.SP_GetCG_HealthEducation(NewsID);
            }
            else
            {
                mCG_HealthEducation = new CG_HealthEducation();
            }
            return View(mCG_HealthEducation);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Article(int NewsID, string Enable, string Title = null, string MyText = null, string PublishDate = null, string EndDate = null)
        {
            CG_HealthEducation mCG_HealthEducation = new CG_HealthEducation();
            mCG_HealthEducation.NewsID = NewsID;
            if (Enable == "1")
            {
                mCG_HealthEducation.NewsType = 0;
                mCG_HealthEducation.Title = Title;
                mCG_HealthEducation.SubTitle = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline).Replace(MyText, " ").Trim();
                mCG_HealthEducation.SmallPictureUrl = Regex.Match(MyText, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
                mCG_HealthEducation.HtmlBody = MyText;
                mCG_HealthEducation.PublishDate = Convert.ToDateTime(PublishDate);
                mCG_HealthEducation.EndDate = Convert.ToDateTime(EndDate);
                mCG_HealthEducation.Enable = true;
            }
            else
            {
                mCG_HealthEducation.NewsType = 0;
                mCG_HealthEducation.Title = "";
                mCG_HealthEducation.SubTitle ="";
                mCG_HealthEducation.SmallPictureUrl = "";
                mCG_HealthEducation.HtmlBody = "";
                mCG_HealthEducation.PublishDate = DateTime.Today;
                mCG_HealthEducation.EndDate = DateTime.Today;
                mCG_HealthEducation.Enable = false;
            }
            mCG_HealthEducation.LastUserID = 1;
            HealthEduRepository mHealthEduRepository = new HealthEduRepository();
            mHealthEduRepository.Update(mCG_HealthEducation);

            //return Redirect("~/HealthEdu");
            return RedirectToAction("Index");



        }
        public void uploadnow(HttpPostedFileWrapper upload)
        {
            if (upload != null)
            {
                string ImageName = upload.FileName;
                //string path = System.IO.Path.Combine(Server.MapPath("~/Images/uploads"), ImageName);
                //string path = System.IO.Path.Combine(@"D:\DCP\CODE\UploadImg", ImageName);
                string path = System.IO.Path.Combine(@"D:\Ap\糖特\DiabetesCarePlatform\DiabetesCarePlatform\UploadImg", ImageName);


                upload.SaveAs(path);
            }
        }

        public ActionResult uploadPartial()
        {
            var appData = @"D:\DCP\CODE\UploadImg";
            var images = Directory.GetFiles(appData).Select(x => new ImagesViewModel
            {
                Url = Url.Content(@"D:\Ap\糖特\DiabetesCarePlatform\DiabetesCarePlatform\UploadImg/" + Path.GetFileName(x))
            });
            return View(images);
        }

        /// <summary>
        /// ckeditor上傳圖片
        /// </summary>
        /// <param name="upload">預設參數叫upload</param>
        /// <param name="CKEditorFuncNum"></param>
        /// <param name="CKEditor"></param>
        /// <param name="langCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadPicture(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string result = "";
            if (upload != null && upload.ContentLength > 0)
            {
                string Extension = Path.GetExtension(upload.FileName);
                string FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Extension;
                //儲存圖片至Server
                upload.SaveAs(Server.MapPath("~/UploadImg/" + FileName));


                var imageUrl = Url.Content("~/UploadImg/" + FileName);

                var vMessage = string.Empty;

                result = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + imageUrl + "\", \"" + vMessage + "\");</script></body></html>";

            }

            return Content(result);
        }
    }
}