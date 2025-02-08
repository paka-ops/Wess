using System.ComponentModel;
using FlotteApplication.Data;
using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FlotteApplication.Repositories.Implementation
{
    public class AdminRepository : IAdmin
    {
        public Boolean IsAdminExist(int adminId)
        {
            var adminContext = new DataSource();
            var existAdmin = adminContext.Admin.Where(e => e.adminId == adminId);
            if (existAdmin.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<String> addAdmin(Admin admin)
        {
            var IsExist = IsAdminExist(admin.adminId);
            if (IsExist == true)
            {
                return "Il existe déjà";
            }
            else
            {
                try
                {
                    using (var adminContext = new DataSource())
                    {
                        adminContext.Add(admin);
                        await adminContext.SaveChangesAsync();
                    }
                    return "Enregistrement effectué avec succes";
                }
                catch (Exception ex)
                {
                    return " erreur " + ex.InnerException;
                }
            }
        }

        public Boolean LoginAdmin(Admin admin)
        {
            using (var adminContext = new DataSource())
            {
                try
                {
                    Boolean result;
                    var adminName = adminContext.Admin.FirstOrDefault(e => e.name == admin.name);
                    if (adminName != null)
                    {
                        if (adminName.password == admin.password)
                        {
                            result = true;
                            return result;
                        }
                        else
                        {
                            result = false;
                            return result;
                        }
                    }
                    else
                    {
                        return false;

                    }
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
    }
}
