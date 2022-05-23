using ClownOnThisSIde.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownOnThisSIde.Helper
{
    static class SetComboBox
    {
        public static string[] _sortList = new string [6] { "Наим. по воз", "Наим. по убыв.",
                                                           "№ цеха по воз.", "№ цеха по убыв.",
                                                           "Мин. стоимость по воз.", "Мин стоимость по убыв." };

        public static List<ProductType> GetOrdList()
        {
            using (ModelBD model = new ModelBD())
            {
                var types = from t in model.ProductType
                            select t;
                return types.ToList();
            }
        }

    }
}
