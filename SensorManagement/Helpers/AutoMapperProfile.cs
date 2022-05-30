namespace SensorManagement.Helpers;

using AutoMapper;
using SensorManagement.Models;
using SensorManagement.Models.Temperature;
using SensorManagement.Models.Users;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserCreateRequest, User>();

        CreateMap<UserUpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    if (prop == null)
                    {
                        return false;
                    }

                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop))
                    {
                        return false;
                    }

                    if (x.DestinationMember.Name == "Role" && src.Role == null)
                    {
                        return false;
                    }

                    return true;
                }
            ));

        CreateMap<TemperatureCreateRequest, TemperatureLog>();
    }
}