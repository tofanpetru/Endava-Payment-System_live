using BlazorApp3.Server.Application.Promotion;
using BlazorApp3.Server.Application.Wallets.Commands;
using BlazorApp3.Server.Data;
using BlazorApp3.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp3.Server.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //se va crea o bd sqlite(bd separata de cea a proiectului)

            //se va crea inregistrare pentru test
        }

        [Test]
        public void Test1()
        {
            //testele
            //ex:update/delete/create
            Assert.Pass();
        }
    }
}