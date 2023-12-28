﻿using AuthService.Application;
using FluentValidation.TestHelper;

namespace AuthService.Tests.Configurations.Validators
{
    public class CreateTokenDtoValidatorTests
    {
        [Fact]
        public async Task Validate_Ok_Ok()
        {
            // Arrange
            var createTokenDtoValidator = new CreateTokenDtoValidator();
            var dto = new CreateTokenDto("1", "2");

            // Act
            var result = await createTokenDtoValidator.TestValidateAsync(dto);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task Validate_LoginNull_NotEmptyErrorMessage()
        {
            // Arrange
            var createTokenDtoValidator = new CreateTokenDtoValidator();
            var dto = new CreateTokenDto(null!, "2");

            // Act
            var result = await createTokenDtoValidator.TestValidateAsync(dto);

            // Assert
            var message = ValidationErrorMessages.NotEmpty<CreateTokenDto, string>(x => x.Login);
            result.ShouldHaveValidationErrorFor(x => x.Login)
                .WithErrorMessage(message);
        }

        [Fact]
        public async Task Validate_PasswordHashNull_NotEmptyErrorMessage()
        {
            // Arrange
            var createTokenDtoValidator = new CreateTokenDtoValidator();
            var dto = new CreateTokenDto("1", null!);

            // Act
            var result = await createTokenDtoValidator.TestValidateAsync(dto);

            // Assert
            var message = ValidationErrorMessages.NotEmpty<CreateTokenDto, string>(x => x.PasswordHash);
            result.ShouldHaveValidationErrorFor(x => x.PasswordHash)
                .WithErrorMessage(message);
        }
    }
}