using Core.DTOs;
using DataLayer.Entities.User;
using DataLayer.Entities.Wallet;

namespace Core.Services.Interfaces;

public interface IUserService
{
    bool IsExistUserName(string userName);
    bool IsExistEmail(string email);
    int AddUser(User user);
    User LoginUser(LoginViewModel login);
    bool ActiveAccount(string activeCode);
    User GetUserByEmail(string email);
    User GetUserByActiveCode(string activeCode);
    void UpdateUser(User user);
    User GetUserByUserName(string username);
    int GetUserIdByUserName(string username);
    User GetUserById(int userId);

    #region UserPanel
    InformationUserViewModel GetUserInformation(string username);
    InformationUserViewModel GetUserInformation(int userId);
    SideBarUserPanelViewModel GetSideBarUserPanelData(string username);
    EditProfileViewModel GetDataForEditProfileUser(string username);
    void EditProfile(string username, EditProfileViewModel profile);
    bool CompareOldPassword(string oldPassword, string username);
    void ChangeUserPassword(string userName, string newPassword);

    #endregion

    #region Wallet

    int BalanceUserWallet(string userName);
    List<WalletViewModel> GetWalletUser(string userName);
    int ChargeWallet(string userName,int amount,string description,bool isPay=false);
    int AddWallet(Wallet wallet);
    Wallet GetWalletByWalletId(int walletId);
    void UpdateWallet(Wallet wallet);

    #endregion

    #region Admin Panel

    UsersForAdminViewModel GetUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
    UsersForAdminViewModel GetDeleteUsers(int pageId = 1, string filterEmail = "", string filterUserName="");
    int AddUserFromAdmin(CreateUserViewModel user);
    EditUserViewModel GetUserForShowInEditMode(int userId);
    void EditUserFromAdmin(EditUserViewModel editUser);
    void DeleteUser(int userId);


    #endregion



}