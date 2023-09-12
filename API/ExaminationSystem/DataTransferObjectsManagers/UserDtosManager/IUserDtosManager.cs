using McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager.UserDtos;

namespace McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager
{
    public interface IUserDtosManager : IDtosManager<UserDto>
    {
        UserDto? GetUserDtoByUserCredentials(UserCredentialsDto userCredentialsDto);
    }
}
