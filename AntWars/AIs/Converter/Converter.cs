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
        public List<AIBoardObject> getAIObjects(List<BoardObject> boardObjects)
        {
            List<AIBoardObject> AIboardObjects = new List<AIBoardObject>();
            foreach (BoardObject boardObject in boardObjects)
            {
                AIBoardObject AIboardObject;
                if (boardObject.isAnt())
                {
                    AIboardObject = new AIAnt((Ant)boardObject);
                }
                else if (boardObject.isBase())
                {
                    AIboardObject = new AIBase((Base)boardObject);
                }           
                else if (boardObject.isCarry())
                {
                    AIboardObject = new AICarry((Carry)boardObject);
                }
                else if (boardObject.isScout())
                {
                    AIboardObject = new AIScout((Scout)boardObject);
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
