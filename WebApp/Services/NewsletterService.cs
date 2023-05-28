//using WebApp.Helpers.Repositories;
//using WebApp.Models.Dtos;
//using WebApp.Models.Entities;

//namespace WebApp.Services
//{
//    public class NewsletterService
//    {
//        private readonly NewsletterRepository _newletterRepo;

//        public NewsletterService(NewsletterRepository newletterRepo)
//        {
//            _newletterRepo = newletterRepo;
//        }

//        public async Task<Newsletter> CreateAsync(NewsletterEntity entity)
//        {
//            var _entity = await _newletterRepo.GetAsync(x => x.Id == entity.Id);
//            if (_entity == null)
//            {
//                _entity = await _newletterRepo.AddAsync(entity);
//                if (_entity != null)
//                    return _entity;
//            }

//            return null!;
//        }
//    }
//}
