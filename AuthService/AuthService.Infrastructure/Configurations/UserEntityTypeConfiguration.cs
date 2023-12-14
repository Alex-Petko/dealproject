﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace AuthService.Domain.Configurations.EntityTypeConfigurations;

[ExcludeFromCodeCoverage]
internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Login);
        builder
            .Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(128);
    }
}