using System.Net.Mail;
using CourseworkTooling;

namespace UserSystem;

/// <summary>
/// The most basic representation of a user. 
/// </summary>
public class User : IEquatable<User>, IEquatable<string>, IComparable<User>
{
    // Properties that every user should have
    public virtual Guid? ID { get; set; } = Guid.NewGuid();
    public virtual string? Username { get; set; }
    public virtual Password? Password { get; set; }
    public virtual MailAddress? Email { get; set; }
    public virtual DateTime? DOB { get; set; }
    public virtual string[]? FullName { get; set; }

    /// <summary>
    /// Indexer allows for lookup of users by username
    /// </summary>
    /// <param name="username">The unique username of the user to lookup</param>
    /// <returns>A User if found, null if not</returns>
    public User? this[string username]
    {
        get
        {
            // Access Global state
            var state = GetGlobalState();

            // Fina all users
            var users = state.Get<User>(STATE_USER);

            // return the first match
            return users.FirstOrDefault(x => x.Username == username);
        }
    }

    /// <summary>
    /// Indexer allows for lookup of users by email addresses
    /// </summary>
    /// <param name="email">The email of the users to lookup</param>
    /// <returns>A list of users that match the email</returns>
    public IEnumerable<User?> this[MailAddress email]
    {
        get
        {
            // Access Global state
            var state = GetGlobalState();

            // Fina all users
            var users = state.Get<User>(STATE_USER);

            // return the first match
            return users.Where(x => x.Email == email);
        }
    }

    /// <summary>
    /// Indexer alows for lookup of user by unique ID
    /// </summary>
    /// <param name="guid">The guid of the user</param>
    /// <returns>A user if found, null if not</returns>
    public User? this[Guid guid]
    {
        get
        {
            var state = GetGlobalState();

            var users = state.Get<User>(STATE_USER);

            return users.FirstOrDefault(x => x.ID == guid);
        }
    }

    public static string UserPath = "users.json";

    public static User From(string username, string password)
    {
        User user = new User()
        {
            Username = username,
            Password = password.CreatePassword()
        };

        // Add to global state
        GlobalStateAdd(
            user.GetState()
            );

        return user;
    }

    public virtual int CompareTo(User? other)
    {
        if(Username is null)
        {
            return 0;
        }
        return Username.CompareTo(other?.Username);
    }

    public virtual bool Equals(string? other)
    {
        if (other is null)
        {
            return false;
        }

        if (Username is null)
        {
            return false;
        }

        return Username.Equals(other);
    }

    public virtual bool Equals(User? other)
    {
        return Equals(other);
    }

    public static bool operator ==(User a, User b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(User a, User b)
    {
        return !a.Equals(b);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator <(User left, User right)
    {
        return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
    }

    public static bool operator <=(User left, User right)
    {
        return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
    }

    public static bool operator >(User left, User right)
    {
        return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
    }

    public static bool operator >=(User left, User right)
    {
        return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
    }
}
