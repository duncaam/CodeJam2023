using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using IS7024Project.Models;
using System.Drawing;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Imaging;

namespace IS7024Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IS7024Project.Data.IS7024ProjectContext _context;

        public IndexModel(ILogger<IndexModel> logger, IS7024Project.Data.IS7024ProjectContext context, IWebHostEnvironment environment)
        {
            _logger = logger;
            _context = context;
            Environment = environment;
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public IWebHostEnvironment Environment { get; }

        public imgBBResponse imgBBResponseEntry = new imgBBResponse();
        public string gAuthFP { get; set; }
        public Guid photoFinish { get; set; }
        public List<imgBBResponse> imgBBResponses = new List<imgBBResponse>();
        public imgBBReturn imgBBReturn1 { get; set; }

        public List<imgBBReturn> imgBBReturns23 = new List<imgBBReturn>();
        public bool continuity { get; set; }
        public async Task OnGetAsync()
        {
            imgBBResponses = _context.imgBBResponse
                .OrderByDescending(s => s.imgBBResponseTime)
                .ToList();

            int i = 0;

            foreach (var p in imgBBResponses)
            {
                if (p.CanShare == true && p.isSafe == true && i == 0)
                {
                    imgBBReturn imgBBReturn = new imgBBReturn();
                    imgBBReturn.imgBBReturnId = p.imgBBResponseId;
                    imgBBReturn.imgBBUrl = p.imgLocal;
                    imgBBReturn.isSafe = p.isSafe;
                    imgBBReturn.EmotionalResult = p.EmotionalResult;
                    imgBBReturn.EmotionCount = p.EmotionCount;
                    imgBBReturn.PrimaryEmotionId = p.PrimaryEmotionId;
                    imgBBReturn.SecondaryEmotionId = p.SecondaryEmotionId;
                    imgBBReturn.PrimaryEmotionIndex = p.PrimaryEmotionIndex;
                    imgBBReturn.SecondaryEmotionIndex = p.SecondaryEmotionIndex;
                    imgBBReturn.CanShare = p.CanShare;
                    imgBBReturn1 = imgBBReturn;
                    i++;
                }
                else if (p.CanShare == true && p.isSafe == true && i > 0 && i < 3)
                {
                    imgBBReturn imgBBReturn = new imgBBReturn();
                    imgBBReturn.imgBBReturnId = p.imgBBResponseId;
                    imgBBReturn.imgBBUrl = p.imgLocal;
                    imgBBReturn.isSafe = p.isSafe;
                    imgBBReturn.EmotionalResult = p.EmotionalResult;
                    imgBBReturn.EmotionCount = p.EmotionCount;
                    imgBBReturn.PrimaryEmotionId = p.PrimaryEmotionId;
                    imgBBReturn.SecondaryEmotionId = p.SecondaryEmotionId;
                    imgBBReturn.PrimaryEmotionIndex = p.PrimaryEmotionIndex;
                    imgBBReturn.SecondaryEmotionIndex = p.SecondaryEmotionIndex;
                    imgBBReturn.CanShare = p.CanShare;
                    imgBBReturns23.Add(imgBBReturn);
                    i++;
                }
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("Begin:OnPostAsync");

            string infileName = Upload.FileName;
            string newFileGuid = Guid.NewGuid().ToString().Replace("-", string.Empty);
            string outFileName = newFileGuid;
            string convertFileName = newFileGuid + ".png";
            string infile = Path.Combine(Environment.ContentRootPath, "wwwroot\\Uploads", infileName);
            string outfile = Path.Combine(Environment.ContentRootPath, "wwwroot\\Uploads", outFileName);
            string convertfile = Path.Combine(Environment.ContentRootPath, "wwwroot\\Uploads\\FourthDownConversion", convertFileName);
            string localfile = "./Uploads/FourthDownConversion/" + convertFileName;

            using (var createFileStream = new FileStream(infile, FileMode.Create))
            {
                await Upload.CopyToAsync(createFileStream);
            }

            System.IO.File.Move(infile, outfile);

            Image undeveloped = Image.FromFile(outfile);

            continuity = Photoshop.OneHourPhoto.KodakMoment(undeveloped, convertfile);

            if (continuity == true)
            {
                try
                {
                    using (Image image = Image.FromFile(convertfile))
                    {
                        using (MemoryStream m = new MemoryStream())
                        {
                            image.Save(m, image.RawFormat);
                            byte[] imageBytes = m.ToArray();
                            string imgBBImg = Convert.ToBase64String(imageBytes);
                            string imgBBKeyFile = "imgBBKey.txt";
                            string imgBBKey = System.IO.File.ReadAllText(imgBBKeyFile);
                            var imgBBClient = new RestClient("https://api.imgbb.com/1/upload?key=" + imgBBKey);
                            imgBBClient.Timeout = -1;
                            var imgBBRequest = new RestRequest(Method.POST);
                            imgBBRequest.AlwaysMultipartFormData = true;
                            imgBBRequest.AddParameter("image", imgBBImg);
                            var imgbbResponse = imgBBClient.Execute(imgBBRequest);
                            var serializedImgBBResponse = JsonConvert.DeserializeObject<ImgBBResponseSerialization>(imgbbResponse.Content);
                            imgBBResponseEntry.imgBBsuccess = serializedImgBBResponse.success;
                            imgBBResponseEntry.imgBBstatus = serializedImgBBResponse.status;
                            imgBBResponseEntry.imgBBDeleteUrl = serializedImgBBResponse.data.delete_url;
                            imgBBResponseEntry.imgBBUrl = serializedImgBBResponse.data.image.url;
                            imgBBResponseEntry.imgLocal = localfile;
                            imgBBResponseEntry.imgBBResponseTime = DateTime.Now;
                            imgBBResponseEntry.imageLocalName = outFileName.ToString();
                            _context.imgBBResponse.Add(imgBBResponseEntry);
                            await _context.SaveChangesAsync();
                            photoFinish = imgBBResponseEntry.imgBBResponseId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Error Occured.Message:{ex.Message}");
                    return RedirectToPage("./Index");
                }

                _logger.LogInformation("End:OnPostAsync");

            }
            return RedirectToPage("./Results", new { id = photoFinish });
        }
    }
}
