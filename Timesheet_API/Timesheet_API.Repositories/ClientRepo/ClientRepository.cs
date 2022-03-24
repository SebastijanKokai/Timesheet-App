﻿using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Helpers;
using Timesheet_API.Models.Models;
using Timesheet_API.Models.Parameters;

namespace Timesheet_API.Repositories.ClientRepo
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository()
        {

        }

        public ClientRepository(timesheet_dbContext context) : base(context)
        {

        }

        public PagedList<Client> GetAll(ClientParameters clientParameters)
        {
            IQueryable<Client> clients = table;

            if (clientParameters.FirstLetter != null)
            {
                clients = table.Where(cp => cp.ClientName.FirstOrDefault() == clientParameters.FirstLetter);
            }

            SearchByName(ref clients, clientParameters.Name);

            return PagedList<Client>
                .ToPagedList(clients.OrderBy(cp => cp.ClientName),
                clientParameters.PageNumber,
                clientParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Client> clients, string clientName)
        {
            if (!clients.Any() || string.IsNullOrWhiteSpace(clientName))
                return;

            clients = clients.Where(cl => cl.ClientName.ToLower().Contains(clientName.Trim().ToLower()));
        }

        new public Client GetByID(Guid ID)
        {
            return table
            .AsNoTracking()
            .Where(p => p.Id == ID).FirstOrDefault();
        }

        public Client GetClientByName(string name)
        {
            return table
                .Where(p => p.ClientName == name)
                .FirstOrDefault();
        }

        public override Client Delete(Guid ID)
        {
            Client? client = table.Find(ID);
            if (client != null)
            {
                client.DeletedDate = DateTime.UtcNow;
                context.Entry(client).State = EntityState.Modified;
                return client;
            }
            throw new NullReferenceException("There is no Client with given ID.");
        }

    }
}
