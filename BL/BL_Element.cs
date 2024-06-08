using BE;
using DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_Element
    {
        private readonly DA_Element _da_element;

        public BL_Element()
        {
            _da_element = new DA_Element();
        }

        public List<Element> GET_NATIONS()
        {
            try
            {
                List<Element> response = _da_element.GetElements();
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
