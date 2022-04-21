using System;
using System.Threading.Tasks;
using Xunit;
using HouseProject.Core.ServiceInterface;
using HouseProject.Core.Dtos;

namespace HouseProject.HouseTest
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyHouse_WhenReturnResult()
        {
            string guid = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";

            HouseDto house = new HouseDto();

            house.Id = Guid.Parse(guid);
            house.City = "Space";
            house.Street = "Estonia";
            house.Entrance = 5;
            house.Number = 2;
            house.Floor = 12;
            house.Area = 123123;
            house.CreatedAt = DateTime.Now;
            house.ModifieAt = DateTime.Now;

            var result = await Svc<IHouseService>().Add(house);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldNot_GetByIdHouse_WhenReturnsResultAsync()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "1ab8c12a-f8da-4e55-ab77-f45378d3adb5";

            //var request = new House();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().GetAsync(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
            //Assert.Single((System.Collections.IEnumerable)result);
        }

        [Fact]
        public async Task Should_GetByIdHouse_WhenReturnsResultAsync()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";
            string guid1 = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";

            //var request = new Spaceship();
            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IHouseService>().GetAsync(insertGuid);

            Assert.Equal(insertGuid1, insertGuid);
            //Assert.Single((System.Collections.IEnumerable)result);
        }

        [Fact]
        public async Task Should_DeleteByIdHouse_WhenDeleteSpaceship()
        {
            string guid = "e6771076-91cd-4169-bbdd-cfc5290a6b3f";

            //var request = new Spaceship();
            var insertGuid = Guid.Parse(guid);

            var result = await Svc<IHouseService>().Delete(insertGuid);

            Assert.NotEmpty((System.Collections.IEnumerable)result);
            Assert.Single((System.Collections.IEnumerable)result);
        }

        [Fact]
        public async Task Should_UpdateByIdHouse_WhenUpdateSpaceship()
        {
            var guid = new Guid("1ab8c12a-f8da-4e55-ab77-f45378d3adb5");

            HouseDto house = new HouseDto();

            house.Id = guid;
            house.City = "Space";
            house.Street = "Estonia";
            house.Entrance = 5;
            house.Number = 2;
            house.Floor = 12;
            house.Area = 123123;
            house.CreatedAt = DateTime.Now;
            house.ModifieAt = DateTime.Now;

            var houseId = guid;
            var houseToUpdate = new HouseDto()
            {
                City = "Test",
                Floor = 456
            };

            await Svc<IHouseService>().Update(houseToUpdate);
            Assert.Equal(house.Id.ToString(), houseId.ToString());
            Assert.DoesNotMatch(house.Street, houseToUpdate.Street);
            Assert.DoesNotMatch(house.City.ToString(), houseToUpdate.City.ToString());
        }
    }
}
