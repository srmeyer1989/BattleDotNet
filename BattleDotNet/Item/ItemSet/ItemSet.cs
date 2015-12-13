using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleDotNet.Item.ItemSet
{
    public class ItemSet
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<SetBonus> setBonuses { get; set; }
        public List<int> items { get; set; }
    }
}
