using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
using AntWars.AIs.Converter.Classes;

namespace AntWars.AIs.Converter
{
    class Converter
    {
        private Board.Board board;
        public Converter(Board.Board board)
        {
            this.board = board;
        }
        public List<AIBoardObject> getAIObjects(List<BoardObject> boardObjects)
        {
            List<AIBoardObject> AIboardObjects = new List<AIBoardObject>();
            foreach (BoardObject boardObject in boardObjects)
            {
                AIBoardObject AIboardObject;
               
                if (boardObject.isBase())
                {
                    AIboardObject = new AIBase((Base)boardObject);
                }           
                else if (boardObject.isCarry())
                {
                    AIboardObject = new AICarry((Carry)boardObject, board);
                }
                else if (boardObject.isScout())
                {
                    AIboardObject = new AIScout((Scout)boardObject, board);
                }
                else if (boardObject.isSugar())
                {
                    AIboardObject = new AISugar((Sugar)boardObject);
                }
                else //?
                {
                    AIboardObject = new AIBoardObject((BoardObject)boardObject);
                }
                AIboardObjects.Add(AIboardObject);
            }
            return AIboardObjects;
        }
    }
}
