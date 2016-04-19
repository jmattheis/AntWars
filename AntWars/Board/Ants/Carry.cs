namespace AntWars.Board.Ants {

    public class Carry : Ant {

        internal Carry(Board board, Player owner, int viewRange, int inventory, int moveRange, int hp)
            : base(board, owner, viewRange, inventory, moveRange, hp, 0) { }

    }
}
