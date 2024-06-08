using BE;
using DA;

namespace BL
{
    public class BL_Nation
    {
        private readonly DA_Nation _da_nation;

        public BL_Nation()
        {
            _da_nation = new DA_Nation();
        }

        public List<Nation> GET_NATIONS()
        {
            try
            {
                List<Nation> response = _da_nation.getNations();
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
