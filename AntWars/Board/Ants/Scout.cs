﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    public class Scout : Ant
    {
        internal Scout(Board board, Player owner) : base(board, owner) {
            this.Speed = owner.PlayerConfig.ScoutSpeed;
        }
    }
}
