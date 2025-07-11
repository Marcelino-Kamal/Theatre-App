﻿using Theatre_App.DTO.UserDtos;

namespace Theatre_App.Service.UserServices
{
    public interface IUserService
    {
        Task<UserResponeDto> GetUserById(Guid id);
        Task<string> UpdateUser(UserUpdateDto dto);
        Task<List<UserAdminResponseDto>> GetAllUsers();
        Task<string> ApproveUser(UserStatusDto dto);
    }
}
