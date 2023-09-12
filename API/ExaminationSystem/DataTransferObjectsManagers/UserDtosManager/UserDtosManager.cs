using McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager.UserDtos;
using McqExaminationSystem.Repositories.UserRepository;

namespace McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager
{
    public class UserDtosManager : IUserDtosManager
    {
        private readonly IUserRepository userRepository;

        public UserDtosManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<UserDto> GetAllDtos()
        {
            var users = userRepository.GetAll();
            var usersDtos = new List<UserDto>();

            users.ForEach(user =>
            {
                usersDtos.Add(new UserDto(
                    user.UserName,
                    user.FullName,
                    user.Email,
                    user.UserId,
                    user.Password,
                    user.Role,
                    user.IsDeleted));
            });

            return usersDtos;
        }

        public UserDto? GetDtoById(int id)
        {
            var user = userRepository.GetById(id);
            return user == null ?
                   null
                   : new UserDto(
                    user.UserName,
                    user.FullName,
                    user.Email,
                    user.UserId,
                    user.Password,
                    user.Role,
                    user.IsDeleted);
        }

        public UserDto? GetUserDtoByUserCredentials(UserCredentialsDto userCredentialsDto)
        {
            var user = userRepository
                .GetByCredentials(userCredentialsDto.Username,
                                  userCredentialsDto.Password);

            return user == null ?
                   null
                   : new UserDto(
                    user.UserName,
                    user.FullName,
                    user.Email,
                    user.UserId,
                    user.Password,
                    user.Role,
                    user.IsDeleted);
        }

        public bool InsertEntityUsingDto(UserDto entity)
        {
            return userRepository.Insert(new Models.User()
            {
                UserName = entity.Username,
                FullName = entity.FullName,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role,
            });
        }

        public bool UpdateEntityUsingDto(UserDto entity)
        {
            return userRepository.Update(new Models.User()
            {
                UserId = entity.UserId,
                UserName = entity.Username,
                FullName = entity.FullName,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role,
            });
        }

        public bool DeleteEntity(int id)
        {
            return userRepository.Delete(id);
        }
    }
}
