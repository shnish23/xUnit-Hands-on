using System;
using System.IO;
using Xunit;

namespace SetupTearDown.Tests
{
    public class FilesTests : IDisposable
    {
        private const string ExistFileName = "test.txt";
        private const string TextFileContent = "Hello, xUnit.net!";
        private const string NotExistFileName = "NotExistFile";

        public FilesTests()
        {
            if (File.Exists(ExistFileName))
                File.Delete(ExistFileName);

            File.WriteAllText(ExistFileName, TextFileContent);
        }

        public void Dispose()
        {
            if (File.Exists(ExistFileName))
                File.Delete(ExistFileName);
        }

        [Fact]
        public void DeleteIfExistWhenExistFile()
        {
            Assert.True(Files.DeleteIfExist(ExistFileName));
            Assert.False(File.Exists(ExistFileName));
        }

        [Fact]
        public void DeleteIfExistWhenNotExistFile()
        {
            Assert.False(Files.DeleteIfExist("NotExistFile"));
        }
    }
}
