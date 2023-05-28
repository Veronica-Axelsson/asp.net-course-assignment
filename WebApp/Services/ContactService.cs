using WebApp.Helpers.Repositories;
using WebApp.Models.Dtos;
using WebApp.Models.Entities;

namespace WebApp.Services;

public class ContactService
{
    private readonly ContactRepository _contactRepo;


    public ContactService(ContactRepository contactRepo)
    {
        _contactRepo = contactRepo;
    }

    public async Task<Contact> CreateAsync(ContactEntity entity)
    {
        var _entity = await _contactRepo.GetAsync(x => x.ContactId == entity.ContactId);
        if (_entity == null)
        {
            _entity = await _contactRepo.AddAsync(entity);
            if (_entity != null)
                return _entity;
        }

        return null!;
    }

    //public async Task<Newsletter> CreateNewAsync(NewsletterEntity entity)
    //{
    //    var _entity = await _newletterRepo.GetAsync(x => x.Id == entity.Id);
    //    if (_entity == null)
    //    {
    //        _entity = await _newletterRepo.AddAsync(entity);
    //        if (_entity != null)
    //            return _entity;
    //    }

    //    return null!;
    //}
}
