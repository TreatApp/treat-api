﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Treat.Model;
using Treat.Repository;

namespace Treat.Service.Tests
{
    [TestClass]
    public class FileServiceTests
    {
        private readonly IFileService _fileService;

        public FileServiceTests()
        {
            var settings = new Settings();
            _fileService = new FileService(settings);
        }

        [TestMethod]
        public void Should_upload_file()
        {
            var content = File.ReadAllBytes("./Resources/test.png");
            _fileService.UploadEventImage("test/test.png", content);
        }
    }
}