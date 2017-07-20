using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Helpers;
using System.Web.Hosting;
using HttpRequest = Microsoft.AspNetCore.Http.HttpRequest;

namespace Sign.HelperClasses
{
    public class FilesHelper
    {
        readonly String _deleteUrl;
        readonly String _deleteType;
        readonly String _storageRoot;
        readonly String _urlBase;
        readonly String _serverMapPath;

        public FilesHelper(String deleteUrl, String deleteType, String storageRoot, String urlBase, String serverMapPath)
        {
           _deleteUrl = deleteUrl;
            _deleteType = deleteType;
            _storageRoot = storageRoot;
            _urlBase = urlBase;
            _serverMapPath = serverMapPath;
        }

        public void DeleteFiles(String pathToDelete)
        {
         
            string path = HostingEnvironment.MapPath(pathToDelete);

         
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo fi in di.GetFiles())
                {
                    File.Delete(fi.FullName);
                   
                }

                di.Delete(true);
            }
        }

        public String DeleteFile(String file)
        {
         
            String fullPath = Path.Combine(_storageRoot, file);
         
            String thumbPath = "/" + file + "80x80.jpg";
            String partThumb1 = Path.Combine(_storageRoot, "thumbs");
            String partThumb2 = Path.Combine(partThumb1, file + "80x80.jpg");

         
            if (System.IO.File.Exists(fullPath))
            {
                //delete thumb 
                if (System.IO.File.Exists(partThumb2))
                {
                    System.IO.File.Delete(partThumb2);
                }
                System.IO.File.Delete(fullPath);
                String succesMessage = "Ok";
                return succesMessage;
            }
            String failMessage = "Error Delete";
            return failMessage;
        }
        public JsonFiles GetFileList()
        {

            var r = new List<ViewDataUploadFilesResult>();
       
            String fullPath = Path.Combine(_storageRoot);
            if (Directory.Exists(fullPath))
            {
                DirectoryInfo dir = new DirectoryInfo(fullPath);
                foreach (FileInfo file in dir.GetFiles())
                {
                    int SizeInt = unchecked((int)file.Length);
                    r.Add(UploadResult(file.Name,SizeInt,file.FullName));
                }

            }
            JsonFiles files = new JsonFiles(r);

            return files;
        }

        
        public void UploadWholeFile(HttpRequest requestContext, List<ViewDataUploadFilesResult> statuses)
        {
            foreach (var file in requestContext.Form.Files)
            {
                String pathOnServer = _storageRoot;
                var fullPath = Path.Combine(pathOnServer, Path.GetFileName(file.FileName));
                var streamdata = new FileStream(fullPath, FileMode.Create);
                file.CopyTo(streamdata);
                streamdata.Flush();
                streamdata.Close();
                streamdata.Dispose();
    
                //Create thumb
                string[] imageArray = file.FileName.Split('.');
                if (imageArray.Length != 0)
                {
                    String extansion = imageArray[imageArray.Length - 1].ToLower();
                    if (extansion != "jpg" && extansion != "png" && extansion != "jpeg") //Do not create thumb if file is not an image
                    {
                        
                    }
                    else
                    {
                        var ThumbfullPath = Path.Combine(pathOnServer, "thumbs");
                        //String fileThumb = file.FileName + ".80x80.jpg";
                        String fileThumb = Path.GetFileNameWithoutExtension(file.FileName) + "80x80.jpg";
                        var ThumbfullPath2 = Path.Combine(ThumbfullPath, fileThumb);
                        using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(fullPath)))
                        {
                            Image image = Image.FromStream(stream);

                            Image thumb = image.GetThumbnailImage(80, 80, () => false, IntPtr.Zero);
                            thumb.Save(ThumbfullPath2 , ImageFormat.Jpeg);
                        }

                    }
                }
                statuses.Add(UploadResult(file.FileName, file.Length, file.FileName));
            }
        }
        
        public ViewDataUploadFilesResult UploadResult(String FileName,long fileSize,String FileFullPath)
        {
            String getType = System.Web.MimeMapping.GetMimeMapping(FileFullPath);
            var result = new ViewDataUploadFilesResult()
            {
                name = FileName,
                size = fileSize,
                type = getType,
                url = _urlBase + FileName,
                deleteUrl = _deleteUrl + FileName,
                thumbnailUrl = CheckThumb(getType, FileName),
                deleteType = _deleteType,
            };
            return result;
        }

        public String CheckThumb(String type,String FileName)
        {
            var splited = type.Split('/');
            if (splited.Length == 2)
            {
                string extansion = splited[1].ToLower();
                if(extansion.Equals("jpeg") || extansion.Equals("jpg") || extansion.Equals("png") || extansion.Equals("gif"))
                {
                    String thumbnailUrl = _urlBase + "thumbs/" + Path.GetFileNameWithoutExtension(FileName) + "80x80.jpg";
                    return thumbnailUrl;
                }
                //else
                //{
                //    if (extansion.Equals("octet-stream")) //Fix for exe files
                //    {
                //        return "/Content/Free-file-icons/48px/exe.png";

                //    }
                //    if (extansion.Contains("zip")) //Fix for exe files
                //    {
                //        return "/Content/Free-file-icons/48px/zip.png";
                //    }
                //    String thumbnailUrl = "/Content/Free-file-icons/48px/"+ extansion +".png";
                //    return thumbnailUrl;
                //}
            }
            return _urlBase + "/thumbs/" + Path.GetFileNameWithoutExtension(FileName) + "80x80.jpg";
        }

        public List<String> FilesList()
        {
            List<String> Filess = new List<String>();
            string path = HostingEnvironment.MapPath(_serverMapPath);
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo fi in di.GetFiles())
                {
                    Filess.Add(fi.Name);
                }

            }
            return Filess;
        }
    }
    public class ViewDataUploadFilesResult
    {
        public string name { get; set; }
        public long size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string deleteUrl { get; set; }
        public string thumbnailUrl { get; set; }
        public string deleteType { get; set; }
    }
    public class JsonFiles
    {
        public ViewDataUploadFilesResult[] files;
        public string TempFolder { get; set; }
        public JsonFiles(List<ViewDataUploadFilesResult> filesList)
        {
            files = new ViewDataUploadFilesResult[filesList.Count];
            for (int i = 0; i < filesList.Count; i++)
            {
                files[i] = filesList.ElementAt(i);
            }

        }
    }
}

    