using TestTask.Infrastructure.Data;

namespace TestTask.ApplicationCore.Services
{
    public class UpdateModelsService
    {
        private readonly DataContext _context;
        public UpdateModelsService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateModel<TEntity, TUpdateDto>(string id, TUpdateDto updateDto)
            where TEntity : class
            where TUpdateDto : class
        {
            var updateModel = await _context.Set<TEntity>().FindAsync(id);
            if (updateModel == null)
                throw new ArgumentException($"{typeof(TEntity).Name} does not exist");

            var modelType = typeof(TEntity);
            var updateDtoType = typeof(TUpdateDto);

            foreach (var property in updateDtoType.GetProperties())
            {
                var newValue = property.GetValue(updateDto);
                if (newValue != null)
                {
                    var entityProperty = modelType.GetProperty(property.Name);
                    if (entityProperty != null && entityProperty.CanWrite)
                    {
                        entityProperty.SetValue(updateModel, newValue);
                    }
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
