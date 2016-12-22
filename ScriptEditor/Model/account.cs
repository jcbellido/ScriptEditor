using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.Model
{
    public class Account
    {
        protected int m_value;

        public Account(int value)
        {
            m_value = value;
        }

        public int Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = 2 * value;
            }
        }
    }
}
