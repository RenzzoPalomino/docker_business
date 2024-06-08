using BE;
using DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Type_Weapon
    {
        private readonly DA_Type_Weapon _da_twepon;

        public BL_Type_Weapon()
        {
            _da_twepon = new DA_Type_Weapon();
        }

        public List<Type_Weapon> GET_TYPE_WEAPONS()
        {
            try
            {
                var response = _da_twepon.getTypeWeapons();
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool NEW_TYPE_WEAPON(Type_Weapon item)
        {
            try
            {
                bool response = _da_twepon.newTypeWeapon(item);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UPDATE_TYPE_WEAPON(Type_Weapon item)
        {
            try
            {
                bool response = _da_twepon.updateTypeWeapon(item);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DELETE_TYPE_WEAPON(int id_type)
        {
            try
            {
                bool response = _da_twepon.deleteTypeWeapon(id_type);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
