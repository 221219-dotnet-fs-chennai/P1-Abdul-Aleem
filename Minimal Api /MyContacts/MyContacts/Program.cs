
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyContacts.ContactsDb>(opt => opt.UseInMemoryDatabase("ContactList"));
var app = builder.Build();




app.MapPost("/AddContacts", (MyContacts.Contacts contacts, MyContacts.ContactsDb contactsDb) =>
{
    contactsDb.contacts.Add(contacts);
    int k = contactsDb.SaveChanges();
    if (k > 0) return Results.Created("Created successfully", contacts);
    else return Results.Problem();
});








app.MapGet("/GetContacts", (MyContacts.ContactsDb db) =>
db.contacts.ToList());






app.MapDelete("/DeleteContacts/{id}", (int id, MyContacts.ContactsDb contacts) =>

{
    MyContacts.Contacts contacts1 = new MyContacts.Contacts();
    contacts1.Id = id;
    contacts.contacts.Remove(contacts1);
    contacts.SaveChanges();
    return Results.Ok("Deleted");

});





app.MapPut("/UpdateContacts/{id}", (int id, MyContacts.Contacts myContacts, MyContacts.ContactsDb db) =>
{
    MyContacts.Contacts contacts = new MyContacts.Contacts();
    contacts.Id = id;
    contacts.Name = myContacts.Name;
    contacts.Category = myContacts.Category;
    contacts.PhoneNo = myContacts.PhoneNo;
    db.Update(contacts);
    db.SaveChanges();

    return Results.Ok("Updated successfully");

});


app.Run();

