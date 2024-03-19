using System.Security.Cryptography;
using System.Text;
using UserSystem;

namespace CourseworkTooling;

/// <summary>
/// A collection of tools to help the user deal with hashing, especially with password hashing
/// </summary>
public static class HashTools
{

    public static Password CreatePassword(this string str)
    {
        var salt = RandomNumberGenerator.GetBytes(64);

        byte[] passwordBytes = Encoding.UTF8.GetBytes(str);

        var hashedPassword = Rfc2898DeriveBytes.Pbkdf2(passwordBytes,
            salt,
            100_000,
            HashAlgorithmName.SHA512,
            64);

        return (Encoding.UTF8.GetString(hashedPassword), salt);
    }

    public static bool VerifyHash(UserBase user, string password)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

        var hashed =
            Rfc2898DeriveBytes.Pbkdf2(passwordBytes,
            user.Password!.Value.Salt,
            100_1000,
            HashAlgorithmName.SHA512,
            64);

        if (Encoding.UTF8.GetString(hashed) == user.Password.Value.Hashed)
        {
            return true;
        }

        return false;
    }
}
