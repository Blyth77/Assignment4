using Assignment4.Core;
using System.Collections.Generic;
using System;
using static Assignment4.Core.Response;

namespace Assignment4.Entities
{
    public class TagRepository : ITagRepository
    {
        private readonly IKanbanContext _context;

        public TagRepository(IKanbanContext context)
        {
            _context = context;
        }

        public (Response Response, int TagId) Create(TagCreateDTO tag)
        {
            var entity = _context.Tags.Find(tag);

            if (entity != null){
                return (Conflict, entity.Id);
            }

            return (Created, entity.Id);
        }

        public Response Delete(int tagId, bool force = false)
        {
            var entity = _context.Tags.Find(tagId);
        
            if (entity == null)
            { 
                return NotFound;
            }

            if (entity.Tasks.Count > 0){
                if (force != true){
                    return Conflict;
                }
            }

            entity.Id = tagId;
            _context.Tags.Remove(entity);

            return Deleted;
        }

        public TagDTO Read(int tagId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TagDTO> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Response Update(TagUpdateDTO tag)
        {
            throw new NotImplementedException();
        }
    }
}