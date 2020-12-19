using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PerformanceCalculator.Models;
using PerformanceCalculator.Services;

namespace PerformanceCalculator.Pages.Students
{
    public class UploadModel : PageModel
    {
        private readonly IDbService<Student> _service;
        private readonly ILogger<UploadModel> _logger;

        public UploadModel(IDbService<Student> service, ILogger<UploadModel> logger)
        {
            _service = service;
            _logger = logger;
        }

        [BindProperty] public IFormFile Upload { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var extension = Path.GetExtension(Upload.FileName);
            if (extension != ".csv") return BadRequest();
            
            var dir = CreateUniqueTempDirectory();
            var file = Path.Combine(dir, Upload.FileName);
            _logger.LogInformation(file);
            
            await WriteFileToTempDirAsync(file);
            try
            {
                await WriteToDbFromTempFile(file);
                Directory.Delete(dir, true);
                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        private static string CreateUniqueTempDirectory()
        {
            var uniqueTempDir = Path.GetFullPath(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            Directory.CreateDirectory(uniqueTempDir);
            return uniqueTempDir;
        }

        private async Task WriteFileToTempDirAsync(string filePath)
        {
            try
            {
                await using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                await Upload.CopyToAsync(fileStream);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        private async Task WriteToDbFromTempFile(string file)
        {
            using var reader = new StreamReader(file);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            await csv.ReadAsync();
            csv.ReadHeader();
            while ((await csv.ReadAsync()))
            {
                csv.Configuration.RegisterClassMap<StudentMap>();
                var record = csv.GetRecord<Student>();
                await _service.CreateAsync(record);
            }
        }
    }

    public sealed class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(s => s.CreatedAt).Ignore();
            Map(s => s.UpdatedAt).Ignore();
        }
    }
}