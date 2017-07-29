using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace digitallearningback.Util
{
    public class UploadFileHelper
    {

        private static String[] imageTypes = new string[] { "image/jpg", "image/jpeg", "image/png" };

        public static Boolean validImageTypes(String contentType) {
            return imageTypes.Any(t => t.Equals(contentType));
        }

        public static String uploadFile(Controller ctr , HttpPostedFileBase uploadFile, String dirKey, String urlKey) {

            var uploadDir = System.Configuration.ConfigurationManager.AppSettings[dirKey].ToString();
            var uploadUrl = System.Configuration.ConfigurationManager.AppSettings[urlKey].ToString();

            String fileId = Guid.NewGuid().ToString().Replace("-", "");

            String filename = fileId + Path.GetExtension(uploadFile.FileName);

            var imagePath = Path.Combine(ctr.Server.MapPath(uploadDir), filename);

            uploadFile.SaveAs(imagePath);

            return uploadUrl + filename;

        }
    }
}