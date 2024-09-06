using MediatR;
using MediatRSample.Helper;

namespace MediatRSample.Queries
{
    public class GetAllPostsQuery: IRequest<List<Post>>
    {
        public OrderByPostOptions OrderBy { get; set; }
    }
}
