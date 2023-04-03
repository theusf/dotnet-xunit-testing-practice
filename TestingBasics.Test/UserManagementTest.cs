using TestingBasics.Functionalities;

namespace TestingBasics.Test
{
    public class UserManagementTest
    {
        private readonly User testUser = new User (
                  "Matheus", "Francisco"
          );

        [Fact]
        public void Add_CreateUser()
        {

            // Arrange
            UserManagement userManagement = new UserManagement();

            // Act
            userManagement.Add(testUser with {});

            // Assert 
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
        
            Assert.Equal("Matheus", testUser.FirstName);
            Assert.Equal("Francisco", testUser.LastName);
            Assert.NotEmpty(savedUser.Phone);
            Assert.False(savedUser.VerifiedEmail);
        }

        [Fact]
        public void Verify_VerifyEmailAddress()
        {
            // Arrange
            var userManagement = new UserManagement();

            // Act
            userManagement.Add(testUser with {});

            var firstUser = userManagement.AllUsers.ToList().First();
            userManagement.VerifyEmail(firstUser.Id);

            // Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.True(savedUser.VerifiedEmail);
        }

        [Fact]
        public void Update_UpdateMobileNumber()
        {
            // Arrange
            var userManagement = new UserManagement();

            // Act
            userManagement.Add(testUser with {});

            var firstUser = userManagement.AllUsers.ToList().First();
            userManagement.VerifyEmail(firstUser.Id);

            string phone = "+5509090909090";
            firstUser.Phone = phone;
            userManagement.UpdatePhone(firstUser);

            // Assert
            var foundUser = Assert.Single(userManagement.AllUsers);
            Assert.Equal(phone, foundUser.Phone);
        }
    }
}