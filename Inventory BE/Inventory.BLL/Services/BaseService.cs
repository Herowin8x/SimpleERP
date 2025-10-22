using AutoMapper;
using Inventory.DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.BLL.Services
{
    public class BaseService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly BaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(BaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TDto> Create(TDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            // Reset Id if exists
            var idProp = typeof(TDto).GetProperty("Id");
            if (idProp != null && (int)idProp.GetValue(dto)! != 0)
                idProp.SetValue(dto, 0);

            var entity = _mapper.Map<TEntity>(dto);
            var newEntity = await _repository.Create(entity);
            return _mapper.Map<TDto>(newEntity);
        }

        public virtual async Task<List<TDto>> Read(int pageSize, int pageNumber)
        {
            var entities = await _repository.Read(pageSize: pageSize, pageNumber: pageNumber);
            return _mapper.Map<List<TDto>>(entities);
        }

        public virtual async Task<TDto> Read(int id)
        {
            var entity = await _repository.Read(id);
            if (entity == null)
                throw new KeyNotFoundException("Entity not found.");

            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task Update(TDto dto)
        {
            var idProp = typeof(TDto).GetProperty("Id");
            if (idProp == null)
                throw new InvalidOperationException("DTO must have an Id property.");

            int id = (int)idProp.GetValue(dto)!;
            var existing = await _repository.Read(id);
            if (existing == null)
                throw new KeyNotFoundException("Entity not found.");

            var entity = _mapper.Map<TEntity>(dto);
            await _repository.Update(entity);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await _repository.Read(id);
            if (entity == null)
                throw new KeyNotFoundException("Entity not found.");

            await _repository.Delete(id);
        }
    }
}
