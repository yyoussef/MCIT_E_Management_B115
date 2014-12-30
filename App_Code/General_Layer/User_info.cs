using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLSTCOMLib;
using System.Data;
using System.Collections;
using System.Web.UI;

/// <summary>
/// Summary description for User_info
/// </summary>
public class User_info
{
    
    String SLSTSDKPATH = "SLSTSDK.DLL";
    SLST ST = new SLST();
    string Token_User_pin;
    public User_info(string mToken_User_pin)
    {
        Token_User_pin = mToken_User_pin;
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Check_Valid_Token_login()
    {
        bool flag = true;
        int ERR = TestToken();
        if (ERR != (int)SLSTCOM_ERR.SLSTCOM_OK)
            flag = false;
        else
            flag = true;

        return flag;

    }

    private int TestToken()
    {
        int ERR;
        //intialize Smart token SDK library
        ST.SLSTInitialize(SLSTSDKPATH);
        ERR = ST.GetLastError(); if (ERR != 0) return ERR;
        UInt32[] TokensIDs;

        //Enumerate all smart tokens connected
        TokensIDs = (UInt32[])ST.SLSTEnumerateTokens();
        ERR = ST.GetLastError(); if (ERR != 0) return ERR;

        //check there at least one token connected
        if (TokensIDs.Length > 0)
        {
            //open session
            uint SessionID = ST.SLSTOpenSession(TokensIDs[0]);



            //obj.ProductID
            //struct  SLSTTokenInfo = 
            ERR = ST.GetLastError(); if (ERR != 0) return ERR;
            //login as user
            ST.SLSTLogin(SessionID, Token_User_pin, (uint)SLSTCOM_USERTYPE.SLSTCOM_USERTYPE_USER);
            ERR = ST.GetLastError(); if (ERR != 0) return ERR;
            ST.SLSTGetTokenInfo(SessionID);

            ////Start Encryption
            //SLSTSCryptKey CK = new SLSTSCryptKey();
            //SLSTSCryptMechanism CM = new SLSTSCryptMechanism();
            //CK.ALGID = (ushort)SLSTCOM_ALG.SLSTCOM_ALG_CRYPT_DES;
            //byte[] Key = { 0, 1, 2, 3, 4, 5, 6, 7 };
            //CK.Key = Key;
            //CM.ALGID = (ushort)SLSTCOM_ALG.SLSTCOM_ALG_CRYPT_DES;
            //CM.Mode = (ushort)SLSTCOM_CRYPT_MODE.SLSTCOM_CRYPT_MODE_CBC;
            //CM.StreamBlockSize = 0;
            //byte[] IV = { 0, 1, 2, 3, 4, 5, 6, 7 };
            //CM.IV = IV;

            //byte[] OrgData = { 0, 1, 2, 3, 4, 5, 6, 7 };
            //byte[] EncData;
            //byte[] DecData;

            ////Encrypt Initialization
            //uint ECryptoID = ST.SLSTCryptInitialize(SessionID, CK, CM);
            //ERR = ST.GetLastError(); if (ERR != 0) return ERR;
            ////Perform Encryption
            //EncData = (byte[])ST.SLSTCryptEncrypt(ECryptoID, OrgData, 1);
            //ST.SLSTCryptFinalize(ECryptoID);

            ////Decrypt
            ////Decrypt Initialize
            //uint DCryptoID = ST.SLSTCryptInitialize(SessionID, CK, CM);
            //ERR = ST.GetLastError(); if (ERR != 0) return ERR;
            ////Perform Decryption
            //DecData = (byte[])ST.SLSTCryptDecrypt(DCryptoID, EncData, 1);
            //ST.SLSTCryptFinalize(DCryptoID);
            ////check that decrypted data the same as orriginal data
            //Boolean Matched = true;
            //for (int i = 0; i < OrgData.Length; i++)
            //    if (OrgData[i] != DecData[i])
            //        Matched = false;

            //if (Matched)
            //{
            //    MessageBox.Show("Date is encrypted and decrypted successfully.");
            //}
            //else
            //{
            //    MessageBox.Show("Error encrypting or decrypting the data.");
            //}
            //logout
            ST.SLSTLogout(SessionID);
            //close session
            ST.SLSTCloseSession(SessionID);

            //close connection with SDK libraray
            ST.SLSTFinalize();

            return (int)SLSTCOM_ERR.SLSTCOM_OK;

        }
        else
        {
            //close connection with SDK libraray
            ST.SLSTFinalize();

            return 1;
        }



    }

    public static ArrayList GetUserPagesByRoleID(int roleID)
    {
        Admin_Athorization_Select_Role_Page_SP SP = new Admin_Athorization_Select_Role_Page_SP();
        SP.RoleID = roleID;

        DataTable PagesDataTable = Admin_Athorization_Select_Role_Page_SP.Get_DataTable(SP);
        ArrayList PagesList = new ArrayList();

        foreach (DataRow dr in PagesDataTable.Rows)
        {
            PagesList.Add(CDataConverter.ConvertToInt(dr["pk_ID"]));
        }

        return PagesList;
    }
    public static ArrayList DT_User_Permission
    {
        
        get
        {
            //Session_CS Session_CS = new Session_CS();
            //Page obj = new Page();

            //if (obj.Session["Arr_User_Permission"] == null)
            //{
            //    if (obj.Session["pmp_id"] != null)
            //    {
            ArrayList Arr_User_Permission = new ArrayList();

            DataTable DT_User = Users_Permission_DB.Select_by_pmp_pmp_id(Session_CS.pmp_id);
            foreach (DataRow dr in DT_User.Rows)
            {
                Arr_User_Permission.Add(CDataConverter.ConvertToInt(dr["Page_ID"].ToString()));
            }
            return Arr_User_Permission;
            //    }
            //    else
            //        return null;
            //}
            //else
            //    return obj.Session["Arr_User_Permission"] as ArrayList;
        }

    }


}
