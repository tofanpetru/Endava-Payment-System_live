using BlazorApp3.Server.Application.Promotion;
using BlazorApp3.Server.Application.Wallets.Commands;
using BlazorApp3.Server.Data;
using BlazorApp3.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using BlazorApp3.Server.Helpers;
using BlazorApp3.Server.Data;

namespace BlazorApp3.Server.UnitTests
{
    public class DeletWalletCommandHandlerTests
    {
        private ApplicationDbContext context;
        public Guid wallet_id = Guid.NewGuid();

        [SetUp]
        public void Setup()
        {
            context = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlite("Filename=Test.db")
                    .Options, Microsoft.Extensions.Options.Options.Create(new OperationalStoreOptions()));

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var user = new ApplicationUser
            {
                Id = "test_user_id",
                Wallets = new List<Wallet>
                {
                    new Wallet
                    {
                        Id = wallet_id,
                        Amount = 100,
                        Currency = "EUR"
                    }
                }
            };

            context.Add(user);

            context.SaveChanges();
        }

        [Test] 
        public async Task DeleteWalletExistentId()
        {
            var sut = new DeletWalletCommandHandler(context);

            var command = new DeletWalletCommand
            {
                UserId = "test_user_id",
                WalletId = wallet_id
            };

            var result = await sut.Handle(command, CancellationToken.None);

            Assert.IsTrue(result.IsSuccessful);
        }


        [Test] 
        public async Task DeleteWalletNonExistentId()
        {
            var sut = new DeletWalletCommandHandler(context);

            var command = new DeletWalletCommand
            {
                UserId = "test_user_id",
                WalletId = Guid()
            };

            var result = await sut.Handle(command, CancellationToken.None);

            Assert.IsFalse(result.IsSuccessful);
        }
    }
}