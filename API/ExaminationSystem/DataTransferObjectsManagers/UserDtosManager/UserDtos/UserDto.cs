namespace McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager.UserDtos
{
    public sealed record UserDto(
        string Username,
        string FullName,
        string Email,
        long UserId = 0,
        string Password = "",
        string Role = "",
        bool IsDeleted = false);
}
