using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Excel
{
    public partial class TableData
    {
        public static TableData Inst = null;
        public NormalStatObject normalStat = null;
    }

    public partial class TableData
    {
        public TableData()
        {
            Inst = this;
            normalStat = new NormalStatObject();
        }
    }
}
