using System;
using Microsoft.EntityFrameworkCore;

namespace MyContacts
{
    public class ContactsDb : DbContext
    {




        public ContactsDb(DbContextOptions<ContactsDb> options)
            : base(options) { }

        public DbSet<Contacts> contacts => Set<Contacts>();
    }






}


