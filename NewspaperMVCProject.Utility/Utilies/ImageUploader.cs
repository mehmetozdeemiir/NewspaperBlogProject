using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewspaperMVCProject.Utility.Utilies
{
    public class ImageUploader
    {
        public static string DefaultProfileImagePath = "/Content/Uploads/UserImages/OriginalImages/userlogo.jpg";
        public static string DefaultXSmallProfileImagePath = "/Content/Uploads/UserImages/XSmallImages/userlogo.jpg";
        public static string DefaultCruptedProfileImagePath = "/Content/Uploads/UserImages/CruptedImages/userlogo.jpg";

        public static string OriginalProfileImagePath = "~/Content/Uploads/UserImages/OriginalImages/";

        public static List<string> UploadSingleImage(string serverPath, HttpPostedFileBase file, int saveAsParam)
        {
            string OriginalImagePath = "~/Content/Uploads/UserImages/OriginalImages/";
            string XSmallImagePath = "~/Content/Uploads/UserImages/XSmallImages/";
            string CruptedImagePath = "~/Content/Uploads/UserImages/CruptedImages/";

            List<string> ImagePaths = new List<string>();

            if (file != null)
            {
                var uniqueName = Guid.NewGuid();

                serverPath = serverPath.Replace("~", string.Empty);

               
                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();
                var fileName = uniqueName + "." + extension;

                if (extension == "jpg" || extension == "jpeg" || extension == "png" || extension=="jfif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        ImagePaths.Add("1");
                        return ImagePaths;
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);

                        file.SaveAs(filePath);

                        ImageResizer.ResizeSettings ImageSettings = new ImageResizer.ResizeSettings();
                        ImageSettings.Width = 30;
                        ImageSettings.Height = 30;
                        ImageSettings.Mode = ImageResizer.FitMode.Crop;

                        ImageResizer.ImageBuilder.Current.Build(OriginalImagePath + fileName, XSmallImagePath + fileName, ImageSettings);

                        if (saveAsParam == 1)
                        {
                            ImageSettings.Width = 150;
                            ImageSettings.Height = 150;
                            ImageSettings.Mode = ImageResizer.FitMode.Crop;
                        }
                        else
                        {
                            ImageSettings.Width = 250;
                            ImageSettings.Height = 250;
                            ImageSettings.Mode = ImageResizer.FitMode.Crop;
                        }

                        ImageResizer.ImageBuilder.Current.Build(OriginalImagePath + fileName, CruptedImagePath + fileName, ImageSettings);

                        ImagePaths.Add(serverPath + fileName);
                        ImagePaths.Add(XSmallImagePath.Replace("~", string.Empty) + fileName);
                        ImagePaths.Add(CruptedImagePath.Replace("~", string.Empty) + fileName);

                        return ImagePaths;
                    }
                }
                else
                {
                    ImagePaths.Add("2");
                    return ImagePaths;
                }
            }
            else
            {
                ImagePaths.Add("3");
                return ImagePaths;
            }
        }
    }
}
