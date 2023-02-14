
using System.Net;
using RestSharp;
using TestAutomationFramework.API.Controllers;

namespace TestAutomationFramework.API.Tests;

[TestFixture]
public class BiblesTests
{
    [Test]
    public void CheckAllAudioBiblesResponse()
    {
        var response = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
        Assert.That(response.Responce.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while GET request to /v1/audio-bibles");
    }

    [Test]
    public void CheckAllAudioBiblesResponseWithoutAutorization()
    {
        var response = new BiblesController(new CustomRestClient(), string.Empty).GetBibles<RestResponse>();
        Assert.That(response.Responce.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status code was returned while GET request to /v1/audio-bibles");
    }

    [Test]
    public void CheckSingleAudioBiblesResponse()
    {
        string id = "26b7a1cd2f8f4878-01";
        var response = new BiblesController(new CustomRestClient(), string.Empty).GetBible<RestResponse>(id);
        Assert.That(response.Responce.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status code was returned while GET request to /v1/audio-bibles/{0}/books");
    }
}
