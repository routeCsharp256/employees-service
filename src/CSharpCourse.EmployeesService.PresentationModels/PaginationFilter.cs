namespace CSharpCourse.EmployeesService.PresentationModels
{
    public class PaginationFilter
    {
        private int _page = 1;
        private int _itemsOnPage = 10;

        public int Page
        {
            get => _page;
            set
            {
                if (value < 1)
                    _page = 1;
                _page = value;
            }
        }

        public int ItemsOnPage
        {
            get => _itemsOnPage;
            set
            {
                if (value < 1)
                    _itemsOnPage = 10;
                _itemsOnPage = value;
            }
        }
    }
}
