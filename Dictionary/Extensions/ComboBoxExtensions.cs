using Dictionary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dictionary.Extensions
{
    public static partial class Extensions
    {
        public static object GetItemWithComboBoxText(this ComboBox q, IEnumerable<Language> list)
        {
            return list.FirstOrDefault(l => q.Text == l.ShortForm);
        }
    }
}
