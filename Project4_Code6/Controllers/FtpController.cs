using Microsoft.AspNetCore.Mvc;
using Project4_Code6.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project4_Code6.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FtpController : ControllerBase
    {
        string ParentFolderPath = "ftp://192.168.1.82/ftp/files/FI9803EP_00626E66ABD9/snap";

        string host = "ftp://192.168.1.82";
        string UserId = "pi";
        string Password = "raspberry";
        private readonly ProjectContext _context;

        public FtpController(ProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public FileStreamResult GetPhotoHal()
        {
            List<string> files = getFilesnames();
            string To = "ftp://192.168.1.82/ftp/files/FI9803EP_00626E66ABD9/snap/" + files[files.Count()-1];


            try
            {
                /* Create an FTP Request */
                var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(To);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(UserId, Password);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Get the FTP Server's Response Stream */
                var ftpStream = ftpResponse.GetResponseStream();

                // TODO: you might need to extract these settings from the FTP response
                const string contentType = "application/jpg";
                string fileNameDisplayedToUser = files[files.Count()-1];

                return File(ftpStream, contentType, fileNameDisplayedToUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        [HttpGet("dome")]
        public FileStreamResult GetPhotoDome()
        {
            List<string> files = getFilesnamesDome();
            string To = "ftp://pi@192.168.1.82/ftp/files/FI9853EP_00626E61750D/snap/" + files[files.Count() - 1];
            try
            {
                /* Create an FTP Request */
                var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(To);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(UserId, Password);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Get the FTP Server's Response Stream */
                var ftpStream = ftpResponse.GetResponseStream();

                // TODO: you might need to extract these settings from the FTP response
                const string contentType = "application/jpg";
                string fileNameDisplayedToUser = files[files.Count() - 1];

                return File(ftpStream, contentType, fileNameDisplayedToUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("offenses")]
        public FileStreamResult GetAllOffenses()
        {
            List<string> files = getFilesnamesOffenses();
            string To = "ftp://pi@192.168.1.82/ftp/files/motion/" + files[1];
            try
            {
                /* Create an FTP Request */
                var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(To);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(UserId, Password);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Get the FTP Server's Response Stream */
                var ftpStream = ftpResponse.GetResponseStream();

                // TODO: you might need to extract these settings from the FTP response
                const string contentType = "video/mp4";
                string fileNameDisplayedToUser = files[1];

                return File(ftpStream, contentType, fileNameDisplayedToUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("offenses/{filename}")]
        public FileStreamResult getFilename(string filename)
        {
            string To = "ftp://pi@192.168.1.82/ftp/files/motion/" + filename;
            try
            {
                /* Create an FTP Request */
                var ftpRequest = (FtpWebRequest)FtpWebRequest.Create(To);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(UserId, Password);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Get the FTP Server's Response Stream */
                var ftpStream = ftpResponse.GetResponseStream();

                // TODO: you might need to extract these settings from the FTP response
                const string contentType = "video/mp4";
                string fileNameDisplayedToUser = filename;

                return File(ftpStream, contentType, fileNameDisplayedToUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("filesnameHal")]
        public List<string> getFilesnames()
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ParentFolderPath);
            ftpRequest.Credentials = new NetworkCredential(UserId, Password);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            List<string> directories = new List<string>();

            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var lineArr = line.Split('/');
                line = lineArr[lineArr.Count() - 1];
                directories.Add(line);
                line = streamReader.ReadLine();
            }

            streamReader.Close();

            return directories;
        }

        [HttpGet("filesnamesDome")]
        public List<string> getFilesnamesDome()
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://pi@192.168.1.82/ftp/files/FI9853EP_00626E61750D/snap/");
            ftpRequest.Credentials = new NetworkCredential(UserId, Password);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            List<string> directories = new List<string>();

            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var lineArr = line.Split('/');
                line = lineArr[lineArr.Count() - 1];
                directories.Add(line);
                line = streamReader.ReadLine();
            }

            streamReader.Close();

            return directories;
        }

        [HttpGet("filesnamesOffenses")]
        public List<string> getFilesnamesOffenses()
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://pi@192.168.1.82/ftp/files/motion/");
            ftpRequest.Credentials = new NetworkCredential(UserId, Password);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            List<string> directories = new List<string>();

            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var lineArr = line.Split('/');
                line = lineArr[lineArr.Count() - 1];
                directories.Add(line);
                line = streamReader.ReadLine();
            }

            streamReader.Close();

            return directories;
        }
    }
}
