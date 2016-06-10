using System;

namespace CoolBlogCore.Services
{
    public class RatingService<T> : IRatingService where T:BasicEntry
    {
        private IRepository<T> _repository;
        public RatingService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void UpVote(int EntryId)
        {
            _repository.GetEntry(EntryId).Rating.UpVote();
            _repository.UpdateFile();
        }

        public void DownVote(int EntryId)
        {
            _repository.GetEntry(EntryId).Rating.DownVote();
            _repository.UpdateFile();
        }
        public int? GetRating(int EntryId) 
        {
            if ((_repository.GetEntry(EntryId))!=null)
            {
                return _repository.GetEntry(EntryId).Rating.Sum;
                
            }
            return null;
        }
    }
}
