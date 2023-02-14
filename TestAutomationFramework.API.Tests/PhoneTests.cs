
using System.Net;
using System.Numerics;
using RestSharp;
using TestAutomationFramework.API.Controllers;
using TestAutomationFramework.API.Models.RequestModels.Phone;
using TestAutomationFramework.API.Models.ResponseModels;
using TestAutomationFramework.API.Models.SharedModelsPhone;

namespace TestAutomationFramework.API.Tests;

[TestFixture]
public class PhoneTests
{
    [Test]
    public void CheckAllPhonesResponse()
    {
        var response = new PhonesController(new CustomRestClient()).GetPhones<List<AllPhonesModels>>();
        Assert.That(response.Responce.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while GET request to /objects");
    }

    [Test]
    public void CheckListOfObjectsId()
    {
        var phone = new PhonesController(new CustomRestClient()).GetPhones<List<AllPhonesModels>>();
        var phoneList = phone.Phones.ToList();

        var response = new PhonesController(new CustomRestClient()).GetPhonesID<List<AllPhonesModels>>(phoneList.Select(item => item.id).Last());
        Assert.That(phoneList.Last().id, Is.EqualTo(response.Phone.Last().id), "GET request to /objects should return any objects");
    }


    [Test]
    public void CheckSpecialCapacity()
    {
        var phoneToCreate = new PhoneModel
        {
            name = "Motorola v3i",
            data = new PhonesData
            {
               price = 20,
               capacityGB = 612
            }
        };
        var createdPhone = new PhonesController(new CustomRestClient()).AddPhone<AllPhonesModels>(phoneToCreate).Phone;

        var receivedPhone = new PhonesController(new CustomRestClient()).GetPhones<AllPhonesModels>(createdPhone.id).Phone;

        Assert.That(receivedPhone.data.capacityGB, Is.EqualTo(createdPhone.data.capacityGB), $"Phone with id {createdPhone.id} was not created!");
        new PhonesController(new CustomRestClient()).DeletePhone<AllPhonesModels>(receivedPhone.id);
    }

    [Test]
    public void CheckSpecialPhoneDelete()
    {
        var phoneToCreate = new PhoneModel
        {
            name = "Sony Ericsson k700i",
            data = new PhonesData
            {
                price = 20,
                capacityGB = 41,
                year = 2004
            }
        };
        var createdPhone = new PhonesController(new CustomRestClient()).AddPhone<AllPhonesModels>(phoneToCreate).Phone;
        var receivedPhone = new PhonesController(new CustomRestClient()).GetPhones<AllPhonesModels>(createdPhone.id).Phone;
        var response = new PhonesController(new CustomRestClient()).DeletePhone<AllPhonesModels>(receivedPhone.id);

        Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Phone with id {createdPhone.id} was not deleted!");
        
    }

    [Test]
    public void CheckSpecialPhoneProperty()
    {
        
        var phoneToCreate = new PhoneModel
        {
            name = "Sony Ericsson k700i",
            data = new PhonesData
            {
                color = "Black",
                price = 20,
                capacityGB = 41,
                year = 2004
            }
        };
        var createdPhone = new PhonesController(new CustomRestClient()).AddPhone<AllPhonesModels>(phoneToCreate).Phone;
        phoneToCreate.data.color = "Silver";
        createdPhone = new PhonesController(new CustomRestClient()).AddPhone<AllPhonesModels>(phoneToCreate).Phone;

        var receivedPhone = new PhonesController(new CustomRestClient()).GetPhones<AllPhonesModels>(createdPhone.id).Phone;
        Assert.That(phoneToCreate.data.color, Is.EqualTo(receivedPhone.data.color), "Color was not changed!");
        new PhonesController(new CustomRestClient()).DeletePhone<AllPhonesModels>(receivedPhone.id);
    }
}