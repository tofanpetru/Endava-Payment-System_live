using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using BlazorApp3.Server.Data;
using Microsoft.EntityFrameworkCore;
using BlazorApp3.Server.Helpers;
using System.Threading;

namespace BlazorApp3.Server.Application.Wallets.Commands
{
    public class DeleteWalletCommand : IRequest<CommandResult>
    {
        public string UserId { get; set; }
        public Guid WalletId { get; set; }
    }

    public class DeleteWalletCommandHandler : IRequestHandler<DeleteWalletCommand, CommandResult>
    {
        private readonly ApplicationDbContext context;

        public DeleteWalletCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CommandResult> Handle(DeleteWalletCommand command, CancellationToken cancellationToken)
        {

            var user = await context.Users.Include(x => x.Wallets).FirstOrDefaultAsync(x => x.Id == command.UserId);

            if (user == null || !user.Wallets.Any(x => x.Id == command.WalletId) )
            {
                return CommandResult.ReturnFailure();
            }

            var wallet = context.Wallets.FirstOrDefault(e => e.Id == command.WalletId);
            context.Wallets.Remove(wallet);
            context.SaveChanges();

            return CommandResult.ReturnSuccess();
        }
    }
}