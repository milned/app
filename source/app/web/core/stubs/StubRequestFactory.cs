using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateControllerRequests
  {
    public IProvideDetailsForACommand create_request_from(HttpContext context)
    {
        return Stub.with<StubRequest>();
    }

    class StubRequest : IProvideDetailsForACommand
    {
    }
  }
}