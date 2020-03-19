namespace Web.API.Repository
{
    public class BaseResposiorty
    {
        public abstract class BaseRepository
        {
            protected readonly AppDbContext _context;

            public BaseRepository(AppDbContext context)
            {
                _context = context;
            }
        }
    }
}