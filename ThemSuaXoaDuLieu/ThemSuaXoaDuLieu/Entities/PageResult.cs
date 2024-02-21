namespace ThemSuaXoaDuLieu.Entities
{
    public class PageResult<T>
    {
        public Pagination pagination { get; set; }
        public IEnumerable<T> data { get; set; }

        public PageResult(Pagination pagination, IEnumerable<T> data)
        {
            this.pagination = pagination;
            this.data = data;
        }
        public static IQueryable<T> ToPageResult(Pagination pagination, IQueryable<T> data)
        {
            pagination.PageNumber = pagination.PageNumber < 1 ? 1 : pagination.PageNumber;
            data = data.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize).AsQueryable();
            return data;
        }
    }
}
