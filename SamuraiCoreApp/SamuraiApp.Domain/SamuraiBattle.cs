using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
    public class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; } //nav prop is optional
        public int BattleId { get; set; }
        public Battle Battle { get; set; }  //nam prop is optional
    }
}
