namespace PdfCombiner
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    // Need to install iTextSharp NuGet Package
    using iTextSharp.text;
    using iTextSharp.text.pdf;

    public static class PdfCombiner
    {
        public static string CombinePdfs(List<string> base64Contents, string tempFolderFilePath)
        {
            // Keep track of files so multiple sets of pdfs can be combined simultaneously
            string uniqueIdentifier = Guid.NewGuid().ToString();

            // Create pdf files from base64 contents in a specified temp folder
            var fileNames = CreatePdfs(uniqueIdentifier, base64Contents, tempFolderFilePath);

            // Create the combined pdf
            var combinedPdfFileName = $"{tempFolderFilePath}/{uniqueIdentifier}_combined.pdf";
            CreateCombinedPdf(fileNames, combinedPdfFileName);

            // Get base64 content of combined pdf
            var combinedPdfBase64Content = GetBase64Content(combinedPdfFileName);

            // Delete temp pdfs
            fileNames.Add(combinedPdfFileName);
            DeletePdfs(fileNames);

            return combinedPdfBase64Content;
        }

        private static List<string> CreatePdfs(string uniqueIdentifier, List<string> base64Contents, string tempFolderFilePath)
        {
            int i = 0;
            List<string> fileNames = new List<string>();
            foreach (var base64Content in base64Contents)
            {
                var fileName = $"{tempFolderFilePath}/{uniqueIdentifier}_{i}.pdf";
                var bytes = Convert.FromBase64String(base64Content);
                using (System.IO.FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    using (System.IO.BinaryWriter writer = new BinaryWriter(stream))
                    {
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                }

                fileNames.Add(fileName);
                i++;
            }

            return fileNames;
        }

        private static void CreateCombinedPdf(List<string> fileNames, string targetPdf)
        {
            using (FileStream stream = new FileStream(targetPdf, FileMode.Create))
            {
                Document document = new Document();
                PdfCopy pdf = new PdfCopy(document, stream);
                PdfReader reader = null;
                try
                {
                    document.Open();
                    foreach (string file in fileNames)
                    {
                        reader = new PdfReader(file);
                        pdf.AddDocument(reader);
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }

                    throw ex;
                }
                finally
                {
                    if (document != null)
                    {
                        document.Close();
                    }
                }
            }
        }

        private static string GetBase64Content(string filePath)
        {
            var byteArray = System.IO.File.ReadAllBytes(filePath);
            return Convert.ToBase64String(byteArray);
        }

        private static void DeletePdfs(List<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                System.IO.File.Delete(fileName);
            }
        }
    }
}