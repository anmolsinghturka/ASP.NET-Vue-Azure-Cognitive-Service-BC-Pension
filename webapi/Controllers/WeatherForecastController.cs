using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure.AI.FormRecognizer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty or not provided.");
            }

            //create the Azure Form Recognizer client
            string endpoint = "https://form-recognizer-anmol-singh.cognitiveservices.azure.com/";
            string key = "f24f3d716a0443e8a368d89a022d6553";
            AzureKeyCredential credential = new AzureKeyCredential(key);
            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), credential);

            try
            {
                //save the uploaded file to the current directory
                string folderName = "uploads";
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                string filePath = Path.Combine(uploadPath, file.FileName);
               // string filePath = Path.Combine(Directory.GetCurrentDirectory(), file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                //analyze the file using Azure Form Recognizer
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-document", stream);
                    AnalyzeResult result = operation.Value;

                    //build the key-value JSON response
                    var keyValuePairs = new System.Collections.Generic.List<object>();
                    foreach (DocumentKeyValuePair kvp in result.KeyValuePairs)
                    {
                        if (kvp.Value == null)
                        {
                            keyValuePairs.Add(new { key = kvp.Key.Content, value = "" });
                        }
                        else
                        {
                            keyValuePairs.Add(new { key = kvp.Key.Content, value = kvp.Value.Content });
                        }
                    }
                    var response = new { keyValuePairs };

                    return Ok(response);
                }
            }
            catch (RequestFailedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private IActionResult Json(object response)
        {
            throw new NotImplementedException();
        }
    }
}
