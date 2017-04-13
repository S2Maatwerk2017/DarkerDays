using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class DropBag:MonoBehaviour
    {
        public List<Item> DropBagItems { get; private set; }

        public DropBag()
        {
            DropBagItems = new List<Item>();
        }
    }
}
