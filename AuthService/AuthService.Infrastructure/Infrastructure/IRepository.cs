﻿namespace AuthService.Infrastructure;

public interface IRepository : IBaseRepositoryHub
{
    IUserRepository Users { get; }
}
