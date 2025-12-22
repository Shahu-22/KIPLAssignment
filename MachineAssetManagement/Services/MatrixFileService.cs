namespace MachineAssetManagement.Services
{
    public class MatrixFileService
    {
        private readonly IWebHostEnvironment _env;
        private const string FileName = "Matrix.txt";
        public MatrixFileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        private string FilePath => Path.Combine(_env.ContentRootPath, FileName);

        public void ReplaceFile(List<string> lines)
        {
            File.WriteAllLines(FilePath, lines);
        }
        public void AppendFile(List<string> lines)
        {
            File.AppendAllLines(FilePath, lines);
        }
    }
}
