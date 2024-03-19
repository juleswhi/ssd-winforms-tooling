global using Password = (string Hashed, byte[] Salt);

using System.Net.Mail;

namespace UserSystem;

/// <summary>
/// The most basic representation of a user. 
/// </summary>
public abstract class UserBase : IEquatable<UserBase>, IEquatable<string>, IComparable<UserBase>, IComparable<int>
{
    // Properties that every user should have
    public virtual string? Username { get; set; }
    public virtual Password? Password { get; set; }
    public virtual MailAddress? Email { get; set; }
    public virtual DateTime? DOB { get; set; }
    public virtual string[]? FullName { get; set; }


    public static string UserPath = "users.json";

    public abstract int CompareTo(UserBase? other);
    public abstract int CompareTo(int other);

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

    public virtual bool Equals(UserBase? other)
    {
        return Equals(other);
    }

    public static bool operator ==(UserBase a, UserBase b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(UserBase a, UserBase b)
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

    public static bool operator <(UserBase left, UserBase right)
    {
        return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
    }

    public static bool operator <=(UserBase left, UserBase right)
    {
        return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
    }

    public static bool operator >(UserBase left, UserBase right)
    {
        return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
    }

    public static bool operator >=(UserBase left, UserBase right)
    {
        return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
    }
}
