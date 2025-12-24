namespace MachineAssetManagement.Services
{
    public class MatrixFileService
    {
        private readonly string _filePath;

        public MatrixFileService(string filePath)
        {
            _filePath = filePath;
        }

        public void ReplaceFile(List<string> lines)
        {
            File.WriteAllLines(_filePath, lines);
        }

        public void AppendFile(List<string> lines)
        {
            File.AppendAllLines(_filePath, lines);
        }
    }
}

