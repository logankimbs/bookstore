using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Models
{
    public class EFDonationRepository : IDonationRepository
    {
        private BookContext context;

        public EFDonationRepository(BookContext temp)
        {
            context = temp;
        }

        public IQueryable<Donation> Donations => context.Donations
            .Include(x => x.Lines)
            .ThenInclude(x => x.Book);

        public void SaveDonation(Donation donation)
        {
            context.AttachRange(donation.Lines.Select(x => x.Book));

            if (donation.DonationId == 0)
            {
                context.Donations.Add(donation);
            }

            context.SaveChanges();
        }
    }
}
