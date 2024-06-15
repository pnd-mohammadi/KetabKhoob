using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;
using System.Xml.Linq;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        private User() { }
        public User(string name, string family, string email, string password, string phoneNumber, Gender gender, IUserDomainService _domainService)
        {
            Guard(email, phoneNumber, _domainService);
            Name = name;
            Family = family;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Gender = gender;
            AvatarName = "avatr.png";
            IsActive = true;
            Addresses = new();
            Roles = new();
            Wallets = new();
            Tokens = new();
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string AvatarName { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsActive { get; set; } 
        public List<UserAddress> Addresses { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserRole> Roles { get; private set; }
        public List<UserToken> Tokens { get; }

        public void Edit(string name, string family, string phoneNumber, string email,
            Gender gender, IUserDomainService _domainService)
        {
            Guard(email, phoneNumber, _domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public static User RegisterUser(string phoneNumber, string password, IUserDomainService userDomainService)
        {
            return new User("", "",  null, password, phoneNumber, Gender.None, userDomainService);
        }

        public void EditAddress(UserAddress addreess, long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
            if (oldAddress == null)
            {
                throw new NullOrEmptyDomainDataException();
            }
            oldAddress = addreess;
        }
        public void DeleteAddress(long addressid)
        {
            var currentAddress = Addresses.FirstOrDefault(f => f.Id == addressid);
            if (currentAddress == null)
            {
                new NullOrEmptyDomainDataException();
            }
            Addresses.Remove(currentAddress);
        }
        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }
        public void ChangePassword(string password)
        {
            Password = password;

        }
        public void SetAvatar(string ImageName)
        {
            if (string.IsNullOrWhiteSpace(ImageName))
                ImageName = "Avatar.png";
            AvatarName = ImageName;

        }
        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }
        public void SetActiveAddress(long addressid)
        {
            var currentAddress = Addresses.FirstOrDefault(f => f.Id == addressid);
            if (currentAddress == null)
            {
                new NullOrEmptyDomainDataException();
            }
            foreach (var address in Addresses)
            {
                address.DeActive();
            }
            currentAddress.Active();
        }
        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
            if (activeTokenCount == 3)
                throw new InvalidDomainDataException("امکان استفاده از 4 دستگاه همزمان وجود ندارد");

            var token = new UserToken(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
            token.UserId = Id;
            Tokens.Add(token);
        }

        public string RemoveToken(long tokenId)
        {
            var token = Tokens.FirstOrDefault(f => f.Id == tokenId);
            if (token == null)
                throw new InvalidDomainDataException("invalid TokenId");

            Tokens.Remove(token);
            return token.HashJwtToken;
        }
        public void Guard(string email, string phoneNumber, IUserDomainService userDomainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));

            if (phoneNumber.Length != 11)
                throw new NullOrEmptyDomainDataException("mobile not valid");

            if (!string.IsNullOrWhiteSpace(email))
                if (email.IsValidEmail() == false)
                    throw new NullOrEmptyDomainDataException("email not valid");

            if (phoneNumber != PhoneNumber)
                if (userDomainService.PhoneNumberIsExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");

            if (email != Email)
                if (userDomainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");
        }
    }
}
